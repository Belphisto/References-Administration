﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class Department
    {
        private int _id;
        private string _name;
        private int? _parentID;

        // Свойства класса
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int? ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        // Метод ToString() для получения строкового представления объекта
        public override string ToString()
        {
            return $"Department ID: {_id}, Name: {_name}, Parent ID: {_parentID}";
        }

        // CRUD операции
        // Создание нового подразделения
        public void Create(NpgsqlConnection connection)
        {
            string query = "INSERT INTO department (name, parent_id) VALUES (@Name, @ParentID)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", _name);
                command.Parameters.AddWithValue("@ParentID", _parentID);
                command.ExecuteNonQuery();
            }
        }

        // Чтение данных подразделения по его идентификатору
        /*public void Read(NpgsqlConnection connection, int departmentID)
        {
            string query = "SELECT * FROM department WHERE id = @DepartmentID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartmentID", departmentID);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        _id = (int)reader["id"];
                        _name = reader["name"].ToString();
                        _parentID = (int)reader["parent_id"];
                    }
                }
            }
        }*/
        public static Department Read(NpgsqlConnection connection, int departmentID)
        {
            Department department = null;
            string query = "SELECT * FROM department WHERE id = @DepartmentID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartmentID", departmentID);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        department = new Department();
                        department.ID = (int)reader["id"];
                        department.Name = reader["name"].ToString();
                        department.ParentID = (int)reader["parent_id"];
                    }
                }
            }
            return department;
        }

        public static Department Read(NpgsqlConnection connection, string departmentName)
        {
            Department department = null;
            string query = "SELECT * FROM department WHERE name = @DepartmentName";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartmentName", departmentName);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        department = new Department();
                        department.ID = (int)reader["id"];
                        department.Name = reader["name"].ToString();
                        department.ParentID = (int)reader["parent_id"];
                    }
                }
            }
            return department;
        }


        // Обновление данных подразделения
        public void Update(NpgsqlConnection connection)
        {
            string query = "UPDATE department SET name = @Name, parent_id = @ParentID WHERE id = @DepartmentID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartmentID", _id);
                command.Parameters.AddWithValue("@Name", _name);
                command.Parameters.AddWithValue("@ParentID", _parentID);

                command.ExecuteNonQuery();
            }
        }

        // Удаление подразделения по его идентификатору
        public void Delete(NpgsqlConnection connection)
        {
            string query = "DELETE FROM department WHERE id = @DepartmentID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartmentID", _id);

                command.ExecuteNonQuery();
            }
        }
    }
}
