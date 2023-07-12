using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class EventEquipmentDataReader : IEventEquipmentDataReader
    {
        private readonly NpgsqlConnection _connection;
        private readonly IEquipmentDataReader _equipmentDataReader;
        public EventEquipmentDataReader(DataBaseConntection connection, IEquipmentDataReader equipmentDataReader)
        {
            _connection = connection.GetConnection();
            _equipmentDataReader = equipmentDataReader;
        }

        public List<Equipment> GetEquipmentInEvent(Event ev)
        {
            List<Equipment> equipments = new List<Equipment>();
            List<int> ids = new List<int>();
            string query = "SELECT equipment_id FROM event_equipment WHERE event_id = @EventId";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
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
            foreach (int id in ids) equipments.Add(_equipmentDataReader.Read(id));
            return equipments;
        }
    }
}
