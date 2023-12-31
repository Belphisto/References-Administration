﻿using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace References_Administration
{
    public partial class StartForm : Form
    {
        private DataBase _dataBase;
        private Session session;

        public StartForm()
        {
            InitializeComponent();

            session = Session.GetInstance();
            DataStorage dataStorage = new DataStorage();
            _dataBase = new DataBase(dataStorage);

            ShowLoginControls(session.IsAuthenticated);
        }

        private void Administration_Click(object sender, EventArgs e)
        {
            var departmentForm = new DepartmentForm(_dataBase, session);
            departmentForm.ShowDialog(this);
        }

        private void Directory_Click(object sender, EventArgs e)
        {
            var clientsForm = new ClientsForm(_dataBase, session);
            clientsForm.ShowDialog(this);
        }

        private void authorizationButton_Click(object sender, EventArgs e)
        {
            string login = LogintextBox.Text;
            //string passwordHash = ClientController.HashPassword(PasswordtextBox.Text);
            string passwordHash = _dataBase.UserController.HashPassword(PasswordtextBox.Text);
            //Client currentClient = ClientController.Read(dataBase.Connection, login);
            User currentUser = _dataBase.UserController.ReadClient(login);

            if (currentUser != null && currentUser.PasswordHash == passwordHash)
            {
                //session.Login(currentUser, RoleController.GetUserRoles(dataBase.Connection, currentUser));
                session.Login(currentUser, _dataBase.RoleController.GetUserRoles(currentUser));
                ShowLoginControls(session.IsAuthenticated);
                //session.Roles = RoleController.GetUserRoles(dataBase.Connection, currentClient);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            session.Logout();
            ShowLoginControls(session.IsAuthenticated);
        }

        private void buttonEvents_Click(object sender, EventArgs e)
        {
            var eventsForm = new EventsForm(session, _dataBase);
            eventsForm.ShowDialog(this);
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dataBase.DataBaseConntection.CloseConnection();
        }

        private void ShowLoginControls(bool isLogin)
        {
            labelLogin.Visible = !isLogin;
            labelPassword.Visible = !isLogin;
            LogintextBox.Visible = !isLogin;
            PasswordtextBox.Visible = !isLogin;
            PasswordtextBox.PasswordChar = '*';
            authorizationButton.Visible = !isLogin;
            buttonLogOut.Visible = isLogin;
            labelCurrentSession.Visible = isLogin;
            if (isLogin) labelCurrentSession.Text = $"Вы вошли как {session.GetName()} роли {session.Roles.Count}";
            buttonEvents.Visible = isLogin;
            LogintextBox.Text = string.Empty;
            PasswordtextBox.Text = string.Empty;
        }
    }

}
