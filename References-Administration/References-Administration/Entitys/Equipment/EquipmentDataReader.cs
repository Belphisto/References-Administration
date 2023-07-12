using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    class EquipmentDataReader : IEquipmentDataReader
    {
        private readonly NpgsqlConnection _connection;
        public EquipmentDataReader(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public List<Equipment> GetEquipments(Holl holl)
        {
            List<Equipment> equipments = new List<Equipment>();
            string query = "SELECT * FROM Equipment WHERE MeetingRoomId = @MeetingRoomId";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@MeetingRoomId", holl.ID);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Equipment equipment = new Equipment();
                        equipment.ID = (int)reader["id"];
                        equipment.Name = reader["name"].ToString();
                        equipment.HollID = (int)reader["MeetingRoomId"];
                        equipments.Add(equipment);
                    }
                }
            }
            return equipments;
        }

        public Equipment Read(int id)
        {
            Equipment equipment = new Equipment();
            string query = "SELECT * FROM Equipment WHERE id = @Id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        equipment.ID = (int)reader["id"];
                        equipment.Name = reader["name"].ToString();
                        equipment.HollID = (int)reader["MeetingRoomId"];
                    }
                }
            }
            return equipment;
        }
    }
}
