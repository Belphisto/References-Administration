using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IEventEquipmentDataWriter
    {
        void AddEquipment(Event ev, Equipment eq);
    }
}
