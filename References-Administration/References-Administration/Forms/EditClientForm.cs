using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace References_Administration
{
    public partial class EditClientForm : Form
    {
        private User _client;
        private DataBase _dataBase;
        private bool _editMode;

        //конструктор для формы редактирования объекта
        public EditClientForm(User client, DataBase dataBase)
        {
            InitializeComponent();
            _client = client;
            _dataBase = dataBase;
            _editMode = true;
            //this.Load += EditClientForm_Load;
            InitializeForm();

        }

        public EditClientForm(DataBase dataBase)
        {
            InitializeComponent();
            _client = new User();
            _editMode = false;
            _dataBase = dataBase;

            //this.Load += EditClientForm_Load;
            InitializeForm();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (_dataBase.UserController.HashPassword(LastPasswordTextBox.Text) != _client.PasswordHash)
            {
                MessageBox.Show("Для сохранения изменений введите старый пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (FullName.Text == "")
            {
                MessageBox.Show("Поле ФИО не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _client.FullName = FullName.Text;

            // Проверить, что выбран элемент в DepartmentsNameListBox
            if (DepartmentsNameListBox.SelectedItem != null)
            {
                // Получить выбранное название подразделения
                string selectedDepartmentName = DepartmentsNameListBox.SelectedItem.ToString();
                Division selectedParent = _dataBase.DivisionController.Read(selectedDepartmentName);
                _client.DepartmentID = selectedParent.ID;
             }

            if (!string.IsNullOrEmpty(PasswordTextBox.Text) && PasswordTextBox.Text == PasswordRetryTextBox.Text)
            {
                _client.PasswordHash = _dataBase.UserController.HashPassword(PasswordTextBox.Text);
            }
            else
             {
                Log.WriteLog($"EditClientForm : FormSaveButton_Click(object sender, EventArgs e)/ Редактирование объекта {_client} не удалось");
                MessageBox.Show("Повторное введение нового пароля не совпадает с новым паролем!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

            _dataBase.UserController.UpdateClient(_client);
             Close();
            
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text == "" || FullName.Text == "" || PasswordTextBox.Text == "" || DepartmentsNameListBox.SelectedItem == null || textBoxEmail.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                // Получить выбранное название подразделения
                string selectedDepartmentName = DepartmentsNameListBox.SelectedItem.ToString();
                Division selectedParent = _dataBase.DivisionController.Read(selectedDepartmentName);
               _client.DepartmentID = selectedParent.ID;
                //else { _client.DepartmentID = null; }
                if (PasswordTextBox.Text == PasswordRetryTextBox.Text)
                {
                    _client.FullName = FullName.Text;
                    _client.Login = LoginTextBox.Text;
                    _client.PasswordHash = _dataBase.UserController.HashPassword(PasswordRetryTextBox.Text);
                    if ( _dataBase.UserController.ValidEmail(textBoxEmail.Text))
                    {
                        _client.EmailAddress = textBoxEmail.Text;
                        try
                        {
                            _dataBase.UserController.CreateClient(_client);
                            this.Close();
                        }
                        catch (Npgsql.PostgresException ex)
                        {
                            if (ex.SqlState == "23505")
                            {
                                // Обработка повторяющегося значения ключа
                                MessageBox.Show("Пользователь с таким логином уже существует.");
                            }
                            else
                            {
                                // Обработка других ошибок PostgreSQL
                                MessageBox.Show("Произошла ошибка при создании клиента: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введен некорректный почтовый адрес!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Log.WriteLog($"EditClientForm : FormSaveButton_Click(object sender, EventArgs e)/ Создание объекта {_client} не удалось");
                    MessageBox.Show("Повторное введение нового пароля не совпадает с новым паролем!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void InitializeForm()
        {
            // Загрузить данные всех подразделений
            var _departments = _dataBase.DivisionController.GetDepartments();

            // Заполнить ListBox названиями подразделений
            foreach (var department in _departments)
            {
                DepartmentsNameListBox.Items.Add(department.Name);
            }

            // Скрыть/показать соответствующие элементы формы в зависимости от сценария использования


            CreateButton.Visible = !_editMode;
            SaveButton.Visible = _editMode;
            LastPasswordLabel.Visible = _editMode;
            LastPasswordTextBox.Visible = _editMode;
            labelLogin.Visible = !_editMode;
            LoginTextBox.Visible = !_editMode;
            labelEmail.Visible = !_editMode;
            textBoxEmail.Visible = !_editMode;

            PasswordTextBox.PasswordChar = '*';
            PasswordRetryTextBox.PasswordChar = '*';
            LastPasswordTextBox.PasswordChar = '*';

            if (_editMode)
            {
                FullName.Text = _client.FullName;
                LoginTextBox.Text = _client.Login;
                textBoxEmail.Text = _client.EmailAddress;
            }
        }
    }
}
