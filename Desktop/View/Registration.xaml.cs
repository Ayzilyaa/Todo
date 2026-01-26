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

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        UserRepository UR = new UserRepository();
        Class Validate = new Class();
        public Registration()
        {
            InitializeComponent();
        }

        private void Имя_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Имя.Text == "введите имя пользователя") { Имя.Foreground = this.Foreground; }
            else if (Имя.Text == "имя не должно быть меньше трех символов") { Имя.Foreground = Brushes.Red; }
            else Имя.Foreground = Brushes.Black;
        }
        private void EmailValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Class.ValidateEmail(txt.Text))
            {
                Class.ShowError(txt, "неверный формат почты");
            }
        }

        private void PasswordValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Class.ValidatePassword(txt.Text))
            {
                Class.ShowError(txt, "пароль не должен быть меньше шести символов");
            }
        }

        private void NameValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Class.ValidateName(txt.Text))
            {
                Class.ShowError(txt, "имя не должно быть меньше трех символов");
            }
        }

        private void BackToLogIn(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as LogIn;
            if (window != null)
            {
                window.MainFrame.Visibility = Visibility.Collapsed;
                window.LoginFormGrid.Visibility = Visibility.Visible;
                window.MainFrame.Navigate(null);
            }

        }

        private void Registation(object sender, RoutedEventArgs e)
        {
            string email = TBEmail.Text.Trim().ToLower();
            string password = Пароль.Text.Trim();
            string repeatPassword = Повтор.Text.Trim();
            string login = Имя.Text.Trim();

            if (Имя.Text == "имя не должно быть меньше трех символов" || Имя.Text == "введите имя пользователя") { MessageBox.Show("неверно введены данные"); }
            else if (Пароль.Text == "пароль не должен быть меньше шести символов" || Пароль.Text == "введите пароль") { MessageBox.Show("неверно введены данные"); }
            else if (TBEmail.Text == "неверный формат почты" || TBEmail.Text == "ayz@yandex.ru") { MessageBox.Show("неверно введены данные"); }
            else if (Повтор.Text == "повторите пароль") { MessageBox.Show("неверно введены данные"); }
            else if (UR.UserRegistration(login, password, email))
            {
                CurrentUser.Name = login;
                CurrentUser.Login = login;
                CurrentUser.Email = email;
                NavigationService?.Navigate(new Main_Empty());
            }
            else
            {
                return;
            }

        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBEmail.Text == "ayz@yandex.ru") { TBEmail.Foreground = this.Foreground; }
            else if (TBEmail.Text == "неверный формат почты") { TBEmail.Foreground = Brushes.Red; }
            else TBEmail.Foreground = Brushes.Black;
        }

        private void Пароль_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Пароль.Text == "введите пароль") { Пароль.Foreground = this.Foreground; }
            else if (Пароль.Text == "пароль не должен быть меньше шести символов") { Пароль.Foreground = Brushes.Red; }
            else Пароль.Foreground = Brushes.Black;
        }

        private void Повтор_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Повтор.Text != Пароль.Text) { }
            if (Повтор.Text == "повторите пароль") { Повтор.Foreground = this.Foreground; }
            else Повтор.Foreground = Brushes.Black;
        }
    }
}