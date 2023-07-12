using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IEquipmentDataWriter
    {
        void AddEquipment(string eq_name, int holl_id);
        void DeleteEquipment(Equipment equipment);
        void DeleteEquipment(Holl holl);
    }
}
