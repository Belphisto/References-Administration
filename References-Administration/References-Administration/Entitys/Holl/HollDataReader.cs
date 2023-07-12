using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class HollDataReader : IHollDataReader
    {
        private readonly NpgsqlConnection _connection;
        private readonly IDivisionDataReader _divisionDataReader;

        public HollDataReader(DataBaseConntection connection, IDivisionDataReader divisionDataReader)
        {
            _connection = connection.GetConnection();
            _divisionDataReader = divisionDataReader;
        }

        public List<Division> GetDepartments(Holl holl)
        {
            List<Division> departments = new List<Division>();
            List<int> ids = new List<int>();
            string query = "SELECT DepartmentId FROM Department_MeetingRoom WHERE MeetingRoomId = @SelectedMeetingRoomId;";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@SelectedMeetingRoomId", holl.ID);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add((int)reader["DepartmentId"]);
                    }
                }
            }
            foreach (var id in ids)
            {
                departments.Add(_divisionDataReader.Read(id));
            }
            return departments;
        }

        public List<Holl> GetHolls()
        {
            List<Holl> holls = new List<Holl>();
            string query = "SELECT * FROM meetingroom";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Holl holl = new Holl();
                        holl.ID = (int)reader["id"];
                        holl.Name = reader["name"].ToString();

                        holls.Add(holl);
                        //Log.WriteLog($"ClientController/GetClients(NpgsqlConnection connection)/ department {client} add to List<Client> clients ");
                    }
                }
            }
            return holls;
        }

        public Holl Read(int hollID)
        {
            Holl holl = null;
            string query = "SELECT * FROM meetingroom WHERE id = @HollID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@HollID", hollID);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        holl = new Holl();
                        holl.ID = (int)reader["id"];
                        holl.Name = reader["name"].ToString();
                    }
                }
            }
            return holl;
        }

        public Holl Read(string hollname)
        {
            Holl holl = null;
            string query = "SELECT * FROM meetingroom WHERE name = @Hollname";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Hollname", hollname);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        holl = new Holl();
                        holl.ID = (int)reader["id"];
                        holl.Name = reader["name"].ToString();
                    }
                }
            }
            return holl;
        }
    }
}
