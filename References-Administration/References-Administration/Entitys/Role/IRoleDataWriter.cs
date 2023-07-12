using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IRoleDataWriter
    {
        void Create(string role);
        void Update(string lastrole, string newRole);
        void Delete(string role);
        void AddRoleToClient(int roleId, User client);
        void RemoveRoleFromClient(int roleId, User client);
    }
}
