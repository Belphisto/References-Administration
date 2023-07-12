using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IUserDataValid
    {
        string HashPassword(string password);
        bool ValidEmail(string email);
    }
}
