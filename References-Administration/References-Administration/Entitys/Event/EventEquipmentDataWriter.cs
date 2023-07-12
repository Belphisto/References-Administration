using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class EventEquipmentDataWriter : IEventEquipmentDataWriter
    {
        private readonly NpgsqlConnection _connection;
        public EventEquipmentDataWriter(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public void AddEquipment(Event ev, Equipment eq)
        {
            string query = "INSERT INTO event_equipment (event_id, equipment_id) VALUES (@EV, @EQ)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@EV", ev.ID);
                command.Parameters.AddWithValue("@EQ", eq.ID);
                command.ExecuteNonQuery();
            }
        }
    }
}
