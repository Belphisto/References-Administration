using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class RoleController
    {
        private readonly IRoleDataWriter _roleDataWriter;
        private readonly IRoleDataReader _roleDataReader;

        public RoleController(IRoleDataWriter roleDataWriter, IRoleDataReader roleDataReader)
        {
            _roleDataReader = roleDataReader;
            _roleDataWriter = roleDataWriter;
        }

        public List<string> GetRoles()
        {
            return _roleDataReader.GetRoles();
        }

        public void Create(string role)
        {
            _roleDataWriter.Create(role);
        }

        public void Update(string lastrole, string newRole)
        {
            _roleDataWriter.Update(lastrole, newRole);
        }

        public void Delete(string role)
        {
            _roleDataWriter.Delete(role);
        }

        public  int GetID(string role)
        {
            return _roleDataReader.GetID(role);
        }

        public void AddRoleToClient(string role, User client)
        {
            int id_role = _roleDataReader.GetID(role);
            _roleDataWriter.AddRoleToClient(id_role, client);
        }

        public void RemoveRoleFromClient(string role, User client)
        {
            int id_role = _roleDataReader.GetID(role);
            _roleDataWriter.RemoveRoleFromClient(id_role, client);
        }

        public  List<string> GetUserRoles(User client)
        {
            return _roleDataReader.GetUserRoles(client);
        }

        public List<string> GetMissingRoles( User client)
        {
            return _roleDataReader.GetMissingRoles(client);
        }
        
        public List<int> GetClientIds(string role)
        {
            return _roleDataReader.GetUserIds(role);
        }
    }
}
