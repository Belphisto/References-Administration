using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class Client
    {
        private int _id;
        private string _fullname;
        private string _login;
        private int? _departmentID;
        private string _passwordHash;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FullName
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public int? DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }

        public string PasswordHash
        {
            get { return _passwordHash; }
            set { _passwordHash = value; }
        }
        public override string ToString()
        {
            return $"ID: {_id}, Name: {_fullname}, Login: {_login}, Department ID: {_departmentID}";
        }

        public string GetDepartmentName(NpgsqlConnection connection, int? id)
        {
            Department department = Department.Read(connection, id);
            string name = department.Name;
            return name;
        }

        // CRUD операции
        // Создание нового пользователя
        public void Create(NpgsqlConnection connection)
        {
            string query = "INSERT INTO client (fullname, login, password_hash, id_department) VALUES (@Fullname, @Login, @Password_hash, @Id_department)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Fullname", _fullname);
                command.Parameters.AddWithValue("@Login", _login);
                command.Parameters.AddWithValue("@Password_hash", _passwordHash);
                command.Parameters.AddWithValue("@Id_department", _departmentID);
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
                        client.DepartmentID = (int?)reader["id_department"];
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
                        client.DepartmentID = (int?)reader["id_department"];
                    }
                }
            }
            return client;
        }


        // Обновление данных подразделения
        public void Update(NpgsqlConnection connection)
        {
            string query = "UPDATE client SET fullname = @Fullname, password_hash = @Password_hash, id_department = @Department_ID WHERE id = @ClientID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClientID", _id);
                command.Parameters.AddWithValue("@Fullname", _fullname);
                command.Parameters.AddWithValue("@Password_hash", _passwordHash);
                command.Parameters.AddWithValue("@Department_ID", _departmentID);
                command.ExecuteNonQuery();
            }
        }

        // Удаление пользователя по его идентификатору
        public void Delete(NpgsqlConnection connection)
        {
            // Удалить текущего пользователя из базы данных
            string deleteQuery = "DELETE FROM client WHERE id = @ClientID";
            using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, connection))
            {
                deleteCommand.Parameters.AddWithValue("@ClientID", _id);
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
}
