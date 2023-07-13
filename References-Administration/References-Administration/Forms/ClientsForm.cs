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
        private Session _session;
        //private List<User> _clients;
        //private List<Division> _divisions;
        public ClientsForm(DataBase dataBase, Session session)
        {
            InitializeComponent();
            _dataBase = dataBase;
            _session = session;
            if (_session.Roles != null)
            {
                SetButtonAccessibility(_session.Roles.Contains("Администратор"));
            }
            else { SetButtonAccessibility(false); }

            dataGridView1.ReadOnly = true;
            bindingNavigator1.AddNewItem.Enabled = true;

            this.Load += ClientsForm_Load;
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            // Загрузить все роли
            RefreshRolesView();
            RefreshDataGridView();
        }

        private void RefreshRolesView()
        {
            comboBoxEditRole.Items.Clear();
            List<string> roles = _dataBase.RoleController.GetRoles();
            // Заполнить ListBox названиями подразделений
            foreach (string role in roles)
            {
                comboBoxEditRole.Items.Add(role);
            }
        }

        private void RefreshDataGridView()
        {
            // Очистить dataGridView1
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Заполнить таблицу данными клиентов
            // Преобразовать список клиентов только с нужными полями в анонимный тип
            var clientsData = _dataBase.UserController.GetClients().Select(c => new
            {
                Login = c.Login,
                FullName = c.FullName,
                Email = c.EmailAddress,
                Department = _dataBase.DivisionController.GetDepartmentName(c.DepartmentID)
            }).ToList();

            // Заполнить таблицу данными клиентов
            dataGridView1.DataSource = clientsData;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            EditClientForm editForm = new EditClientForm(_dataBase);
            editForm.ShowDialog();
            RefreshDataGridView();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                User editClient = _dataBase.UserController.ReadClient(selectedRow.Cells["Login"].Value.ToString());
                _dataBase.UserController.DeleteClient(editClient);
                // Обновить данные в dataGridView1
                RefreshDataGridView();
            }
        }

        private void toolStripEditButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                User editClient = _dataBase.UserController.ReadClient(selectedRow.Cells["Login"].Value.ToString());
                EditClientForm editForm = new EditClientForm(editClient, _dataBase);
                editForm.ShowDialog();
                RefreshDataGridView();
            }
        }

        private void buttonEditRole_Click(object sender, EventArgs e)
        {
            if (comboBoxEditRole.SelectedItem != null && textBoxNewRole.Text != "")
            {
                string lastrole = comboBoxEditRole.SelectedItem.ToString();
                string newrole = textBoxNewRole.Text;
                _dataBase.RoleController.Update(lastrole, newrole);
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
                _dataBase.RoleController.Delete(role);
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
                    _dataBase.RoleController.Create(newRole);
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            // Проверяем, есть ли выбранная строка в dataGridView1
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем выбранного клиента из выбранной строки
                User selectedClient = _dataBase.UserController.ReadClient(selectedRow.Cells["Login"].Value.ToString());

                // Вызываем методы RefreshRolesToAddView и RefreshRolesToRemoveView
                RefreshRolesToAddView(selectedClient);
                RefreshRolesToRemoveView(selectedClient);
            }
        }

        private void RefreshRolesToAddView(User client)
        {
            checkedListBoxDeletedRoles.Items.Clear();
            List<string> roles = _dataBase.RoleController.GetUserRoles(client);
            foreach (string role in roles)
            {
                checkedListBoxDeletedRoles.Items.Add(role);
            }
        }
        
        private void RefreshRolesToRemoveView(User client)
        {
            checkedListBoxAddingRoles.Items.Clear();
            List<string> roles = _dataBase.RoleController.GetMissingRoles(client);
            foreach (string role in roles)
            {
                checkedListBoxAddingRoles.Items.Add(role);
            }
        }

        private void buttonDeleteUserRole_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            User client_deleterole = _dataBase.UserController.ReadClient(selectedRow.Cells["Login"].Value.ToString());
            //List<string> selectedItems = new List<string>();
            foreach (var item in checkedListBoxDeletedRoles.CheckedItems)
            {
                string selectedItem = item.ToString();
                //selectedItems.Add(selectedItem);
                _dataBase.RoleController.RemoveRoleFromClient(selectedItem, client_deleterole);
            }
            RefreshRolesToRemoveView(client_deleterole);
            RefreshRolesToAddView(client_deleterole);
        }

        private void buttonAddUserRole_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            User client_addrole = _dataBase.UserController.ReadClient(selectedRow.Cells["Login"].Value.ToString());
            foreach (var item in checkedListBoxAddingRoles.CheckedItems)
            {
                string selectedItem = item.ToString();
                //selectedItems.Add(selectedItem);
                _dataBase.RoleController.AddRoleToClient(selectedItem, client_addrole);
            }
            RefreshRolesToRemoveView(client_addrole);
            RefreshRolesToAddView(client_addrole);
        }

        private void SetButtonAccessibility(bool isAdmin)
        {
            buttonDeleteRole.Enabled = isAdmin;
            buttonEditRole.Enabled = isAdmin;
            buttonCreateRole.Enabled = isAdmin;
            buttonDeleteUserRole.Enabled = isAdmin;
            buttonCreateRole.Enabled = isAdmin;
            bindingNavigatorDeleteItem.Enabled = isAdmin;
            buttonAddUserRole.Enabled = isAdmin;
        }
    }
}
