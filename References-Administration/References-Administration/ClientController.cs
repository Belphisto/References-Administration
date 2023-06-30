using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

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
                        client.DepartmentID = (int?)reader["id_department"];
                        client.PasswordHash = reader["password_hash"].ToString();
                        clients.Add(client);
                        Log.WriteLog($"ClientController/GetClients(NpgsqlConnection connection)/ department {client} add to List<Client> clients ");
                    }
                }
            }
            return clients;
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
    }
}
