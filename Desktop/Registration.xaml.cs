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
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void Имя_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Имя.Text == "Введите имя пользователя") { Имя.Foreground = this.Foreground; }
            else if (Имя.Text == "Имя не должно быть меньше 3 символов") { Имя.Foreground = Brushes.Red; }
            else Имя.Foreground = Brushes.Black;
        }
        private void EmailValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Class.ValidateEmail(txt.Text))
            {
                Class.ShowError(txt, "Неверный формат почты");
            }
        }

        private void PasswordValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Class.ValidatePassword(txt.Text))
            {
                Class.ShowError(txt, "Пароль не должен быть меньше 6 символов");
            }
        }

        private void NameValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Class.ValidateName(txt.Text))
            {
                Class.ShowError(txt, "Имя не должно быть меньше 3 символов");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var LogIn = new MainWindow();
            LogIn.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Имя.Text == "Имя не должно быть меньше 3 символов" || Имя.Text == "Введите имя пользователя") { MessageBox.Show("Неверно введены данные"); }
            else if (Пароль.Text == "Пароль не должен быть меньше 6 символов" || Пароль.Text == "Введите пароль") { MessageBox.Show("Неверно введены данные"); }
            else if (email.Text == "Неверный формат почты" || email.Text == "exam@yandex.ru") { MessageBox.Show("Неверно введены данные"); }
            else if (Повтор.Text == "Повторите пароль") { MessageBox.Show("Неверно введены данные"); }
            else
            {
                var MainEmpty = new MainEmpty();
                MainEmpty.Show();
                this.Close();
            }

        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (email.Text == "exam@yandex.ru") { email.Foreground = this.Foreground; }
            else if (email.Text == "Неверный формат почты") { email.Foreground = Brushes.Red; }
            else email.Foreground = Brushes.Black;
        }

        private void Пароль_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Пароль.Text == "Введите пароль") { Пароль.Foreground = this.Foreground; }
            else if (Пароль.Text == "Пароль не должен быть меньше 6 символов") { Пароль.Foreground = Brushes.Red; }
            else Пароль.Foreground = Brushes.Black;
        }

        private void Повтор_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Повтор.Text != Пароль.Text) { }
            if (Повтор.Text == "Повторите пароль") { Повтор.Foreground = this.Foreground; }
            else Повтор.Foreground = Brushes.Black;
        }
    }
}
