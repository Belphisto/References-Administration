using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class EquipmentController
    {
        private IEquipmentDataReader _equipmentDataReader;
        private IEquipmentDataWriter _equipmentDataWriter;

        public EquipmentController(IEquipmentDataReader equipmentDataReader, IEquipmentDataWriter equipmentDataWriter)
        {
            _equipmentDataReader = equipmentDataReader;
            _equipmentDataWriter = equipmentDataWriter;
        }
        public List<Equipment> GetEquipments(Holl holl)
        {
            return _equipmentDataReader.GetEquipments(holl);
        }

        public  Equipment Read( int id)
        {
            return _equipmentDataReader.Read(id);
        }

        public void AddEquipment(string eq_name, int holl_id)
        {
            _equipmentDataWriter.AddEquipment(eq_name, holl_id);
        }
        public void DeleteEquipment(Equipment equipment)
        {
            _equipmentDataWriter.DeleteEquipment(equipment);
        }

        // Удаление всех записей в таблице equipment, связанных с совещательным залом
        public void DeleteEquipment(Holl holl)
        {
            _equipmentDataWriter.DeleteEquipment(holl);
        }
    }
}
