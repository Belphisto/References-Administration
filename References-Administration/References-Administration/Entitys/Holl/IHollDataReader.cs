using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IHollDataReader
    {
        List<Holl> GetHolls();
        List<Division> GetDepartments(Holl holl);
        Holl Read(int hollID);
        Holl Read(string hollname);

    }
}
