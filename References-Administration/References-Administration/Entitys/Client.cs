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
        private int _departmentID;
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
        public int DepartmentID
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

        public string GetDepartmentName(NpgsqlConnection connection, int id)
        {
            Department department = DepartmentController.Read(connection, id);
            string name = department.Name;
            return name;
        }
    }
}
