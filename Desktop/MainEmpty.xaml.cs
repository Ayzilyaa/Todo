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
using Todo;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainEmpty.xaml
    /// </summary>
    public partial class MainEmpty : Window
    {
        public MainEmpty()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Создание_задачи createWindow = new Создание_задачи();
            createWindow.Owner = this;
            createWindow.ShowDialog();

            if (createWindow.NewTask != null)
            {
                TaskManager.AllTasks.Add(createWindow.NewTask);
                Main mainWindow = new Main();
                mainWindow.Show();
                this.Close();
            }
        }
        private void Photo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Photo.ContextMenu.IsOpen = true;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            log.Show();
            this.Close();
        }
        private void ChangeProfilePhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
