using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class EventController
    {
        private IEventDataReader _eventDataReader;
        private IEventDataWriter _eventDataWriter;
        private IEventEquipmentDataReader _eventEquipmentDataReader;
        private IEventEquipmentDataWriter _eventEquipmentDataWriter;
        public EventController(IEventDataReader eventDataReader, IEventDataWriter eventDataWriter, IEventEquipmentDataReader eventEquipmentDataReader, IEventEquipmentDataWriter eventEquipmentDataWriter)
        {
            _eventDataReader = eventDataReader;
            _eventDataWriter = eventDataWriter;
            _eventEquipmentDataReader = eventEquipmentDataReader;
            _eventEquipmentDataWriter = eventEquipmentDataWriter;
        }
        public List<Event> GetEvents(Holl holl)
        {
            return _eventDataReader.GetEvents(holl);
        }

        public List<Event> GetEvents()
        {
            return _eventDataReader.GetEvents();
        }

        public List<Event> GetEvents(List<Event> events, DateTime selectedDate)
        {
            return _eventDataReader.GetEvents(events, selectedDate);
        }

        // Удаление всех event, связанных с совещательным залом
        public void DeleteEvents(Holl holl)
        {
            _eventDataWriter.DeleteEvents(holl);
        }

        public bool IsEventTimeAvailable(Event planningEvent, List<Event> eventsInHoll)
        {
            return _eventDataReader.IsEventTimeAvailable(planningEvent, eventsInHoll);
        }

        public void Create(Event planningEvent)
        {
            _eventDataWriter.Create(planningEvent);
        }

        public  int GetLastCreatedID()
        {
            return _eventDataReader.GetLastCreatedID();
        }

        public  void Update(Event planningEvent)
        {
            _eventDataWriter.Update(planningEvent);
        }

        public void AddEquipment( Event ev, Equipment eq)
        {
            _eventEquipmentDataWriter.AddEquipment(ev, eq);
        }
        public List<Equipment> GetEquipmentInEvent( Event ev)
        {
            return _eventEquipmentDataReader.GetEquipmentInEvent(ev);
        }

    }
}
