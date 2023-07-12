using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IDivisionDataWriter
    {
        void Create(Division department);
        void Update(Division department);
        void Delete(Division department);
        void CheckUsers(Division department);
        void UpdateParentDepartments(Division department);
        void RemoveDepartment(Division department);
    }
}
