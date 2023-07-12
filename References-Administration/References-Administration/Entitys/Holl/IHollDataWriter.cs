using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IHollDataWriter
    {
        void Create(Holl holl);
        void Update(Holl holl);
        void Delete(Holl holl);
        void DeleteMeetingRoom(Holl holl);
    }
}
