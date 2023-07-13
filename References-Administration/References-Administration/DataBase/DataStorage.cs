using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class DataStorage
    {
        public List<Division> Divisions { get; set; }
        public List<User> Users { get; set; }
        public List<Holl> Holls { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<string> Roles { get; set; }
        public List<Event> Events { get; set; }
    }
}
