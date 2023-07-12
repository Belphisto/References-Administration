using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    class EventDataWriter : IEventDataWriter
    {
        private readonly NpgsqlConnection _connection;

        public EventDataWriter (DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public void Create(Event planningEvent)
        {
            string query = "INSERT INTO event (note, meetingroomid, startdate, enddate, status, client_login) VALUES (@Note, @HollID, @StartDate, @EndDate, @Status, @Login)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Note", planningEvent.Note);
                command.Parameters.AddWithValue("@HollID", planningEvent.HollID);
                command.Parameters.AddWithValue("@StartDate", planningEvent.StartTime);
                command.Parameters.AddWithValue("@EndDate", planningEvent.EndTime);
                command.Parameters.AddWithValue("@Status", planningEvent.Status.ToString());
                command.Parameters.AddWithValue("@Login", planningEvent.UserLogin.ToString());
                command.ExecuteNonQuery();

            }
        }

        public void DeleteEvents(Holl holl)
        {
            string deleteEventQuery = "DELETE FROM event WHERE MeetingRoomId = @MeetingRoomId";
            using (NpgsqlCommand deleteEventCommand = new NpgsqlCommand(deleteEventQuery, _connection))
            {
                deleteEventCommand.Parameters.AddWithValue("@MeetingRoomId", holl.ID);
                deleteEventCommand.ExecuteNonQuery();
            }
        }

        public void Update(Event planningEvent)
        {
            string query = "UPDATE event SET comment = @Comment, status = @Status WHERE id = @EventId";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Comment", planningEvent.Comment);
                command.Parameters.AddWithValue("@Status", planningEvent.Status.ToString());
                command.Parameters.AddWithValue("@EventId", planningEvent.ID);
                command.ExecuteNonQuery();
            }
        }
    }
}
