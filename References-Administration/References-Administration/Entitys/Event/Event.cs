using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class Event
    {
        private int _id;
        private string _note;
        private int _hollID;
        private DateTime _startDate;
        private DateTime _endDate;
        private Status _status;
        private string _comment;
        public string UserLogin { get; set; }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public int HollID
        {
            get { return _hollID; }
            set { _hollID = value; }
        }

        public DateTime StartTime
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndTime
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public string ToString(Holl holl, List<Equipment> eqs)
        {
            string output = $"Мероприятие: {_note} \n" +
                $"Инициатор: {UserLogin} \n" +
                $" В зале: {holl.Name} \n " +
                $"Время начала: {_startDate} \n" +
                $" Время завершения: {_endDate} \n " +
                $"Статус мероприятия: {StatusExtensions.GetDescription(_status)} \n " +
                $"Комментарий: {_comment}\n " +
                $"Требуемое оборудование: \n";
            foreach (var eq in eqs) output += $"    {eq.Name} \n";

            return output;
        }

        public string ToString(Holl holl)
        {
            string output = $"Мероприятие: {_note} \n" +
                $"Инициатор: {UserLogin} \n" +
                $" В зале: {holl.Name} \n " +
                $"Время начала: {_startDate} \n" +
                $" Время завершения: {_endDate} \n " +
                $"Статус мероприятия: {StatusExtensions.GetDescription(_status)} \n " +
                $"Комментарий: {_comment}\n " +
                $"Требуемое оборудование: нет \n";

            return output;
        }
    }
}
