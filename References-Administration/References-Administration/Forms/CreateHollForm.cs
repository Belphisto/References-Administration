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
    public partial class CreateHollForm : Form
    {
        private DataBase _dataBase;
        private List<Division> _departments;

        public CreateHollForm(DataBase dataBase)
        {
            InitializeComponent();
            // Подключение к базе данных
            _dataBase = dataBase;
            // Получить данные из базы данных
            _departments = _dataBase.DivisionController.GetDepartments();
        }

        private void CreateHollForm_Load(object sender, EventArgs e)
        {
            // Установка источника данных для checkedListBoxDepartments
            checkedListBoxDepartments.DataSource = _departments;
            checkedListBoxDepartments.DisplayMember = "Name";

            // Разрешение выбора нескольких элементов в checkedListBoxDepartments
            //checkedListBoxDepartments.SelectionMode = SelectionMode.MultiSimple;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && checkedListBoxDepartments.CheckedItems.Count != 0)
            {
                Holl newHoll = new Holl();
                newHoll.Name = textBoxName.Text;
                _dataBase.HollController.Create(newHoll);
                newHoll = _dataBase.HollController.Read(textBoxName.Text);

                foreach (var item in checkedListBoxDepartments.CheckedItems)
                {
                    Division department = item as Division;
                    if (department != null)
                    {
                        _dataBase.DivisionController.AddDepatrment(department, newHoll);
                    }
                }

                foreach (var item in checkedListBoxEquipments.CheckedItems)
                {
                    _dataBase.EquipmentController.AddEquipment(item.ToString(), newHoll.ID);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Название совещательного зала и относящиеся к нему подразделения не могут быть пустыми!\n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxEquipment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string inputText = textBoxEquipment.Text;

                // Проверка на пустую строку
                if (!string.IsNullOrEmpty(inputText))
                {
                    checkedListBoxEquipments.Items.Add(inputText);
                }

                textBoxEquipment.Text = string.Empty; // Очистка текстового поля
            }
        }
    }
}
