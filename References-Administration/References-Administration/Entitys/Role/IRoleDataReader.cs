using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IRoleDataReader
    {
        List<string> GetRoles();
        int GetID(string role);
        List<string> GetUserRoles(User client);
        List<string> GetMissingRoles(User client);
        List<int> GetUserIds(string role);
    }
}
