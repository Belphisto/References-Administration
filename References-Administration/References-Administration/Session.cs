﻿using System;
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
        private List<string> _roles;

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

        public List<string> Roles
        {
            get { return _roles; }
        }

        public Client User
        {
            get { return _client; }
        }

        public void Login(Client client)
        {
            // аутентификация успешна
            _isAuthenticated = true;
            this._client = client;
        }

        public void Logout()
        {
            // завершения сеанса пользователя.
            _isAuthenticated = false;
            _instance = null;
            _client = null;
        }
    }
}
