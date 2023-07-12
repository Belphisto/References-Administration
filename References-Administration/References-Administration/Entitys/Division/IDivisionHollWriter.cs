using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IDivisionHollWriter
    {
        void RemoveDepartmentMeetingRooms(Division department);
        void RemoveDepartmentMeetingRooms(Holl holl);
        void AddDepatrment(Division department, Holl holl);
        void RemoveDepartment(Division department, Holl holl);
    }
}
