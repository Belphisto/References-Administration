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
        private Division _department;
        private DataBase _dataBase;

        //конструктор для формы редактирования объекта
        public EditDepartmentForm(Division department, DataBase dataBase)
        {
            Log.WriteLog($" EditDepartmentForm : Form/EditDepartmentForm(Department department, DataBaseController dataBase)/ Форма для редактирования открыта");
            InitializeComponent();
            _department = department;
            _dataBase = dataBase;
            CreateButton.Visible = false; //скрыть кнопку для создания объекта
            NameTextBox.Text = _department.Name;
            this.Load += EditDepartmentForm_Load;
        }

        // конструктор для формы создания объекта
        public EditDepartmentForm(DataBase dataBase)
        {
            Log.WriteLog($"EditDepartmentForm : Form/ EditDepartmentForm(DataBaseController dataBase)/ Форма для создания открыта");
            InitializeComponent();
            _department = new Division(); 
            _dataBase = dataBase;
            SaveButton.Visible = false; //скрыть кнопку для сохранения редактированного объекта
            this.Load += EditDepartmentForm_Load;
        }

        private void EditDepartmentForm_Load(object sender, EventArgs e)
        {
            // Загрузить данные всех подразделений
            List<Division> departments =  _dataBase.DivisionController.GetDepartments();
            
            // Заполнить ListBox названиями подразделений
            foreach (Division department in departments)
            {
                if (department.Name == _department.Name ) continue; //недопустить родительскую ссылку на самого себя
                else
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
            if (NameTextBox.Text != "")
            {
                _department.Name = NameTextBox.Text;

                // Проверить, что выбран элемент в DepartmentsNameListBox
                if (DepartmentsNameListBox.SelectedItem != null)
                {
                    // Получить выбранное название подразделения
                    string selectedDepartmentName = DepartmentsNameListBox.SelectedItem.ToString();

                    Division selectedParent =  _dataBase.DivisionController.Read(selectedDepartmentName);
                    _department.ParentID = selectedParent.ID;
                }
                _dataBase.DivisionController.Update(_department);
                this.Close();
            }
            else
            {
                MessageBox.Show("Название подразделения не может быть пустым!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if ( NameTextBox.Text != "")
            {
                if (DepartmentsNameListBox.SelectedItem != null)
                {
                    string selectedDepartmentName = DepartmentsNameListBox.SelectedItem.ToString();
                    Division selectedParent =  _dataBase.DivisionController.Read(selectedDepartmentName);
                    _department.ParentID = selectedParent.ID;
                }
                _department.Name = NameTextBox.Text;

                _dataBase.DivisionController.Create(_department);
                Log.WriteLog($"EditDepartmentForm : Form/CreateButton_Click(object sender, EventArgs e)/ Создание объекта {_department} произошло успешно");
                this.Close();
            } 
            else
            {
                Log.WriteLog($"EditDepartmentForm : Form/CreateButton_Click(object sender, EventArgs e)/ Создание объекта не удалось");
                MessageBox.Show("Название подразделения не заполнено!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


    }
}
