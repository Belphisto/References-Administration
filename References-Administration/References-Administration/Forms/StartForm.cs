using System;
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
        private DataBaseController dataBase;
        private Session session;
        public StartForm()
        {
            InitializeComponent();
            
            session = Session.GetInstance();

            labelLogin.Visible = true;
            labelPassword.Visible = true;
            LogintextBox.Visible = true;
            PasswordtextBox.Visible = true;
            PasswordtextBox.PasswordChar = '*';
            authorizationButton.Visible = true;
            buttonLogOut.Visible = false;
            labelCurrentSession.Visible = false;
        }

        private void Administration_Click(object sender, EventArgs e)
        {
           var department = new DepartmentForm();
           department.ShowDialog(this);
        }

        private void Directory_Click(object sender, EventArgs e)
        {
            var directory = new ClientsForm();
            directory.ShowDialog(this);
        }

        private void authorizationButton_Click(object sender, EventArgs e)
        {
            dataBase = new DataBaseController();
            string login = LogintextBox.Text;
            string password_hash = ClientController.HashPassword(PasswordtextBox.Text);
            Client currentClient = new Client();
            
                currentClient = Client.Read(dataBase.Connection, login);
                if (currentClient != null && currentClient.PasswordHash == password_hash)
                {
                    session.Login(currentClient);
                    labelLogin.Visible = false;
                    labelPassword.Visible = false;
                    LogintextBox.Visible = false;
                    PasswordtextBox.Visible = false;
                    authorizationButton.Visible = false;
                    buttonLogOut.Visible = true;
                    labelCurrentSession.Visible = true;
                    labelCurrentSession.Text = $"Вы вошли как {session.GetName()}"; 
                }
                else
                {
                    MessageBox.Show($"Неверный логин или пароль! \n ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            session.Logout();
            labelLogin.Visible = true;
            labelPassword.Visible = true;
            LogintextBox.Visible = true;
            PasswordtextBox.Visible = true;
            authorizationButton.Visible = true;
            buttonLogOut.Visible = false;
            labelCurrentSession.Visible = false;
            LogintextBox.Text = string.Empty;
            PasswordtextBox.Text = string.Empty;

        }
    }
}
