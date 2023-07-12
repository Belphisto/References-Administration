using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IEventDataWriter
    {
        void DeleteEvents(Holl holl);
        void Create(Event planningEvent);
        void Update(Event planningEvent);
    }
}
