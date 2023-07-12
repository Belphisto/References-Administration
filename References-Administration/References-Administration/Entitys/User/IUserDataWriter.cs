using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IUserDataWriter
    {
        void Create(User client);
        void Update(User client);
        void Delete(User client);
    }
}
