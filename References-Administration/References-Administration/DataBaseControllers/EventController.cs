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
    }
}
