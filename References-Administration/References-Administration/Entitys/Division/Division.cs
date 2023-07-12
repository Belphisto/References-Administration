using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class Division
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }

        public override string ToString()
        {
            return $"Department ID: {ID}, Name: {Name}, Parent ID: {ParentID}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Department other = (Department)obj;
            return ID == other.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
