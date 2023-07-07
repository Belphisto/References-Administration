using System;
using Npgsql;
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
    public partial class EditHollForm : Form
    {
        private DataBaseController _dataBase;
        private Holl _holl;
        public EditHollForm(DataBaseController dataBase, Holl holl)
        {
            InitializeComponent();
            _dataBase = dataBase;
            _holl = holl;
        }

        private void EditHollForm_Load(object sender, EventArgs e)
        {
            textBoxName.Text = _holl.Name;
            
            ShowEquipment();
            ShowDepartment();
        }

        private void ShowEquipment()
        {
            List<Equipment> equipment = EquipmentController.GetEquipments(_dataBase.Connection, _holl);

            checkedListBoxDeleteEquipment.DataSource = null; // Удаление связи с DataSource
            checkedListBoxDeleteEquipment.Items.Clear(); // Очистка коллекции элементов

            foreach (Equipment item in equipment)
            {
                checkedListBoxDeleteEquipment.Items.Add(item); // Добавление элементов в коллекцию
            }

            checkedListBoxDeleteEquipment.DisplayMember = "Name"; // Установка отображаемого свойства
        }


        private void ShowDepartment()
        {
            List<Department> allDepartments = DepartmentController.GetDepartments(_dataBase.Connection); // список всех подразделений
            List<Department> relatedDepartments = HollController.GetDepartments(_dataBase.Connection, _holl); // список подразделений, относящихся к залу
            List<Department> unrelatedDepartments = allDepartments.Except(relatedDepartments).ToList();

            checkedListBoxDepartments.Items.Clear();
            checkedListBoxAddDepartments.Items.Clear();

            foreach (Department department in unrelatedDepartments)
            {
                checkedListBoxAddDepartments.Items.Add(department);
            }

            foreach (Department department in relatedDepartments)
            {
                checkedListBoxDepartments.Items.Add(department);
            }

            checkedListBoxAddDepartments.DisplayMember = "Name";
            checkedListBoxDepartments.DisplayMember = "Name";

        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                _holl.Name = textBoxName.Text;
                HollController.Update(_dataBase.Connection, _holl);
            }
            else
            {
                MessageBox.Show("Название совещательного зала не может быть пустым!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteDepartments_Click(object sender, EventArgs e)
        {
            List<object> checkedItems = checkedListBoxDepartments.CheckedItems.OfType<object>().ToList();

            foreach (var item in checkedItems)
            {
                Department department = item as Department;
                if (department != null)
                {
                    if (checkedListBoxDepartments.Items.Count > 1)
                    {
                        HollController.RemoveDepartment(_dataBase.Connection, department.ID, _holl.ID);
                    }
                    else
                    {
                        MessageBox.Show("Хотя бы одно подразделение должно относиться к совещательному залу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            ShowDepartment();

        }

        private void buttonAddDepartments_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxAddDepartments.CheckedItems)
            {
                Department department = item as Department;
                if (department != null)
                {
                    HollController.AddDepatrment(_dataBase.Connection, department.ID, _holl.ID);
                }
            }
            ShowDepartment();
        }

        private void buttonAddEquipments_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxAddEquipments.CheckedItems)
            {
                EquipmentController.AddEquipment(_dataBase.Connection, item.ToString(), _holl.ID);
            }
            checkedListBoxAddEquipments.ClearSelected();
            ShowEquipment();
        }

        private void buttonDeleteEquipment_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxDeleteEquipment.CheckedItems)
            {
                Equipment equipment = item as Equipment;
                if (equipment != null)
                {
                    EquipmentController.DeleteEquipment(_dataBase.Connection, equipment);
                }
            }
            ShowEquipment();
        }

        private void textBoxEquipment_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string inputText = textBoxEquipment.Text;

                // Проверка на пустую строку
                if (!string.IsNullOrEmpty(inputText))
                {
                    checkedListBoxAddEquipments.Items.Add(inputText);
                }

                textBoxEquipment.Text = string.Empty; // Очистка текстового поля
            }
        }
    }
}
