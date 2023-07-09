using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class EquipmentController
    {
        public static List<Equipment> GetEquipments(NpgsqlConnection connection, Holl holl)
        {
            List<Equipment> equipments = new List<Equipment>();
            string query = "SELECT * FROM Equipment WHERE MeetingRoomId = @MeetingRoomId";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
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

        public static Equipment Read(NpgsqlConnection connection, int id)
        {
            Equipment equipment = new Equipment();
            string query = "SELECT * FROM Equipment WHERE id = @Id"; 
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
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

        public static void AddEquipment(NpgsqlConnection connection, string eq_name, int holl_id)
        {
            string query = "INSERT INTO equipment (name, meetingroomid) VALUES (@Name, @HollID)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", eq_name);
                command.Parameters.AddWithValue("@HollID", holl_id);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteEquipment(NpgsqlConnection connection, Equipment equipment)
        {
            string query = "DELETE FROM Equipment WHERE Id = @Id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", equipment.ID);
                command.ExecuteNonQuery();
            }
        }

        // Удаление всех записей в таблице equipment, связанных с совещательным залом
        public static void DeleteEquipment(NpgsqlConnection connection, Holl holl)
        {
            string deleteEquipmentQuery = "DELETE FROM equipment WHERE MeetingRoomId = @MeetingRoomId";
            using (NpgsqlCommand deleteEquipmentCommand = new NpgsqlCommand(deleteEquipmentQuery, connection))
            {
                deleteEquipmentCommand.Parameters.AddWithValue("@MeetingRoomId", holl.ID);
                deleteEquipmentCommand.ExecuteNonQuery();
            }
        }
    }
}
