using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class Equipment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int HollID { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
