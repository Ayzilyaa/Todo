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
    /// Логика взаимодействия для Историяя.xaml
    /// </summary>
    public partial class Историяя : Window
    {
        private List<TaskItem> _completedTasks;
        public string UserName => CurrentUser.Name;
        public Историяя()
        {
            InitializeComponent();
            this.DataContext = this;
            FilterCompletedTasksByCategory("Дом");

        }
        private void LoadAllCompletedTasks()
        {
            _completedTasks = TaskManager.AllTasks.Where(t => t.IsCompleted).ToList();
            History.ItemsSource = _completedTasks;
        }

        private void FilterCompletedTasksByCategory(string category)
        {
            var filteredTasks = TaskManager.AllTasks
                .Where(t => t.IsCompleted && t.Category == category)
                .ToList();
            History.ItemsSource = filteredTasks;
        }

        private void DomButton_Click(object sender, RoutedEventArgs e)
        {
            FilterCompletedTasksByCategory("Дом");
        }

        private void RabotaButton_Click(object sender, RoutedEventArgs e)
        {
            FilterCompletedTasksByCategory("Работа");
        }

        private void UchebaButton_Click(object sender, RoutedEventArgs e)
        {
            FilterCompletedTasksByCategory("Учеба");
        }

        private void OtdihButton_Click(object sender, RoutedEventArgs e)
        {
            FilterCompletedTasksByCategory("Отдых");
        }

        //кнопка Задачи
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }
        
        private void СменаФото_Click(object sender, RoutedEventArgs e)
        {


        }
        private void History_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (History.SelectedItem is TaskItem selectedTask)
            {
                ShowTaskDetails(selectedTask);
            }
        }
        private void ShowTaskDetails(TaskItem task)
        {
            DetailTime.Text = task.DisplayTime;
            DetailDate.Text = task.FormattedDate;
            DetailDescription.Text = string.IsNullOrEmpty(task.Description)
        ? "Описание отсутствует"
        : task.Description;
        }
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            log.Show();
            this.Close();

        }
    }
}
