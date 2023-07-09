using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class EventEquipment
    {
        public static void AddEquipment(NpgsqlConnection connection, Event ev, Equipment eq)
        {
            string query = "INSERT INTO event_equipment (event_id, equipment_id) VALUES (@EV, @EQ)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EV", ev.ID);
                command.Parameters.AddWithValue("@EQ", eq.ID);
                command.ExecuteNonQuery();
            }
        }
        public static List<Equipment> GetEquipmentInEvent(NpgsqlConnection connection, Event ev)
        {
            List<Equipment> equipments = new List<Equipment>();
            List<int> ids = new List<int>();
            string query = "SELECT equipment_id FROM event_equipment WHERE event_id = @EventId";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EventId", ev.ID);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Id = (int)reader["equipment_id"];
                        ids.Add(Id);
                        
                    }
                }
            }
            foreach (int id in ids) equipments.Add(EquipmentController.Read(connection, id));
            return equipments;
        }
    }
}
