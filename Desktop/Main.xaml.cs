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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public List<TaskItem> Tasks { get; set; }
        private string _currentCategory = "Дом";
        private TaskItem _selectedTask;
        public string UserName => CurrentUser.Name;

        public Main()
        {
            InitializeComponent();
            Tasks = new List<TaskItem>();
            TasksListBox.ItemsSource = Tasks;
            this.DataContext = this;
            FilterTasksByCategory("Дом");
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Создание_задачи createWindow = new Создание_задачи();
            createWindow.Owner = this;
            createWindow.ShowDialog();

            if (createWindow.NewTask != null)
            {
                TaskManager.AllTasks.Add(createWindow.NewTask);
                if (_currentCategory == createWindow.NewTask.Category)
                {
                    FilterTasksByCategory(_currentCategory);
                }


            }
        }
        private void FilterTasksByCategory(string category)
        {
            _currentCategory = category;

            Tasks.Clear();
            var filteredTasks = TaskManager.AllTasks.Where(t => t.Category == category).ToList();
            Tasks.AddRange(filteredTasks);

            TasksListBox.Items.Refresh();
        }


        private void TasksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedTask = TasksListBox.SelectedItem as TaskItem;

            if (_selectedTask != null)
            {
                ShowTaskDetails(_selectedTask);
            }
        }
        private void ShowTaskDetails(TaskItem task)
        {
            var label = FindName("DetailTitle") as Label;
            if (label != null) label.Content = task.Title;

            DetailTime.Text = $"{task.Time:hh\\:mm}";
            DetailDate.Text = task.Date.ToString("dd MMMM yyyy");
            DetailDescription.Text = task.Description;
            CompleteButton.Content = task.IsCompleted ? "Не выполнено" : "Готово";
            DetailDate.Text = task.FormattedDate;
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTask != null)
            {
                _selectedTask.IsCompleted = !_selectedTask.IsCompleted;

                ShowTaskDetails(_selectedTask);
                TasksListBox.Items.Refresh();
            }
        }
        private void DomButton_Click(object sender, RoutedEventArgs e)
        {
            FilterTasksByCategory("Дом");
        }

        private void RabotaButton_Click(object sender, RoutedEventArgs e)
        {
            FilterTasksByCategory("Работа");
        }

        private void UchebaButton_Click(object sender, RoutedEventArgs e)
        {
            FilterTasksByCategory("Учеба");
        }

        private void OtdihButton_Click(object sender, RoutedEventArgs e)
        {
            FilterTasksByCategory("Отдых");
        }


        private void Photo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Photo.ContextMenu.IsOpen = true;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTask != null)
            {
                var result = MessageBox.Show($"Удалить задачу '{_selectedTask.Title}'?",
                    "Подтверждение удаления", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    TaskManager.AllTasks.Remove(_selectedTask);
                    Tasks.Remove(_selectedTask);
                    TasksListBox.Items.Refresh();

                    ClearTaskDetails();
                }
            }
        }
        private void ClearTaskDetails()
        {
            var label = FindName("DetailTitle") as Label;
            if (label != null) label.Content = "Заголовок";

            DetailTime.Text = "";
            DetailDate.Text = "";
            DetailDescription.Text = "";
        }
      
        private void СменаФото_Click(object sender, RoutedEventArgs e)
        {


        }
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            log.Show();
            this.Close();

        }
    }
}
