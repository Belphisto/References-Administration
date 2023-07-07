using System;
using System.Collections.Generic;
using Npgsql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    class HollController
    {
        public static List<Holl> GetHolls(NpgsqlConnection connection)
        {
            List<Holl> holls = new List<Holl>();
            string query = "SELECT * FROM meetingroom";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
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

        public static List<Department> GetDepartments(NpgsqlConnection connection, Holl holl)
        {
            List<Department> departments = new List<Department>();
            List<int> ids = new List<int>();
            string query = "SELECT DepartmentId FROM Department_MeetingRoom WHERE MeetingRoomId = @SelectedMeetingRoomId;";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
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
                departments.Add(DepartmentController.Read(connection, id));
            }
            return departments;
        }

        // CRUD операции
        // Создание нового совещательного зала
        public static void Create(NpgsqlConnection connection, Holl holl)
        {
            string query = "INSERT INTO meetingroom (name) VALUES (@Name)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", holl.Name);
                command.ExecuteNonQuery();
            }
        }

        // Чтение данных совещательного зала по его идентификатору
        public static Holl Read(NpgsqlConnection connection, int hollID)
        {
            Holl holl = null;
            string query = "SELECT * FROM meetingroom WHERE id = @HollID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
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

        public static Holl Read(NpgsqlConnection connection, string hollname)
        {
            Holl holl = null;
            string query = "SELECT * FROM meetingroom WHERE name = @Hollname";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
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

        // Обновление данных совещательного зала
        public static void Update(NpgsqlConnection connection, Holl holl)
        {
            string query = "UPDATE meetingroom SET name = @Name WHERE id = @HollID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@HollID", holl.ID);
                command.Parameters.AddWithValue("@Name", holl.Name);
                command.ExecuteNonQuery();
            }
        }

        // Удаление совещательного зала по его идентификатору
        public static void Delete(NpgsqlConnection connection, Holl holl)
        {
            EventController.DeleteEvents(connection, holl);
            DepartmentHollController.RemoveDepartmentMeetingRooms(connection, holl);
            EquipmentController.DeleteEquipment(connection, holl);
            DeleteMeetingRoom(connection, holl);
        }

        // Удаление совещательного зала
        private static void DeleteMeetingRoom(NpgsqlConnection connection, Holl holl)
        {
            string deleteMeetingRoomQuery = "DELETE FROM meetingroom WHERE Id = @MeetingRoomId";
            using (NpgsqlCommand deleteMeetingRoomCommand = new NpgsqlCommand(deleteMeetingRoomQuery, connection))
            {
                deleteMeetingRoomCommand.Parameters.AddWithValue("@MeetingRoomId", holl.ID);
                deleteMeetingRoomCommand.ExecuteNonQuery();
            }
        }

    }
}
