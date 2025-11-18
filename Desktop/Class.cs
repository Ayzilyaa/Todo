using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop
{
    public class Class
    {
        public static bool ValidateEmail(string email)
        {
            //для проверки email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        //валидация пароля 
        public static bool ValidatePassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 6;

        }

        ////валидация имени
        public static bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 3;

        }

        //Метод для отображения сообщения об ошибке
        public static void ShowError(TextBox textBox, string errorMessage)
        {
            textBox.Text = errorMessage;
        }
    }
}
