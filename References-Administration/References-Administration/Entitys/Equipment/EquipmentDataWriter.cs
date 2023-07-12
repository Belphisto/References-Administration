using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    class EquipmentDataWriter : IEquipmentDataWriter
    {
        private readonly NpgsqlConnection _connection;
        public EquipmentDataWriter(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public void AddEquipment(string eq_name, int holl_id)
        {
            string query = "INSERT INTO equipment (name, meetingroomid) VALUES (@Name, @HollID)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Name", eq_name);
                command.Parameters.AddWithValue("@HollID", holl_id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEquipment(Equipment equipment)
        {
            string query = "DELETE FROM Equipment WHERE Id = @Id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id", equipment.ID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEquipment(Holl holl)
        {
            string deleteEquipmentQuery = "DELETE FROM equipment WHERE MeetingRoomId = @MeetingRoomId";
            using (NpgsqlCommand deleteEquipmentCommand = new NpgsqlCommand(deleteEquipmentQuery, _connection))
            {
                deleteEquipmentCommand.Parameters.AddWithValue("@MeetingRoomId", holl.ID);
                deleteEquipmentCommand.ExecuteNonQuery();
            }
        }
    }
}
