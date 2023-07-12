using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.ComponentModel.DataAnnotations;

namespace References_Administration
{
    class ClientController
    {
        public static List<Client> GetClients(NpgsqlConnection connection)
        {
            List<Client> clients = new List<Client>();
            string query = "SELECT * FROM client";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client client = new Client();
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
        public static string GetEmail(NpgsqlConnection connection, string login)
        {
            string email = "";
            string query = "SELECT email FROM client WHERE login = @Login";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
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

        public static string GetEmail(NpgsqlConnection connection, int id)
        {
            string email = "";
            string query = "SELECT email FROM client WHERE id = @Id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
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

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hash;
            }
        }

        // CRUD операции
        // Создание нового пользователя
        public static void Create(NpgsqlConnection connection, Client client)
        {
            string query = "INSERT INTO client (fullname, login, password_hash, id_department, email) VALUES (@Fullname, @Login, @Password_hash, @Id_department, @Email)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Fullname", client.FullName);
                command.Parameters.AddWithValue("@Login", client.Login);
                command.Parameters.AddWithValue("@Password_hash", client.PasswordHash);
                command.Parameters.AddWithValue("@Id_department", client.DepartmentID);
                command.Parameters.AddWithValue("@Email", client.EmailAddress);
                command.ExecuteNonQuery();
            }
        }

        // Чтение данных пользователя по его идентификатору
        public static Client Read(NpgsqlConnection connection, int id)
        {
            Client client = null;
            string query = "SELECT * FROM client WHERE id = @ClientID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClientID", id);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = new Client();
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

        // Чтение данных подразделения по его наименованию

        public static Client Read(NpgsqlConnection connection, string clientLogin)
        {
            Client client = null;
            string query = "SELECT * FROM client WHERE login = @ClientLogin";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClientLogin", clientLogin);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = new Client();
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


        // Обновление данных подразделения
        public static void Update(NpgsqlConnection connection, Client client)
        {
            string query = "UPDATE client SET fullname = @Fullname, password_hash = @Password_hash, id_department = @Department_ID WHERE id = @ClientID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClientID", client.ID);
                command.Parameters.AddWithValue("@Fullname", client.FullName);
                command.Parameters.AddWithValue("@Password_hash", client.PasswordHash);
                command.Parameters.AddWithValue("@Department_ID", client.DepartmentID);
                command.ExecuteNonQuery();
            }
        }

        // Удаление пользователя по его идентификатору
        public static void Delete(NpgsqlConnection connection, Client client)
        {
            // Удалить текущего пользователя из базы данных
            string deleteQuery = "DELETE FROM client WHERE id = @ClientID";
            using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, connection))
            {
                deleteCommand.Parameters.AddWithValue("@ClientID", client.ID) ;
                deleteCommand.ExecuteNonQuery();
            }
        }

        public static bool ValidEmail(string email)
        {
            if (new EmailAddressAttribute().IsValid(email))
                return true;
            else return false;
        }
    }
}
