using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class UserDataReader : IUserDataReader
    {
        private readonly NpgsqlConnection _connection;

        public UserDataReader(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public List<User> GetClients()
        {
            List<User> clients = new List<User>();
            string query = "SELECT * FROM client";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User client = new User();
                        client.ID = (int)reader["id"];
                        client.FullName = reader["fullname"].ToString();
                        client.Login = reader["login"].ToString();
                        client.DepartmentID = (int)reader["id_department"];
                        client.PasswordHash = reader["password_hash"].ToString();
                        client.EmailAddress = reader["email"].ToString();
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }

        public string GetEmail(string login)
        {
            string email = "";
            string query = "SELECT email FROM client WHERE login = @Login";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Login", login);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        email = reader["email"].ToString();
                    }
                }
            }
            return email;
        }

        public string GetEmail(int id)
        {
            string email = "";
            string query = "SELECT email FROM client WHERE id = @Id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        email = reader["email"].ToString();
                    }
                }
            }
            return email;
        }

        public User Read(int id)
        {
            User client = null;
            string query = "SELECT * FROM client WHERE id = @ClientID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@ClientID", id);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = new User();
                        client.ID = (int)reader["id"];
                        client.FullName = reader["fullname"].ToString();
                        client.Login = reader["login"].ToString();
                        client.PasswordHash = reader["password_hash"].ToString();
                        client.DepartmentID = (int)reader["id_department"];
                        client.EmailAddress = reader["email"].ToString();
                    }
                }
            }
            return client;
        }

        public User Read(string clientLogin)
        {
            User client = null;
            string query = "SELECT * FROM client WHERE login = @ClientLogin";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@ClientLogin", clientLogin);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = new User();
                        client.ID = (int)reader["id"];
                        client.FullName = reader["fullname"].ToString();
                        client.Login = reader["login"].ToString();
                        client.PasswordHash = reader["password_hash"].ToString();
                        client.DepartmentID = (int)reader["id_department"];
                        client.EmailAddress = reader["email"].ToString();
                    }
                }
            }
            return client;
        }


    }
}
