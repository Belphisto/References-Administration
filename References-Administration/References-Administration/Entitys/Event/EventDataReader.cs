using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    class EventDataReader : IEventDataReader
    {
        private readonly NpgsqlConnection _connection;

        public EventDataReader(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public List<Event> GetEvents(Holl holl)
        {
            var eventsInHoll = new List<Event>();
            string query = "SELECT * FROM event WHERE meetingroomid = @HollID";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@HollID", holl.ID);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var eventInHoll = new Event();
                        eventInHoll.ID = (int)reader["id"];
                        eventInHoll.Note = reader["note"].ToString();
                        eventInHoll.HollID = (int)reader["meetingroomid"];
                        eventInHoll.StartTime = (DateTime)reader["startdate"];
                        eventInHoll.EndTime = (DateTime)reader["enddate"];
                        eventInHoll.Status = (Status)Enum.Parse(typeof(Status), reader["status"].ToString());
                        eventInHoll.Comment = reader["comment"] != DBNull.Value ? Convert.ToString(reader["comment"]) : null;
                        eventInHoll.UserLogin = reader["client_login"].ToString();

                        eventsInHoll.Add(eventInHoll);
                    }
                }
            }
            return eventsInHoll;
        }

        public List<Event> GetEvents()
        {
            var eventsInHoll = new List<Event>();
            string query = "SELECT * FROM event ";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var eventInHoll = new Event();
                        eventInHoll.ID = (int)reader["id"];
                        eventInHoll.Note = reader["note"].ToString();
                        eventInHoll.HollID = (int)reader["meetingroomid"];
                        eventInHoll.StartTime = (DateTime)reader["startdate"];
                        eventInHoll.EndTime = (DateTime)reader["enddate"];
                        eventInHoll.Status = (Status)Enum.Parse(typeof(Status), reader["status"].ToString());
                        eventInHoll.UserLogin = reader["client_login"].ToString();
                        eventInHoll.Comment = reader["comment"] != DBNull.Value ? Convert.ToString(reader["comment"]) : null;
                        eventsInHoll.Add(eventInHoll);
                    }
                }
            }
            return eventsInHoll;
        }

        public List<Event> GetEvents(List<Event> events, DateTime selectedDate)
        {
            List<Event> eventsOnSelectedDate = events.Where(e => e.StartTime.Date == selectedDate.Date).ToList();
            return eventsOnSelectedDate;
        }

        public int GetLastCreatedID()
        {
            string selectQuery = "SELECT lastval()";
            using (NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, _connection))
            {
                int eventId = Convert.ToInt32(selectCommand.ExecuteScalar());
                return eventId;
            }
        }

        public bool IsEventTimeAvailable(Event planningEvent, List<Event> eventsInHoll)
        {
            foreach (Event existing in eventsInHoll)
            {
                if (planningEvent.StartTime < existing.EndTime && planningEvent.EndTime > existing.StartTime) return false;
            }
            return true;
        }
    }
}
