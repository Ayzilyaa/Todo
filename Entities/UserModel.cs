using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    
    public class UserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public UserModel(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
