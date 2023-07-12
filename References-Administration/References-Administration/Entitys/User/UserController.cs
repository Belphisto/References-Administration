using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class UserController
    {
        private readonly IUserDataReader _userDataReader;
        private readonly IUserDataWriter _userDataWriter;
        private readonly IUserDataValid _userDataValid;

        public UserController(IUserDataReader clientDataReader, IUserDataWriter clientDataWriter, IUserDataValid userDataValid)
        {
            _userDataReader = clientDataReader;
            _userDataWriter = clientDataWriter;
            _userDataValid = userDataValid;
        }

        public List<User> GetClients()
        {
            return _userDataReader.GetClients();
        }

        public User ReadClient(int id)
        {
            return _userDataReader.Read(id);
        }

        public User ReadClient(string clientLogin)
        {
            return _userDataReader.Read(clientLogin);
        }

        public string GetEmail(string login)
        {
            return _userDataReader.GetEmail(login);
        }

        public string GetEmail(int id)
        {
            return _userDataReader.GetEmail(id);
        }

        public void CreateClient(User client)
        {
            _userDataWriter.Create(client);
        }

        public void UpdateClient(User client)
        {
            _userDataWriter.Update(client);
        }

        public void DeleteClient(User client)
        {
            _userDataWriter.Delete(client);
        }

        public bool ValidEmail(string email)
        {
            return _userDataValid.ValidEmail(email);
        }

        public string HashPassword(string password)
        {
            return _userDataValid.HashPassword(password);
        }
    }
}
