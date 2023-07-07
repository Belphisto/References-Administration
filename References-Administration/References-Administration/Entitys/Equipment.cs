using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class Equipment
    {
        private int _id;
        private string _name;
        private int _hollId;

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

        public int HollID
        {
            get { return _hollId; }
            set { _hollId = value; }
        }
    }
}
