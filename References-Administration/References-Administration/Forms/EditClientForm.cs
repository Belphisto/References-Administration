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

        //конструктор для формы редактирования объекта
        public EditClientForm(User client, DataBase dataBase)
        {
            InitializeComponent();
            _client = client;
            _dataBase = dataBase;
            CreateButton.Visible = false; //скрыть кнопку для создания объекта
            labelLogin.Visible = false;
            LoginTextBox.Visible = false;
            labelEmail.Visible = false;
            textBoxEmail.Visible = false;

            PasswordTextBox.PasswordChar = '*';
            PasswordRetryTextBox.PasswordChar = '*';
            LastPasswordTextBox.PasswordChar = '*';

            FullName.Text = _client.FullName;


            this.Load += EditClientForm_Load;
        }

        public EditClientForm(DataBase dataBase)
        {
            InitializeComponent();
            _client = new User();
            _dataBase = dataBase;
            SaveButton.Visible = false; //скрыть кнопку для сохранения редактированного объекта
            LastPasswordLabel.Visible = false;
            LastPasswordTextBox.Visible = false;
            this.Load += EditClientForm_Load;

            PasswordTextBox.PasswordChar = '*';
            PasswordRetryTextBox.PasswordChar = '*';
            LastPasswordTextBox.PasswordChar = '*';
        }

        private void EditClientForm_Load(object sender, EventArgs e)
        {
            // Проверить, содержит ли уже список подразделений элементы
            if (DepartmentsNameListBox.Items.Count == 0)
            {
                // Загрузить данные всех подразделений
                List<Division> departments = _dataBase.divisionController.GetDepartments();

                // Заполнить ListBox названиями подразделений
                foreach (var department in departments)
                {
                    DepartmentsNameListBox.Items.Add(department.Name);
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(_dataBase.userController.HashPassword(LastPasswordTextBox.Text) == _client.PasswordHash)
            {
                if (FullName.Text != "")
                {
                    _client.FullName = FullName.Text;
                    // Проверить, что выбран элемент в DepartmentsNameListBox
                    if (DepartmentsNameListBox.SelectedItem != null)
                    {
                        // Получить выбранное название подразделения
                        string selectedDepartmentName = DepartmentsNameListBox.SelectedItem.ToString();
                        Division selectedParent = _dataBase.divisionController.Read(selectedDepartmentName);
                        _client.DepartmentID = selectedParent.ID;
                    }
                    if (PasswordTextBox.Text != "")
                    {
                        if (PasswordRetryTextBox.Text == PasswordTextBox.Text)
                        {
                            _client.PasswordHash = _dataBase.userController.HashPassword(PasswordTextBox.Text);
                        }
                        else
                        {
                            Log.WriteLog($"EditClientForm : FormSaveButton_Click(object sender, EventArgs e)/ Редактирование объекта {_client} не удалось");
                            MessageBox.Show("Повторное введение нового пароля не совпадает с новым паролем!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    Log.WriteLog($"EditClientForm : FormSaveButton_Click(object sender, EventArgs e)/ Редактирование объекта {_client} не удалось");
                    MessageBox.Show("Поле ФИО не может быть пустым!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _dataBase.userController.UpdateClient(_client);
                Log.WriteLog($"EditClientForm : FormSaveButton_Click(object sender, EventArgs e)/ Редактирование объекта {_client} произошло успешно");
                this.Close();
            }
            else
            {
                Log.WriteLog($"EditClientForm : FormSaveButton_Click(object sender, EventArgs e)/ Редактирование объекта {_client} не удалось");
                MessageBox.Show("Для сохранения изменений введите старый пароль!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if ( LoginTextBox.Text != "" && FullName.Text != "" && PasswordTextBox.Text != "" && DepartmentsNameListBox.SelectedItem != null && textBoxEmail.Text != "")
            {

               // Получить выбранное название подразделения
               string selectedDepartmentName = DepartmentsNameListBox.SelectedItem.ToString();
                Division selectedParent = _dataBase.divisionController.Read(selectedDepartmentName);
               _client.DepartmentID = selectedParent.ID;
                //else { _client.DepartmentID = null; }
                if (PasswordTextBox.Text == PasswordRetryTextBox.Text)
                {
                    _client.FullName = FullName.Text;
                    _client.Login = LoginTextBox.Text;
                    _client.PasswordHash = _dataBase.userController.HashPassword(PasswordRetryTextBox.Text);
                    if ( _dataBase.userController.ValidEmail(textBoxEmail.Text))
                    {
                        _client.EmailAddress = textBoxEmail.Text;
                        try
                        {
                            _dataBase.userController.CreateClient(_client);
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
            else
            {
                Log.WriteLog($"EditClientForm : Form/CreateButton_Click(object sender, EventArgs e)/ Создание объекта не удалось");
                MessageBox.Show("Не все поля заполнены!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
