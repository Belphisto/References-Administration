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
    public partial class EditDepartmentForm : Form
    {
        private Department _department;
        private DataBaseController _dataBase;
        public EditDepartmentForm(Department department, DataBaseController dataBase)
        {
            Log.WriteLog($"Форма для редактирования открыта");
            InitializeComponent();
            _department = department;
            _dataBase = dataBase;
        }

        private void EditDepartmentForm_Load(object sender, EventArgs e)
        {
            // Загрузить данные всех подразделений
            List<Department> departments = _dataBase.GetDepartments();
            Log.WriteLog($"EditDepartmentForm_Load: количество отделений для выбора родительского элемента = {departments.Count}");

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
            _department.Name = NameTextBox.Text;

            // Получить выбранное название подразделения
            string selectedDepartmentName = DepartmentsNameListBox.SelectedItem.ToString();

            Department selectedParent = Department.Read(_dataBase.Connection, selectedDepartmentName);
            _department.ParentID = selectedParent.ID;
            _department.Update(_dataBase.Connection);
            this.Close();
        }


    }
}
