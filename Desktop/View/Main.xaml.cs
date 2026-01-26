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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
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
            LoadActiveTasks();
        }

        //кнопка +
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var createPage = new Создание_задачи();
            var currentPage = this;

            createPage.Unloaded += (s, args) =>
            {
                if (createPage.NewTask != null)
                {
                    TaskManager.AllTasks.Add(createPage.NewTask);

                    if (_currentCategory == createPage.NewTask.Category)
                    {
                        FilterTasksByCategory(_currentCategory);
                    }

                }

            };
            NavigationService?.Navigate(createPage);
        }
        private void LoadActiveTasks()
        {
            Tasks.Clear();
            var activeTasks = TaskManager.AllTasks.Where(t => !t.IsCompleted).ToList();
            Tasks.AddRange(activeTasks);
            TasksListBox.Items.Refresh();
        }
        private void FilterTasksByCategory(string category)
        {
            _currentCategory = category;

            Tasks.Clear();
            var filteredTasks = TaskManager.AllTasks.Where(t => t.Category == category).ToList();
            Tasks.AddRange(filteredTasks);

            TasksListBox.Items.Refresh();
        }
        private void TaskCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var task = (TaskItem)checkBox.DataContext;
            task.IsCompleted = true;
            LoadActiveTasks();

            MessageBox.Show($"Задача выполнена!");
        }
        private void DomButton_Click(object sender, RoutedEventArgs e)
        {
            _currentCategory = "Дом";
            Tasks.Clear();
            var domTasks = TaskManager.AllTasks.Where(t => t.Category == "Дом" && !t.IsCompleted).ToList();
            Tasks.AddRange(domTasks);
            TasksListBox.Items.Refresh();
        }

        private void RabotaButton_Click(object sender, RoutedEventArgs e)
        {
            _currentCategory = "Работа";
            Tasks.Clear();
            var rabotaTasks = TaskManager.AllTasks.Where(t => t.Category == "Работа" && !t.IsCompleted).ToList();
            Tasks.AddRange(rabotaTasks);
            TasksListBox.Items.Refresh();
        }

        private void UchebaButton_Click(object sender, RoutedEventArgs e)
        {
            _currentCategory = "Учеба";
            Tasks.Clear();
            var uchebaTasks = TaskManager.AllTasks.Where(t => t.Category == "Учеба" && !t.IsCompleted).ToList();
            Tasks.AddRange(uchebaTasks);
            TasksListBox.Items.Refresh();
        }

        private void OtdihButton_Click(object sender, RoutedEventArgs e)
        {
            _currentCategory = "Отдых";
            Tasks.Clear();
            var otdihTasks = TaskManager.AllTasks.Where(t => t.Category == "Отдых" && !t.IsCompleted).ToList();
            Tasks.AddRange(otdihTasks);
            TasksListBox.Items.Refresh();
        }


        private void Photo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Photo.ContextMenu.IsOpen = true;
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

        //кнопка готово
        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListBox.SelectedItem is TaskItem selectedTask)
            {
                selectedTask.IsCompleted = true;
                LoadActiveTasks();
                MessageBox.Show($"Задача выполнена!");
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTask != null)
            {
                var result = MessageBox.Show($"Удалить задачу?",
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
        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as LogIn;
            if (window != null)
            {
                window.MainFrame.Visibility = Visibility.Collapsed;
                window.LoginFormGrid.Visibility = Visibility.Visible;
                window.MainFrame.Navigate(null);
            }

        }
        private void СменаФото_Click(object sender, RoutedEventArgs e)
        {


        }
        //кнопка История
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Историяя());

        }
    }
}
