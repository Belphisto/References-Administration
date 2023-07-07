using Npgsql;
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
    public partial class DepartmentForm : Form
    {
        private DataBaseController dataBase;
        private List<Department> departments;
        private List<Holl> holls;

        public DepartmentForm()
        {
            InitializeComponent();
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            // Подключение к базе данных
            dataBase = new DataBaseController();

            // Получить данные из базы данных
            departments = DepartmentController.GetDepartments(dataBase.Connection);
            // Заполнить TreeView
            FillTreeView(departments);
            FillHolls();

        }

        private void FillTreeView(List<Department> departments)
        {
            // Очистить TreeView
            treeView.Nodes.Clear();

            // Создать узлы дерева из списка подразделений
            var treeNodes = CreateTreeNodes(departments);

            // Добавить корневые узлы в TreeView
            foreach (var node in treeNodes)
            {
                treeView.Nodes.Add(node);
            }
        }
        private void FillHolls()
        {
            comboBoxHolls.Items.Clear();
            holls = HollController.GetHolls(dataBase.Connection);
            comboBoxHolls.Items.AddRange(holls.ToArray());
        }

        private List<TreeNode> CreateTreeNodes(List<Department> departments, int? parentID = null)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            foreach (var department in departments.Where(d => d.ParentID == parentID))
            {
                TreeNode node = new TreeNode(department.Name);
                node.Tag = department;

                // Рекурсивно создать дочерние узлы для текущего узла
                var childNodes = CreateTreeNodes(departments, department.ID);
                node.Nodes.AddRange(childNodes.ToArray());

                nodes.Add(node);
            }

            return nodes;
        }

        private void UpdateTreeView()
        {
            // Очистить TreeView
            treeView.Nodes.Clear();

            // Получить данные из базы данных
            //var departments = dataBase.GetDepartments();
            departments = DepartmentController.GetDepartments(dataBase.Connection);

            // Заполнить TreeView
            FillTreeView(departments);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Закрыть подключение к базе данных при закрытии формы
            Log.WriteLog("Закрыть подключение к базе данных при закрытии формы;");
            dataBase.CloseConnection();
            base.OnFormClosing(e);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            // Получить выбранный узел в дереве TreeView
            TreeNode selectedNode = treeView.SelectedNode;

            // Проверить, что узел выбран
            if (selectedNode != null)
            {
                Log.WriteLog("Элемент выбран");
                // Получить объект Department из Tag выбранного узла
                Department selectedDepartment = selectedNode.Tag as Department;

                // Проверить, что объект Department не равен null
                //if (selectedDepartment != null && selectedDepartment.ID != 1)
                if (selectedDepartment != null)
                {
                    // Открыть новую форму для редактирования выбранного объекта Department
                    EditDepartmentForm editForm = new EditDepartmentForm(selectedDepartment, dataBase);
                    Log.WriteLog("selectedDepartment != null;");
                    editForm.ShowDialog();

                    // Обновить данные в дереве TreeView после редактирования
                    UpdateTreeView();
                }

                Log.WriteLog("selectedDepartment = null;");
            }
            Log.WriteLog("Элемент не выбран");
        }


        private void AddDepartmentButton_Click(object sender, EventArgs e)
        {
            EditDepartmentForm editForm = new EditDepartmentForm(dataBase);
            Log.WriteLog("Открыта форма для добавления подразделения;");
            editForm.ShowDialog();
            // Обновить данные в дереве TreeView после редактирования
            UpdateTreeView();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Получить выбранный узел в дереве TreeView
            TreeNode selectedNode = treeView.SelectedNode;

            // Проверить, что узел выбран
            if (selectedNode != null)
            {
                Log.WriteLog("Элемент выбран");
                // Получить объект Department из Tag выбранного узла
                Department selectedDepartment = selectedNode.Tag as Department;

                // Проверить, что объект Department не равен null
                //if (selectedDepartment != null && selectedDepartment.ID != 1)
                if (selectedDepartment != null && selectedDepartment.ID != 1)
                {
                    try
                    {
                        DepartmentController.Delete(dataBase.Connection, selectedDepartment);
                        // Обновить данные в дереве TreeView после редактирования
                        UpdateTreeView();
                        Log.WriteLog("selectedDepartment = null;");
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show("Невозможно удалить подразделение, так как существуют связанные пользователи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Log.WriteLog("Элемент не выбран");
        }

        private void buttonCreateHoll_Click(object sender, EventArgs e)
        {
            CreateHollForm editForm = new CreateHollForm(dataBase);
            editForm.ShowDialog();
            FillHolls();
        }

        private void buttonShowDepartmentInHoll_Click(object sender, EventArgs e)
        {
            Holl selected = comboBoxHolls.SelectedItem as Holl;
            if (selected != null)
            {
                List<Department> departments = HollController.GetDepartments(dataBase.Connection, selected);

                StringBuilder message = new StringBuilder();
                message.AppendLine("Подразделения:");
                foreach (Department department in departments)
                {
                    message.AppendLine(department.Name);
                }
                MessageBox.Show(message.ToString(), "Подразделения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите совещательный зал из списка. Если список пуст - сначала создайте совещательный зал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteHoll_Click(object sender, EventArgs e)
        {
            Holl selected = comboBoxHolls.SelectedItem as Holl;
            if (selected != null)
            {

                HollController.Delete(dataBase.Connection, selected);
                MessageBox.Show("Совещательный зал был удален вместе с оборудованием, относящимся к нему, а также мероприятиями", "Удалено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillHolls();
            }
            else
            {
                MessageBox.Show("Выберите совещательный зал из списка. Если список пуст - сначала создайте совещательный зал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditHoll_Click(object sender, EventArgs e)
        {
            Holl selected = comboBoxHolls.SelectedItem as Holl;
            if (selected != null)
            {

                EditHollForm editForm = new EditHollForm(dataBase, selected) ;
                Log.WriteLog("Открыта форма для добавления подразделения;");
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите совещательный зал из списка. Если список пуст - сначала создайте совещательный зал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


    }
}
