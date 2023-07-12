using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class DataBase
    {
        public DataBaseConntection dataBaseConntection;
        public UserController userController;
        public RoleController roleController;
        public DivisionController divisionController;
        public EventController eventController;
        public EquipmentController equipmentController;
        public HollController hollController;

        public DataBase()
        {
            dataBaseConntection = new DataBaseConntection();

            IUserDataReader userDataReader = new UserDataReader(dataBaseConntection);
            IUserDataWriter userDataWriter = new UserDataWriter(dataBaseConntection);
            IUserDataValid userDataValid = new UserDataValid();
            userController = new UserController(userDataReader, userDataWriter, userDataValid);

            IRoleDataReader roleDataReader = new RoleDataReader(dataBaseConntection);
            IRoleDataWriter roleDataWriter = new RoleDataWriter(dataBaseConntection);
            roleController = new RoleController(roleDataWriter, roleDataReader);

            IDivisionDataReader divisionDataReader = new DivisionDataReader(dataBaseConntection);
            IDivisionHollWriter divisionHollWriter = new DivisionHollWriter(dataBaseConntection);
            IDivisionDataWriter divisionDataWriter = new DivisionDataWriter(dataBaseConntection, divisionHollWriter);
            divisionController = new DivisionController(divisionDataWriter, divisionDataReader);
            
            IEquipmentDataReader equipmentDataReader = new EquipmentDataReader(dataBaseConntection);
            IEquipmentDataWriter equipmentDataWriter = new EquipmentDataWriter(dataBaseConntection);
            equipmentController = new EquipmentController(equipmentDataReader, equipmentDataWriter);

            IEventDataReader eventDataReader = new EventDataReader(dataBaseConntection);
            IEventDataWriter eventDataWriter = new EventDataWriter(dataBaseConntection);
            IEventEquipmentDataReader eventEquipmentDataReader = new EventEquipmentDataReader(dataBaseConntection, equipmentDataReader);
            IEventEquipmentDataWriter eventEquipmentDataWriter = new EventEquipmentDataWriter(dataBaseConntection);
            eventController = new EventController(eventDataReader, eventDataWriter, eventEquipmentDataReader, eventEquipmentDataWriter);

            IHollDataWriter hollDataWriter = new HollDataWriter(dataBaseConntection);
            IHollDataReader hollDataReader = new HollDataReader(dataBaseConntection, divisionDataReader);
            hollController = new HollController(hollDataWriter, hollDataReader, eventDataWriter, divisionHollWriter, equipmentDataWriter);


        }

    }
}
