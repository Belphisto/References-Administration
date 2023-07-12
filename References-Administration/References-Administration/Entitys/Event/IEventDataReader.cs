using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IEventDataReader
    {
        List<Event> GetEvents(Holl holl);
        List<Event> GetEvents();
        List<Event> GetEvents(List<Event> events, DateTime selectedDate);
        bool IsEventTimeAvailable(Event planningEvent, List<Event> eventsInHoll);
        int GetLastCreatedID();
    }
}
