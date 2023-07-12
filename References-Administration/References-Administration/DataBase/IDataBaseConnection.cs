using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public interface IDataBaseConnection
    {
        NpgsqlConnection GetConnection();
        void CloseConnection();
    }
}
