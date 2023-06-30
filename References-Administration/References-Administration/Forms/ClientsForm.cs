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
        private static int totalClients;
        private DataBaseController dataBase;
        private List<Client> clients;
        private List<Department> departments;

        public ClientsForm()
        {
            InitializeComponent();
            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Логин", HeaderText = "Логин" });
            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ФИО", HeaderText = "ФИО" });
            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Подразделение", HeaderText = "Подразделение" });
            dataGridView1.ReadOnly = true;
            bindingNavigator1.AddNewItem.Enabled = true;
            bindingNavigator1.DeleteItem.Enabled = true;
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

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            int offset = (int)bindingSource1.Current;
            //var records = new List<Record>();
            // for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //records.Add(new Record { Index = i });
            dataGridView1.DataSource = clients;
        }

        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalClients" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalClients; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
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
                Client editClient = Client.Read(dataBase.Connection, selectedRow.Cells["Login"].Value.ToString());
                editClient.Delete(dataBase.Connection);
                // Обновить данные в dataGridView1
                RefreshDataGridView();
            }
        }

        private void toolStripEditButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                Client editClient = Client.Read(dataBase.Connection, selectedRow.Cells["Login"].Value.ToString());
                EditClientForm editForm = new EditClientForm(editClient, dataBase);
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
    }
}
