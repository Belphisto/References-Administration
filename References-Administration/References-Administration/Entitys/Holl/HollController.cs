using System;
using System.Collections.Generic;
using Npgsql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class HollController
    {
        private IHollDataWriter _hollDataWriter;
        private IHollDataReader _hollDataReader;
        private IEventDataWriter _eventDataWriter;
        private IDivisionHollWriter _divisionHollWriter;
        private IEquipmentDataWriter _equipmentDataWriter;

        public HollController(IHollDataWriter hollDataWriter, IHollDataReader hollDataReader, IEventDataWriter eventDataWriter, IDivisionHollWriter divisionHollWriter, IEquipmentDataWriter equipmentDataWriter)
        {
            _hollDataReader = hollDataReader;
            _hollDataWriter = hollDataWriter;
            _eventDataWriter = eventDataWriter;
            _divisionHollWriter = divisionHollWriter;
            _equipmentDataWriter = equipmentDataWriter;
        }
        public List<Holl> GetHolls()
        {
            return _hollDataReader.GetHolls();
        }

        public  List<Division> GetDepartments( Holl holl)
        {
           return _hollDataReader.GetDepartments(holl);
        }

        // CRUD операции
        // Создание нового совещательного зала
        public void Create(Holl holl)
        {
            _hollDataWriter.Create(holl);
        }

        // Чтение данных совещательного зала по его идентификатору
        public Holl Read( int hollID)
        {
           return _hollDataReader.Read(hollID);
        }

        public  Holl Read( string hollname)
        {
            return _hollDataReader.Read(hollname);
        }

        // Обновление данных совещательного зала
        public void Update(Holl holl)
        {
            _hollDataWriter.Update(holl);
        }

        // Удаление совещательного зала по его идентификатору
        public void Delete( Holl holl)
        {
            _eventDataWriter.DeleteEvents(holl);
            _divisionHollWriter.RemoveDepartmentMeetingRooms(holl);
            _equipmentDataWriter.DeleteEquipment(holl);
            _hollDataWriter.DeleteMeetingRoom(holl); 
        }


    }
}
