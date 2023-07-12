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
    public partial class ClientsForm : Form
    {
        private DataBase _dataBase;
        private List<User> _clients;
        private List<Division> _divisions;
        public ClientsForm(DataBase dataBase)
        {
            InitializeComponent();
            _dataBase = dataBase;

            dataGridView1.ReadOnly = true;
            bindingNavigator1.AddNewItem.Enabled = true;
            bindingNavigator1.DeleteItem.Enabled = true;

            this.Load += ClientsForm_Load;
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            // Подключение к базе данных

            // Получить данные из базы данных
            _clients = _dataBase.userController.GetClients();
            _divisions = _dataBase.divisionController.GetDepartments();

            // Заполнить таблицу данными клиентов
            // Преобразовать список клиентов только с нужными полями в анонимный тип
            var clientsData = _clients.Select(c => new
            {
                Login = c.Login,
                FullName = c.FullName,
                Email = c.EmailAddress,
                Department = _dataBase.divisionController.GetDepartmentName(c.DepartmentID)
            }).ToList();

            // Заполнить таблицу данными клиентов
            dataGridView1.DataSource = clientsData;

            // Загрузить все роли
            RefreshRolesView();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            EditClientForm editForm = new EditClientForm(_dataBase);
            Log.WriteLog("Открыта форма для добавления пользователя;");
            editForm.ShowDialog();
            RefreshDataGridView();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                User editClient = _dataBase.userController.ReadClient(selectedRow.Cells["Login"].Value.ToString());
                _dataBase.userController.DeleteClient(editClient);
                // Обновить данные в dataGridView1
                RefreshDataGridView();
            }
        }

        private void toolStripEditButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                User editClient = _dataBase.userController.ReadClient(selectedRow.Cells["Login"].Value.ToString());
                EditClientForm editForm = new EditClientForm(editClient, _dataBase);
                editForm.ShowDialog();
                RefreshDataGridView();
            }
        }

        private void RefreshDataGridView()
        {
            // Очистить dataGridView1
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            _clients = _dataBase.userController.GetClients();
            _divisions = _dataBase.divisionController.GetDepartments();

            // Заполнить таблицу данными клиентов
            // Преобразовать список клиентов только с нужными полями в анонимный тип
            var clientsData = _clients.Select(c => new
            {
                Login = c.Login,
                FullName = c.FullName,
                Email = c.EmailAddress,
                Department = _dataBase.divisionController.GetDepartmentName(c.DepartmentID)
            }).ToList();

            // Заполнить таблицу данными клиентов
            dataGridView1.DataSource = clientsData;
        }

        private void buttonEditRole_Click(object sender, EventArgs e)
        {
            if (comboBoxEditRole.SelectedItem != null && textBoxNewRole.Text != "")
            {
                string lastrole = comboBoxEditRole.SelectedItem.ToString();
                string newrole = textBoxNewRole.Text;
                _dataBase.roleController.Update(lastrole, newrole);
                MessageBox.Show("роль обновлена успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                comboBoxEditRole.SelectedItem = null;
                textBoxNewRole.Text = "";
                RefreshRolesView();
            }
        }

        private void buttonDeleteRole_Click(object sender, EventArgs e)
        {
            if (comboBoxEditRole.SelectedItem != null)
            {
                string role = comboBoxEditRole.SelectedItem.ToString();
                _dataBase.roleController.Delete(role);
                MessageBox.Show("роль удалена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                comboBoxEditRole.SelectedItem = null;

                RefreshRolesView();
            }
            else
            {
                MessageBox.Show("Выберите роль из списка суещствующих", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateRole_Click(object sender, EventArgs e)
        {
            string newRole = textBoxNewRole.Text;
            try
            {
                if (newRole != "")
                {
                    _dataBase.roleController.Create(newRole);
                    MessageBox.Show("роль создана", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RefreshRolesView();
                    textBoxNewRole.Text = "";
                }
                else { MessageBox.Show("Роль не может быть пустой", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception)
            {
                MessageBox.Show("такая роль уже существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshRolesView()
        {
            comboBoxEditRole.Items.Clear();
            List<string> roles = _dataBase.roleController.GetRoles();
            // Заполнить ListBox названиями подразделений
            foreach (string role in roles)
            {
                comboBoxEditRole.Items.Add(role);
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            // Проверяем, есть ли выбранная строка в dataGridView1
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем выбранного клиента из выбранной строки
                User selectedClient = _dataBase.userController.ReadClient(selectedRow.Cells["Login"].Value.ToString());

                // Вызываем методы RefreshRolesToAddView и RefreshRolesToRemoveView
                RefreshRolesToAddView(selectedClient);
                RefreshRolesToRemoveView(selectedClient);
            }
        }

        private void RefreshRolesToAddView(User client)
        {
            checkedListBoxDeletedRoles.Items.Clear();
            List<string> roles = _dataBase.roleController.GetUserRoles(client);
            foreach (string role in roles)
            {
                checkedListBoxDeletedRoles.Items.Add(role);
            }
        }
        private void RefreshRolesToRemoveView(User client)
        {
            checkedListBoxAddingRoles.Items.Clear();
            List<string> roles = _dataBase.roleController.GetMissingRoles(client);
            foreach (string role in roles)
            {
                checkedListBoxAddingRoles.Items.Add(role);
            }
        }

        private void buttonDeleteUserRole_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            User client_deleterole = _dataBase.userController.ReadClient(selectedRow.Cells["Login"].Value.ToString());
            //List<string> selectedItems = new List<string>();
            foreach (var item in checkedListBoxDeletedRoles.CheckedItems)
            {
                string selectedItem = item.ToString();
                //selectedItems.Add(selectedItem);
                _dataBase.roleController.RemoveRoleFromClient(selectedItem, client_deleterole);
            }
            RefreshRolesToRemoveView(client_deleterole);
            RefreshRolesToAddView(client_deleterole);
        }

        private void buttonAddUserRole_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            User client_addrole = _dataBase.userController.ReadClient(selectedRow.Cells["Login"].Value.ToString());
            foreach (var item in checkedListBoxAddingRoles.CheckedItems)
            {
                string selectedItem = item.ToString();
                //selectedItems.Add(selectedItem);
                _dataBase.roleController.AddRoleToClient(selectedItem, client_addrole);
            }
            RefreshRolesToRemoveView(client_addrole);
            RefreshRolesToAddView(client_addrole);
        }
    }
}
