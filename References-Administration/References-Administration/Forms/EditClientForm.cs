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
        private Client _client;
        private DataBaseController _dataBase;

        //конструктор для формы редактирования объекта
        public EditClientForm(Client client, DataBaseController dataBase)
        {
            Log.WriteLog($" EditClientForm : Form/EditClientForm(Client client, DataBaseController dataBase)/ Форма для редактирования открыта");
            InitializeComponent();
            _client = client;
            _dataBase = dataBase;
            CreateButton.Visible = false; //скрыть кнопку для создания объекта
            labelLogin.Visible = false;
            LoginTextBox.Visible = false;

            FullName.Text = _client.FullName;


            this.Load += EditClientForm_Load;
        }

        public EditClientForm(DataBaseController dataBase)
        {
            Log.WriteLog($" EditClientForm : Form/EditClientForm(Client client, DataBaseController dataBase)/ Форма для редактирования открыта");
            InitializeComponent();
            _client = new Client();
            _dataBase = dataBase;
            SaveButton.Visible = false; //скрыть кнопку для сохранения редактированного объекта
            LastPasswordLabel.Visible = false;
            LastPasswordTextBox.Visible = false;
            this.Load += EditClientForm_Load;
        }

        private void EditClientForm_Load(object sender, EventArgs e)
        {
            // Загрузить данные всех подразделений
            List<Department> departments = DepartmentController.GetDepartments(_dataBase.Connection);

            // Заполнить ListBox названиями подразделений
            foreach (Department department in departments)
            {
                DepartmentsNameListBox.Items.Add(department.Name);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ClientController.HashPassword(LastPasswordTextBox.Text) == _client.PasswordHash)
            {
                if (FullName.Text != "")
                {
                    _client.FullName = FullName.Text;
                    // Проверить, что выбран элемент в DepartmentsNameListBox
                    if (DepartmentsNameListBox.SelectedItem != null)
                    {
                        // Получить выбранное название подразделения
                        string selectedDepartmentName = DepartmentsNameListBox.SelectedItem.ToString();

                        Department selectedParent = Department.Read(_dataBase.Connection, selectedDepartmentName);
                        _client.DepartmentID = selectedParent.ID;
                    }
                    if (PasswordTextBox.Text != "")
                    {
                        if (PasswordRetryTextBox.Text == PasswordTextBox.Text)
                        {
                            _client.PasswordHash = ClientController.HashPassword(PasswordTextBox.Text);
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
                _client.Update(_dataBase.Connection);
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
            if (DepartmentsNameListBox.SelectedItem != null && LoginTextBox.Text != "" && FullName.Text != "" && PasswordTextBox.Text != "")
            {
                if (PasswordTextBox.Text == PasswordRetryTextBox.Text)
                {
                    _client.FullName = FullName.Text;
                    _client.Login = LoginTextBox.Text;
                    _client.PasswordHash = ClientController.HashPassword(PasswordRetryTextBox.Text);

                    // Получить выбранное название подразделения
                    string selectedDepartmentName = DepartmentsNameListBox.SelectedItem.ToString();
                    Department selectedParent = Department.Read(_dataBase.Connection, selectedDepartmentName);
                    _client.DepartmentID = selectedParent.ID;
                    try
                    {
                        _client.Create(_dataBase.Connection);
                        Log.WriteLog($"EditClientForm : Form/CreateButton_Click(object sender, EventArgs e)/ Создание объекта {_client} произошло успешно");
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
