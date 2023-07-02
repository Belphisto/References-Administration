using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class Session
    {
        private static Session _instance;
        private bool _isAuthenticated = false;
        //private string username;
        private Client _client;

        private Session() { }
        public static Session GetInstance()
        {
            if (_instance == null)
                _instance = new Session();
            return _instance;
        }
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
        }

        public string GetName()
        {
            return _client.Login;
        }
        //public string Username
        //{
        //    get { return username; }
        //}
        public Client User
        {
            get { return _client; }
        }

        public void Login(Client client)
        {
            // Здесь вы можете добавить логику проверки аутентификации,
            // например, проверить имя пользователя и пароль в базе данных или другом источнике.

            // Предположим, что аутентификация успешна и имя пользователя верное.
            _isAuthenticated = true;
            this._client = client;
        }

        public void Logout()
        {
            // Выполните все необходимые операции для завершения сеанса пользователя.
            _isAuthenticated = false;
            //username = null;
            _instance = null;
            _client = null;
        }
    }
}
