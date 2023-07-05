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
        private const int pageSize = 20;
        private int currentPage = 1;
        private int totalClients;
        private DataBaseController dataBase;
        private List<Client> clients;
        private List<Department> departments;
        //private List<string> roles;

        public ClientsForm()
        {
            InitializeComponent();
            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Логин", HeaderText = "Логин" });
            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ФИО", HeaderText = "ФИО" });
            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Подразделение", HeaderText = "Подразделение" });
            dataGridView1.ReadOnly = true;
            bindingNavigator1.AddNewItem.Enabled = true;
            bindingNavigator1.DeleteItem.Enabled = true;
            //bindingNavigatorMoveNextItem.Enabled = true;
            //bindingNavigatorMovePreviousItem.Enabled = true;
            //bindingNavigatorPositionItem.Enabled = true;
            //bindingNavigatorCountItem.Enabled = true;

            //bindingNavigator1.BindingSource = bindingSource1;
            //bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            //bindingSource1.DataSource = new PageOffsetList();

            //this.Load += ClientsForm_Load;
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            // Подключение к базе данных
            dataBase = new DataBaseController();

            // Получить данные из базы данных
            clients = ClientController.GetClients(dataBase.Connection);
            totalClients = clients.Count;
            departments = DepartmentController.GetDepartments(dataBase.Connection);
            //ShowCurrentPage();
            // Заполнить таблицу данными клиентов
            // Преобразовать список клиентов только с нужными полями в анонимный тип
            var clientsData = clients.Select(c => new
            {
                Login = c.Login,
                FullName = c.FullName,
                Department = c.GetDepartmentName(dataBase.Connection, c.DepartmentID)
            }).ToList();

            // Заполнить таблицу данными клиентов
            dataGridView1.DataSource = clientsData;

            // Загрузить все роли
            RefreshRolesView();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Закрыть подключение к базе данных при закрытии формы
            Log.WriteLog("Закрыть подключение к базе данных при закрытии формы;");
            dataBase.CloseConnection();
            base.OnFormClosing(e);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            EditClientForm editForm = new EditClientForm(dataBase);
            Log.WriteLog("Открыта форма для добавления пользователя;");
            editForm.ShowDialog();
            RefreshDataGridView();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                Client editClient = ClientController.Read(dataBase.Connection, selectedRow.Cells["Login"].Value.ToString());
                ClientController.Delete(dataBase.Connection, editClient); 
                // Обновить данные в dataGridView1
                RefreshDataGridView();
            }
        }

        private void toolStripEditButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                Client editClient = ClientController.Read(dataBase.Connection, selectedRow.Cells["Login"].Value.ToString());
                EditClientForm editForm = new EditClientForm(editClient, dataBase);
                editForm.ShowDialog();
                RefreshDataGridView();
            }
        }

        private void RefreshDataGridView()
        {
            clients = ClientController.GetClients(dataBase.Connection);
            totalClients = clients.Count;
            departments = DepartmentController.GetDepartments(dataBase.Connection);
            // Очистить dataGridView1
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Заполнить таблицу данными клиентов
            // Преобразовать список клиентов только с нужными полями в анонимный тип
            var clientsData = clients.Select(c => new
            {
                Login = c.Login,
                FullName = c.FullName,
                Department = c.GetDepartmentName(dataBase.Connection, c.DepartmentID)
            }).ToList();

            // Заполнить таблицу данными клиентов
            dataGridView1.DataSource = clientsData;
        }

        private void ShowCurrentPage()
        {
            // Определить индекс первого и последнего элементов текущей страницы
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize - 1, totalClients - 1);

            // Получить подмножество клиентов для текущей страницы
            var clientsSubset = clients.Skip(startIndex).Take(pageSize).ToList();

            // Преобразовать список клиентов только с нужными полями в анонимный тип
            var clientsData = clientsSubset.Select(c => new
            {
                Login = c.Login,
                FullName = c.FullName,
                Department = c.GetDepartmentName(dataBase.Connection, c.DepartmentID)
            }).ToList();

            // Очистить dataGridView1
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Заполнить таблицу данными клиентов
            dataGridView1.DataSource = clientsData;

            // Обновить надпись с информацией о текущей странице
            bindingNavigatorPositionItem.Text = string.Format(" {0}", currentPage);
            bindingNavigatorCountItem.Text = string.Format("{0}",GetTotalPages());
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            // Перейти к следующей странице, если она существует
            if (currentPage < GetTotalPages())
            {
                currentPage++;
                ShowCurrentPage();
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            // Перейти к предыдущей странице, если она существует
            if (currentPage > 1)
            {
                currentPage--;
                ShowCurrentPage();
            }
        }

        private int GetTotalPages()
        {
            // Рассчитать общее число страниц на основе общего числа элементов и размера страницы
            return (int)Math.Ceiling((double)totalClients / pageSize);
        }

        private void buttonEditRole_Click(object sender, EventArgs e)
        {
            if (comboBoxEditRole.SelectedItem != null && textBoxNewRole.Text != "")
            {
                string lastrole = comboBoxEditRole.SelectedItem.ToString();
                string newrole = textBoxNewRole.Text;
                RoleController.Update(dataBase.Connection, lastrole, newrole);
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
                RoleController.Delete(dataBase.Connection, role);
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
                    RoleController.Create(dataBase.Connection, newRole);
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
            List<string> roles = RoleController.GetRoles(dataBase.Connection);
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
                Client selectedClient = ClientController.Read(dataBase.Connection, selectedRow.Cells["Login"].Value.ToString());

                // Вызываем методы RefreshRolesToAddView и RefreshRolesToRemoveView
                RefreshRolesToAddView(selectedClient);
                RefreshRolesToRemoveView(selectedClient);
            }
        }

        private void RefreshRolesToAddView(Client client)
        {
            checkedListBoxDeletedRoles.Items.Clear();
            List<string> roles = RoleController.GetUserRoles(dataBase.Connection, client);
            foreach (string role in roles)
            {
                checkedListBoxDeletedRoles.Items.Add(role);
            }
        }
        private void RefreshRolesToRemoveView(Client client)
        {
            checkedListBoxAddingRoles.Items.Clear();
            List<string> roles = RoleController.GetMissingRoles(dataBase.Connection, client);
            foreach (string role in roles)
            {
                checkedListBoxAddingRoles.Items.Add(role);
            }
        }

        private void buttonDeleteUserRole_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddUserRole_Click(object sender, EventArgs e)
        {

        }
    }
}
