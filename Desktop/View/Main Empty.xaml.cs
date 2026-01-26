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
using Todo;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для MainEmpty.xaml
    /// </summary>
    public partial class Main_Empty : Page
    {
        public Main_Empty()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var createPage = new Создание_задачи();
            NavigationService?.Navigate(createPage);
            bool taskCreated = false;
            createPage.Unloaded += (s, args) =>
            {
                if (createPage.NewTask != null)
                {
                    TaskManager.AllTasks.Add(createPage.NewTask);
                    taskCreated = true;
                }
            };
            if (taskCreated)
            {
                NavigationService?.Navigate(new Main());
            }
        }
        private void Photo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Photo.ContextMenu.IsOpen = true;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as LogIn;
            if (window != null)
            {
                window.MainFrame.Visibility = Visibility.Collapsed;
                window.LoginFormGrid.Visibility = Visibility.Visible;
                window.MainFrame.Navigate(null);
            }
        }
        private void ChangeProfilePhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

