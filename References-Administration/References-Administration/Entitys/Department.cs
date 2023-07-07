using Npgsql;
using NpgsqlTypes;
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Department other = (Department)obj;
            return _id == other._id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

    }
}
