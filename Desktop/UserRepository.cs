using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop
{
    public static class CurrentUser
    {
        public static string Name { get; set; } = "пользователь";
        public static string Login { get; set; }
        public static string Email { get; set; }
    }
    public class UserRepository
    {
        private static List<UserModel> registredUser = new List<UserModel>();

        public bool UserRegistration(string login, string password, string email)
        {
            if (registredUser.Exists(l => l.Login == login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return false;
            }

            if (registredUser.Exists(l => l.Email == email))
            {
                MessageBox.Show("Пользователь с такой почтой уже существует");
                return false;
            }

            var newUser = new UserModel(login, password, email);
            registredUser.Add(newUser);
            return true;
        }
        public UserModel UserAuthenticate(string email, string password)
        {
            var user = registredUser.Find(l => l.Email == email && l.Password == password);
            if (user == null)
            {
                throw new Exception("Неверная почта или пароль");
            }
            return user;
        }
    }
}
