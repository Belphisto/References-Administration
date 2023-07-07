using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class Holl
    {
        private int _id;
        private string _name;
        //private List<int> _departmentsId;
       // private List<int> _equipmentsId;
        //private List<string> _equipmentsName;

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

        /*public List<int> DepartmentsID
        {
            get { return _departmentsId; }
            set { _departmentsId = value; }
        }

        public List<int> EquipmentsID
        {
            get { return _equipmentsId; }
            set { _equipmentsId = value; }
        }

        public List<string> EquipmentsName
        {
            get { return _equipmentsName; }
            set { _equipmentsName = value; }
        }*/

        public override string ToString()
        {
            return $"{_name}";
        }
    }
}
