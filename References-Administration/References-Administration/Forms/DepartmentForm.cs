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
        private DataBase _dataBase;
        private Session _session;
        private List<Division> departments;
        private List<Holl> holls;

        public DepartmentForm( DataBase dataBase, Session session)
        {
            _dataBase = dataBase;
            _session = session;
            InitializeComponent();
            if (_session.Roles != null)
            {
                InitializeForm(session.Roles.Contains("Администратор"));
            }
            else { InitializeForm(false); }
            
        }
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            // Получить данные из базы данных
            departments = _dataBase.DivisionController.GetDepartments();
            // Заполнить TreeView
            FillTreeView(departments);
            FillHolls();

        }

        private void FillTreeView(List<Division> departments)
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
            holls = _dataBase.HollController.GetHolls();
            comboBoxHolls.Items.AddRange(holls.ToArray());
        }

        private List<TreeNode> CreateTreeNodes(List<Division> departments, int? parentID = null)
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
            departments = _dataBase.DivisionController.GetDepartments();

            // Заполнить TreeView
            FillTreeView(departments);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
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
                Division selectedDepartment = selectedNode.Tag as Division;

                // Проверить, что объект Department не равен null
                //if (selectedDepartment != null && selectedDepartment.ID != 1)
                if (selectedDepartment != null)
                {
                    // Открыть новую форму для редактирования выбранного объекта Department
                    EditDepartmentForm editForm = new EditDepartmentForm(selectedDepartment, _dataBase);
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
            EditDepartmentForm editForm = new EditDepartmentForm(_dataBase);
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
                Division selectedDepartment = selectedNode.Tag as Division;

                // Проверить, что объект Department не равен null
                //if (selectedDepartment != null && selectedDepartment.ID != 1)
                if (selectedDepartment != null && selectedDepartment.ID != 1)
                {
                    try
                    {
                        _dataBase.DivisionController.Delete(selectedDepartment);
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
            CreateHollForm editForm = new CreateHollForm(_dataBase);
            editForm.ShowDialog();
            FillHolls();
        }

        private void buttonShowDepartmentInHoll_Click(object sender, EventArgs e)
        {
            Holl selected = comboBoxHolls.SelectedItem as Holl;
            if (selected != null)
            {
                List<Division> departments = _dataBase.HollController.GetDepartments(selected);

                StringBuilder message = new StringBuilder();
                message.AppendLine("Подразделения:");
                foreach (Division department in departments)
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
                _dataBase.HollController.Delete(selected);
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

                EditHollForm editForm = new EditHollForm(_dataBase, selected) ;
                Log.WriteLog("Открыта форма для добавления подразделения;");
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите совещательный зал из списка. Если список пуст - сначала создайте совещательный зал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void InitializeForm(bool isEditMode)
        {
            EditButton.Enabled = isEditMode;
            AddDepartmentButton.Enabled = isEditMode;
            DeleteButton.Enabled = isEditMode;
            buttonCreateHoll.Enabled = isEditMode;
            buttonDeleteHoll.Enabled = isEditMode;
            buttonEditHoll.Enabled = isEditMode;
        }
    }
}
