using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class EventController
    {
        public static List<Event> GetEvents(NpgsqlConnection connection, Holl holl)
        {
            var eventsInHoll = new List<Event>();
            string query = "SELECT * FROM event WHERE meetingroomid = @HollID";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
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
                        eventInHoll.Comment = reader["comment"] != DBNull.Value ? Convert.ToString(reader["parent_id"]) : null;
                        eventsInHoll.Add(eventInHoll);
                    }
                }
            }
            return eventsInHoll;
        }

        public static List<Event> GetEvents(NpgsqlConnection connection)
        {
            var eventsInHoll = new List<Event>();
            string query = "SELECT * FROM event ";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
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
                        eventInHoll.Comment = reader["comment"] != DBNull.Value ? Convert.ToString(reader["parent_id"]) : null;
                        eventsInHoll.Add(eventInHoll);
                    }
                }
            }
            return eventsInHoll;
        }

        public static List<Event> GetEvents(NpgsqlConnection connection, List<Event> events, DateTime selectedDate)
        {
            List<Event> eventsOnSelectedDate = events.Where(e => e.StartTime.Date == selectedDate.Date).ToList();
            return eventsOnSelectedDate;
        }

        // Удаление всех event, связанных с совещательным залом
        public static void DeleteEvents(NpgsqlConnection connection, Holl holl)
        {
            string deleteEventQuery = "DELETE FROM event WHERE MeetingRoomId = @MeetingRoomId";
            using (NpgsqlCommand deleteEventCommand = new NpgsqlCommand(deleteEventQuery, connection))
            {
                deleteEventCommand.Parameters.AddWithValue("@MeetingRoomId", holl.ID);
                deleteEventCommand.ExecuteNonQuery();
            }
        }

        public static bool IsEventTimeAvailable(Event planningEvent, List<Event> eventsInHoll)
        {
            foreach (Event existing in eventsInHoll)
            {
                if (planningEvent.StartTime < existing.EndTime && planningEvent.EndTime > existing.StartTime) return false;
            }
            return true;
        }

        public static void Create(NpgsqlConnection connection, Event planningEvent)
        {
            string query = "INSERT INTO event (note, meetingroomid, startdate, enddate, status) VALUES (@Note, @HollID, @StartDate, @EndDate, @Status)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Note", planningEvent.Note);
                command.Parameters.AddWithValue("@HollID", planningEvent.HollID);
                command.Parameters.AddWithValue("@StartDate", planningEvent.StartTime);
                command.Parameters.AddWithValue("@EndDate", planningEvent.EndTime);
                command.Parameters.AddWithValue("@Status", planningEvent.Status.ToString());
                command.ExecuteNonQuery();
            }
        }
    }
}
