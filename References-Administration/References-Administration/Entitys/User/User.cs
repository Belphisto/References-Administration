using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace References_Administration
{
    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public int DepartmentID { get; set; }
        public string PasswordHash { get; set; }
        public string EmailAddress { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {FullName}, Login: {Login}, Email: {EmailAddress}, Department ID: {DepartmentID}";
        }

        public static bool ValidEmail(string email)
        {
            if (new EmailAddressAttribute().IsValid(email))
                return true;
            else return false;
        }
    }
}
