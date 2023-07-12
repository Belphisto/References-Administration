using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IUserDataReader
    {
        List<User> GetClients();
        User Read(int id);
        User Read(string clientLogin);
        string GetEmail(string login);
        string GetEmail(int id);
    }
}
