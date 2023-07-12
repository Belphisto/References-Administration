using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class HollDataWriter : IHollDataWriter
    {
        private readonly NpgsqlConnection _connection;

        public HollDataWriter(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public void Create(Holl holl)
        {
            string query = "INSERT INTO meetingroom (name) VALUES (@Name)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Name", holl.Name);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Holl holl)
        {
            throw new NotImplementedException();
        }

        public void DeleteMeetingRoom(Holl holl)
        {
            string deleteMeetingRoomQuery = "DELETE FROM meetingroom WHERE Id = @MeetingRoomId";
            using (NpgsqlCommand deleteMeetingRoomCommand = new NpgsqlCommand(deleteMeetingRoomQuery, _connection))
            {
                deleteMeetingRoomCommand.Parameters.AddWithValue("@MeetingRoomId", holl.ID);
                deleteMeetingRoomCommand.ExecuteNonQuery();
            }
        }

        public void Update(Holl holl)
        {
            string query = "UPDATE meetingroom SET name = @Name WHERE id = @HollID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@HollID", holl.ID);
                command.Parameters.AddWithValue("@Name", holl.Name);
                command.ExecuteNonQuery();
            }
        }
    }
}
