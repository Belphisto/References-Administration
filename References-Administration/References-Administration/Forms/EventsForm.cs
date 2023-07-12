using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace References_Administration
{
    public partial class EventsForm : Form
    {
        private List<Holl> holls;
        private DataBaseController dataBase;
        private List<Event> events;
        private Session _session;
        private EmailSenderForm emailSenderForm;



        public EventsForm(Session session)
        {
            InitializeComponent();
            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.CustomFormat = "dd.MMMM.yyyy HH:mm:ss";
            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndTime.CustomFormat = "dd.MMMM.yyyy HH:mm:ss";
            panelCreateEvent.Visible = false;
            // Запретить редактирование таблицы
            dataGridView1.ReadOnly = true;

            // Запретить добавление новых строк
            dataGridView1.AllowUserToAddRows = false;

            _session = session;
            // Подключение к базе данных
            dataBase = new DataBaseController();
            holls = HollController.GetHolls(dataBase.Connection);
            events = EventController.GetEvents(dataBase.Connection);
            RefreshEvents();

            dataGridView1.Columns.Add("NoteColumn", "Note");
            dataGridView1.Columns.Add("CommentColumn", "Comment");
            dataGridView1.Columns.Add("MeetingRoomIDColumn", "Meeting Room");
            dataGridView1.Columns.Add("StartDateColumn", "Start Date");
            dataGridView1.Columns.Add("EndDateColumn", "End Date");
            dataGridView1.Columns.Add("StatusColumn", "Status");
            dataGridView1.Columns.Add("UserColumn", "User");

            
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
            checkedListBoxEquipments.Items.Clear();
            List <Equipment> equipments = EquipmentController.GetEquipments(dataBase.Connection, holl);
            foreach(var eq in equipments)
            {
                checkedListBoxEquipments.Items.Add(eq);
            }
            checkedListBoxEquipments.DisplayMember = "Name";
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
            Event selectedEvent = comboBoxEventInDay.SelectedItem as Event;
            selectedEvent.Status = Status.Canceled;
            if (textBoxComment.Text != "")
            {
                selectedEvent.Comment = textBoxComment.Text;
                EventController.Update(dataBase.Connection, selectedEvent);

                Holl selectedHoll = HollController.Read(dataBase.Connection, selectedEvent.HollID);
                List<Equipment> eqs = EventEquipment.GetEquipmentInEvent(dataBase.Connection, selectedEvent);
                List<int> idsTech = RoleController.GetClientIds(dataBase.Connection, "Техник");
                List<string> emailsTech = new List<string>();
                foreach (var id in idsTech) emailsTech.Add(ClientController.GetEmail(dataBase.Connection, id));

                if (_session.Roles.Contains("Техник"))
                {
                    string email = ClientController.GetEmail(dataBase.Connection, selectedEvent.UserLogin);
                    string subjectEmail = _session.User.Login;
                    subjectEmail += $" { _session.GetRoles()}";
                    subjectEmail += $": мероприятие {selectedEvent.Note} отменено";
                    string bodyEmail = selectedEvent.ToString(selectedHoll, eqs);
                    emailSenderForm.SendEmail(email, subjectEmail, bodyEmail);
                    foreach (var mailTech in emailsTech) 
                    {
                        subjectEmail += "Копия письма";
                        emailSenderForm.SendEmail(mailTech, subjectEmail, bodyEmail); 
                    }
                    MessageBox.Show("Отмена мероприятия прошла успешно. Владельцу отправлено уведомление\n ", "Мероприятие отменено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Отмена мероприятия прошла успешно\n ", "Мероприятие отменено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Введите комментарий отмены мероприятия\n ", "Не удается отменить мероприятия", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCunfirmEvent_Click(object sender, EventArgs e)
        {
            Event selectedEvent = comboBoxEventInDay.SelectedItem as Event;
            selectedEvent.Status = Status.Confirmed;
            if (textBoxComment.Text != "")
            {
                selectedEvent.Comment = textBoxComment.Text;
                EventController.Update(dataBase.Connection, selectedEvent);

                Holl selectedHoll = HollController.Read(dataBase.Connection, selectedEvent.HollID);
                List<Equipment> eqs = EventEquipment.GetEquipmentInEvent(dataBase.Connection, selectedEvent);

                if (_session.Roles.Contains("Техник"))
                {
                    string email = ClientController.GetEmail(dataBase.Connection, selectedEvent.UserLogin);
                    string subjectEmail = _session.User.Login;
                    subjectEmail += $" { _session.GetRoles()}";
                    subjectEmail += $": мероприятие {selectedEvent.Note} подтверждено";
                    string bodyEmail = selectedEvent.ToString(selectedHoll, eqs);
                    emailSenderForm.SendEmail(email, subjectEmail, bodyEmail);
                    MessageBox.Show("Подтверждение мероприятия прошло успешно. Владельцу отправлено уведомление\n ", "Мероприятие подтверждено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Подтверждение мероприятия прошло успешно\n ", "Мероприятие подтверждено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Введите комментарий подтверждения\n ", "Не удается подтвердить мероприятия", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panelCreateEvent.Visible = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool isEq = false;
            if (textBoxNote.Text != "" && comboBox1.SelectedItem != null && dateTimePickerStartTime.Value < dateTimePickerEndTime.Value)
            {
                Event newEvent = new Event();
                Holl selectedHoll = comboBox1.SelectedItem as Holl;
                newEvent.Note = textBoxNote.Text;
                newEvent.HollID = selectedHoll.ID;
                newEvent.StartTime = dateTimePickerStartTime.Value;
                newEvent.EndTime = dateTimePickerEndTime.Value;
                newEvent.UserLogin = _session.User.Login;
                
                if(checkedListBoxEquipments.CheckedItems.Count != 0) newEvent.Status = Status.Scheduled;
                else newEvent.Status = Status.Confirmed;
                if (EventController.IsEventTimeAvailable(newEvent, EventController.GetEvents(dataBase.Connection, selectedHoll)))
                {
                    EventController.Create(dataBase.Connection, newEvent);
                    newEvent.ID = EventController.GetLastCreatedID(dataBase.Connection);

                    List<Equipment> eqs = new List<Equipment>();
                    foreach(Equipment eq in checkedListBoxEquipments.CheckedItems)
                    {
                        EventEquipment.AddEquipment(dataBase.Connection, newEvent, eq);
                        isEq = true;
                        eqs.Add(eq);
                    }
                    
                    if (isEq)
                    {
                        List<int> idsTech = RoleController.GetClientIds(dataBase.Connection, "Техник");
                        List<string> emailsTech = new List<string>();
                        foreach (var id in idsTech)
                        {
                            emailsTech.Add(ClientController.GetEmail(dataBase.Connection, id));
                        }
                        string subjectEmail = _session.User.Login;
                        subjectEmail += $" { _session.GetRoles()}";
                        subjectEmail += $": мероприятие {newEvent.Note} запланировано";
                        string bodyEmail = newEvent.ToString(selectedHoll, eqs);
                        foreach (var mailTech in emailsTech)
                        {
                            subjectEmail += "Копия письма";
                            emailSenderForm.SendEmail(mailTech, subjectEmail, bodyEmail);
                            MessageBox.Show($"{mailTech}\n ", "Отправлено технику", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        MessageBox.Show("После того, как техник проверит оборудование, вам придет ответ по электронной почте !\n ", "Статус мероприятия: запланировано", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    textBoxNote.Text = "";
                    comboBox1.SelectedItem = null;
                    checkedListBoxEquipments.Items.Clear();
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
            comboBoxEventInDay.Items.Clear();
            comboBoxEventInDay.DisplayMember = "Note";
            foreach (Event ev in events)
            {
                if (ev.StartTime.Date == selectedDate.Date)
                {
                    // Ваш код для заполнения dataGridView1 и comboBoxEventInDay
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);

                    row.Cells[0].Value = ev.Note;
                    row.Cells[1].Value = ev.Comment;
                    Holl current = HollController.Read(dataBase.Connection, ev.HollID);
                    row.Cells[2].Value = current.Name;
                    row.Cells[3].Value = ev.StartTime;
                    row.Cells[4].Value = ev.EndTime;
                    row.Cells[5].Value = ev.Status.ToString();
                    row.Cells[6].Value = ev.UserLogin.ToString();

                    dataGridView1.Rows.Add(row);
                    comboBoxEventInDay.Items.Add(ev);
                    
                }
                
            }

        }

        private void comboBoxEventInDay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Event selectedEvent = comboBoxEventInDay.SelectedItem as Event;
            Holl holl = HollController.Read(dataBase.Connection, selectedEvent.HollID);
            labelEventInfo.Text = selectedEvent.ToString(holl, EventEquipment.GetEquipmentInEvent(dataBase.Connection, selectedEvent));
            if (selectedEvent.Status == Status.Confirmed) { buttonCunfirmEvent.Visible = false; }
            else if (selectedEvent.Status == Status.Canceled) { buttonCancelEvent.Visible = false; }
            else { buttonCunfirmEvent.Visible = true; buttonCancelEvent.Visible = true; }
        }

        private void buttonSM_Click(object sender, EventArgs e)
        {
            try
            {
                // Создание объекта SmtpClient с настройками для сервера Yandex
                SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru", 587);
                smtpClient.EnableSsl = true; // Включение SSL для шифрования соединения

                // Аутентификация на сервере Yandex с помощью учетных данных отправителя
                smtpClient.Credentials = new NetworkCredential("aniln0va@yandex.ru", "tuuhnmmsgqvqqven");

                // Создание объекта MailMessage с информацией о письме
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("aniln0va@yandex.ru");
                mailMessage.To.Add("lina.invers.02@mail.ru");
                mailMessage.Subject = "Тестовое письмо";
                mailMessage.Body = "Привет, это тестовое письмо из моего приложения WinForms.";

                // Отправка письма
                smtpClient.Send(mailMessage);

                // Освобождение ресурсов
                mailMessage.Dispose();
                smtpClient.Dispose();

                MessageBox.Show("Письмо успешно отправлено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отправки письма: " + ex.Message);
            }
        }

        private void EventsForm_Load(object sender, EventArgs e)
        {
            IEmailSender emailSender = new EmailSender("aniln0va@yandex.ru", "tuuhnmmsgqvqqven");
            emailSenderForm = new EmailSenderForm(emailSender);
        }
    }
}
