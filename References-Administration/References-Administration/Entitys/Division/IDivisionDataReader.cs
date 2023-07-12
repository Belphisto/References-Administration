using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IDivisionDataReader
    {
        List<Division> GetDepartments();
        Division Read(int departmentID);
        Division Read(string departmentName);
        string GetDepartmentName(int id);

    }
}
