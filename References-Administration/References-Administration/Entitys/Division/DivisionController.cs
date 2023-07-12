using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class DivisionController
    {
        private readonly IDivisionDataWriter _divisionDataWriter;
        private readonly IDivisionDataReader _divisionDataReader;

        public DivisionController (IDivisionDataWriter divisionDataWriter, IDivisionDataReader divisionDataReader)
        {
            _divisionDataReader = divisionDataReader;
            _divisionDataWriter = divisionDataWriter;
        }

        public List<Division> GetDepartments()
        {
            return _divisionDataReader.GetDepartments();
        }

        public string GetDepartmentName(int id)
        {
            return _divisionDataReader.GetDepartmentName(id);
        }

        // CRUD операции
        // Создание нового подразделения
        public void Create(Division department)
        {
            _divisionDataWriter.Create(department);
        }

        // Чтение данных подразделения по его идентификатору
        public Division Read(int departmentID)
        {
            return _divisionDataReader.Read(departmentID);
        }

        // Чтение данных подразделения по его наименованию
        public Division Read(string departmentName)
        {
            return _divisionDataReader.Read(departmentName);
        }

        // Обновление данных подразделения
        public void Update(Division department)
        {
            _divisionDataWriter.Update(department);
        }

        // Удаление подразделения по его идентификатору
        public void Delete( Division department)
        {
            _divisionDataWriter.Delete(department);
        }

    }
}
