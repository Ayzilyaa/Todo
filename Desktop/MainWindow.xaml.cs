using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Desktop.Class;

namespace Desktop
{
    public partial class MainWindow : Window
    {
        UserRepository UR = new UserRepository();
        Class validate = new Class();

        public MainWindow()
        {
            InitializeComponent();
            UR.UserRegistration("AYZILYA", "04052007", "ayzilya@gmail.com");
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            string email = TBEmail.Text.Trim().ToLower();
            string password = TBPassword.Text.Trim();

            //Проверка полей на правильность с последующий входом

            if (!Class.ValidateEmail(email))
            {
                MessageBox.Show("некорректая почта.", "ошибка");
                return;
            }

            if (!Class.ValidatePassword(password))
            {
                MessageBox.Show("пароль должен содержать шесть символов.", "ошибка");
                return;
            }
            try
            {
                var user = UR.UserAuthenticate(email, password);
                MainEmpty main_Empty = new MainEmpty();
                main_Empty.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ошибка");
                return;
            }
        }

        private void Registation(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void TBEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBEmail.Text == "почта")
            {
                TBEmail.Text = string.Empty;
            }
        }

        private void TBEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBEmail.Text))
            {
                TBEmail.Text = "Почта";
            }
        }
        private void TBPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Text == "Пароль")
            {
                TBPassword.Text = string.Empty;
            }
        }

        private void TBPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPassword.Text))
            {
                TBPassword.Text = "Пароль";
            }
        }
        
    }
}

