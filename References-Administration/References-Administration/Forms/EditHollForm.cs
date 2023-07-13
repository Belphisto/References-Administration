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
        private DataBase _dataBase;
        private Holl _holl;
        public EditHollForm(DataBase dataBase, Holl holl)
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
            List<Equipment> equipment = _dataBase.EquipmentController.GetEquipments(_holl);

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
            List<Division> allDepartments = _dataBase.DivisionController.GetDepartments(); // список всех подразделений
            List<Division> relatedDepartments = _dataBase.HollController.GetDepartments(_holl); // список подразделений, относящихся к залу
            List<Division> unrelatedDepartments = allDepartments.Except(relatedDepartments).ToList();

            checkedListBoxDepartments.Items.Clear();
            checkedListBoxAddDepartments.Items.Clear();

            foreach (Division department in unrelatedDepartments)
            {
                checkedListBoxAddDepartments.Items.Add(department);
            }

            foreach (Division department in relatedDepartments)
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
                _dataBase.HollController.Update(_holl);
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
                Division department = item as Division;
                if (department != null)
                {
                    if (checkedListBoxDepartments.Items.Count > 1)
                    {
                        _dataBase.DivisionController.RemoveDepartment(department, _holl);
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
                Division department = item as Division;
                if (department != null)
                {
                    _dataBase.DivisionController.AddDepatrment( department, _holl);
                }
            }
            ShowDepartment();
        }

        private void buttonAddEquipments_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxAddEquipments.CheckedItems)
            {
                _dataBase.EquipmentController.AddEquipment(item.ToString(), _holl.ID);
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
                    _dataBase.EquipmentController.DeleteEquipment(equipment);
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
