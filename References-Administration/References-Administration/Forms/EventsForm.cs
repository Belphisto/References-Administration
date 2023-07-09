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
    public partial class EventsForm : Form
    {
        private List<Holl> holls;
        private DataBaseController dataBase;
        private List<Event> events;

        public EventsForm()
        {
            InitializeComponent();
            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.CustomFormat = "dd.MMMM.yyyy HH:mm:ss";
            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndTime.CustomFormat = "dd.MMMM.yyyy HH:mm:ss";
            panelCreateEvent.Visible = false;

            // Подключение к базе данных
            dataBase = new DataBaseController();
            holls = HollController.GetHolls(dataBase.Connection);
            events = EventController.GetEvents(dataBase.Connection);
            //RefreshEvents();

            dataGridView1.Columns.Add("NoteColumn", "Note");
            dataGridView1.Columns.Add("CommentColumn", "Comment");
            dataGridView1.Columns.Add("MeetingRoomIDColumn", "Meeting Room");
            dataGridView1.Columns.Add("StartDateColumn", "Start Date");
            dataGridView1.Columns.Add("EndDateColumn", "End Date");
            dataGridView1.Columns.Add("StatusColumn", "Status");
        }

        private void RefreshEvents()
        {
            events = EventController.GetEvents(dataBase.Connection);
            monthCalendar3.RemoveAllBoldedDates();
            foreach (var ev in events)
            {
                DateTime eventDate = ev.StartTime.Date;
                monthCalendar3.AddBoldedDate(eventDate); // Добавление даты в выделенные дни
            }
            monthCalendar3.UpdateBoldedDates();
        }

        private void ViewListHoll()
        {
            comboBox1.Items.Clear();
            foreach (var holl in holls)
            {
                comboBox1.Items.Add(holl);
            }
            comboBox1.DisplayMember = "Name";
        }
        private void ViewListEquipmentInHoll(Holl holl)
        {
            checkedListBox1.Items.Clear();
            List <Equipment> equipments = EquipmentController.GetEquipments(dataBase.Connection, holl);
            foreach(var eq in equipments)
            {
                checkedListBox1.Items.Add(eq);
            }
            checkedListBox1.DisplayMember = "Name";
        }

        private void buttonCreateEvent_Click(object sender, EventArgs e)
        {
            panelCreateEvent.Visible = true;
            ViewListHoll();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Holl selectedHoll)
            {
                ViewListEquipmentInHoll(selectedHoll);
            }
        }

        private void buttonCancelEvent_Click(object sender, EventArgs e)
        {
            //
        }

        private void buttonCunfirmEvent_Click(object sender, EventArgs e)
        {
            //
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panelCreateEvent.Visible = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxNote.Text != "" && comboBox1.SelectedItem != null && dateTimePickerStartTime.Value < dateTimePickerEndTime.Value)
            {
                Event newEvent = new Event();
                Holl selectedHoll = comboBox1.SelectedItem as Holl;
                newEvent.Note = textBoxNote.Text;
                newEvent.HollID = selectedHoll.ID;
                newEvent.StartTime = dateTimePickerStartTime.Value;
                newEvent.EndTime = dateTimePickerEndTime.Value;
                newEvent.Status = Status.Scheduled;
                if (EventController.IsEventTimeAvailable(newEvent, EventController.GetEvents(dataBase.Connection, selectedHoll)))
                {
                    EventController.Create(dataBase.Connection, newEvent);
                    textBoxNote.Text = "";
                    comboBox1.SelectedItem = null;
                    checkedListBox1.Items.Clear();
                    panelCreateEvent.Visible = false;
                    RefreshEvents();
                }
                else MessageBox.Show("В выбранное время в выбранном зале уже проходит другое мероприятие. Выберите другое время!\n ", "Не удается создать мероприятия", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Введите описание мероприятия и выберите совещательный зал для проведения мероприятия, а также убедитесь, что дата начала проведения мероприятия не превосходит дату окончания!\n ", "Не удается создать мероприятия", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar3.SelectionStart.Date;
            List<Event> eventsSelectedDate = EventController.GetEvents(dataBase.Connection, events, selectedDate);
            dataGridView1.Rows.Clear();
            foreach (Event ev in eventsSelectedDate)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                row.Cells[0].Value = ev.Note;
                row.Cells[1].Value = ev.Comment;
                Holl current = HollController.Read(dataBase.Connection, ev.HollID);
                row.Cells[2].Value = current.Name;
                row.Cells[3].Value = ev.StartTime;
                row.Cells[4].Value = ev.EndTime;
                row.Cells[5].Value = ev.Status.ToString();

                dataGridView1.Rows.Add(row);
            }
        }
    }
}
