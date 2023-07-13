using System;
using System.Collections.Generic;

namespace References_Administration
{
    public class DataBase
    {
        //private readonly DataStorage _dataStorage;
        public DataBaseConntection DataBaseConntection { get;}
        public UserController UserController { get;}
        public RoleController RoleController { get;}
        public DivisionController DivisionController { get;}
        public EventController EventController { get;}
        public EquipmentController EquipmentController { get;}
        public HollController HollController { get;}

        public DataBase(DataStorage dataStorage)
        {
            //_dataStorage = dataStorage;

            DataBaseConntection = new DataBaseConntection();

            IUserDataReader userDataReader = new UserDataReader(DataBaseConntection);
            IUserDataWriter userDataWriter = new UserDataWriter(DataBaseConntection);
            IUserDataValid userDataValid = new UserDataValid();
            UserController = new UserController(userDataReader, userDataWriter, userDataValid);

            IRoleDataReader roleDataReader = new RoleDataReader(DataBaseConntection);
            IRoleDataWriter roleDataWriter = new RoleDataWriter(DataBaseConntection);
            RoleController = new RoleController(roleDataWriter, roleDataReader);

            IDivisionDataReader divisionDataReader = new DivisionDataReader(DataBaseConntection);
            IDivisionHollWriter divisionHollWriter = new DivisionHollWriter(DataBaseConntection);
            IDivisionDataWriter divisionDataWriter = new DivisionDataWriter(DataBaseConntection, divisionHollWriter);
            DivisionController = new DivisionController(divisionDataWriter, divisionDataReader,divisionHollWriter);
            
            IEquipmentDataReader equipmentDataReader = new EquipmentDataReader(DataBaseConntection);
            IEquipmentDataWriter equipmentDataWriter = new EquipmentDataWriter(DataBaseConntection);
            EquipmentController = new EquipmentController(equipmentDataReader, equipmentDataWriter);

            IEventDataReader eventDataReader = new EventDataReader(DataBaseConntection);
            IEventDataWriter eventDataWriter = new EventDataWriter(DataBaseConntection);
            IEventEquipmentDataReader eventEquipmentDataReader = new EventEquipmentDataReader(DataBaseConntection, equipmentDataReader);
            IEventEquipmentDataWriter eventEquipmentDataWriter = new EventEquipmentDataWriter(DataBaseConntection);
            EventController = new EventController(eventDataReader, eventDataWriter, eventEquipmentDataReader, eventEquipmentDataWriter);

            IHollDataWriter hollDataWriter = new HollDataWriter(DataBaseConntection);
            IHollDataReader hollDataReader = new HollDataReader(DataBaseConntection, divisionDataReader);
            HollController = new HollController(hollDataWriter, hollDataReader, eventDataWriter, divisionHollWriter, equipmentDataWriter);
        }

    }
}
