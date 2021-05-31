using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CA1_Sem4
{
    /// <summary>
    /// Interaction logic for TaskEdit.xaml
    /// </summary>
    public partial class TaskEdit : Window
    {
        Task editTask;

        public TaskEdit(Task task)
        {
            InitializeComponent();
            editTask = task;

            CmbBxCategory.ItemsSource = Enum.GetValues(typeof(TaskCategory));
            CmbBxPriority.ItemsSource = Enum.GetValues(typeof(PriorityLevel));
            CmbBxUser.ItemsSource = MainWindow.UserList;

            TxtBkTitle.Text = editTask.Title;
            TxtBkDescription.Text = editTask.Description;
            CmbBxCategory.SelectedIndex = (int)editTask.Category;
            DatePckEvent.SelectedDate = editTask.DueDate;
            CmbBxPriority.SelectedIndex = (int)editTask.Priority;
            foreach (string s in editTask.Labels)
            {
                TxtBkLabels.Text += (s + ",");
            }
            TxtBkLabels.Text.TrimEnd(' ', ',');
            CmbBxUser.SelectedIndex = MainWindow.UserList.IndexOf(editTask.Responsibility);
            ChkBxComplete.IsChecked = editTask.Completed == "Completed" ? true: false;


            
        }

        private void BtnApplyChangesEvent_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.taskList.Remove(editTask);

            TaskCategory category;
            PriorityLevel priority;
            switch (CmbBxCategory.Text)
            {
                case "Personal":
                    category = TaskCategory.Personal;
                    break;

                case "School":
                    category = TaskCategory.School;
                    break;

                case "Work":
                    category = TaskCategory.Work;
                    break;

                case "Birthday":
                    category = TaskCategory.Birthday;
                    break;

                default:
                    category = TaskCategory.Misc;
                    break;
            }
            switch (CmbBxCategory.Text)
            {
                case "Low":
                    priority = PriorityLevel.Low;
                    break;

                case "Medium":
                    priority = PriorityLevel.Medium;
                    break;

                case "High":
                    priority = PriorityLevel.High;
                    break;

                case "Urgent":
                    priority = PriorityLevel.Urgent;
                    break;

                default:
                    priority = PriorityLevel.Low;
                    break;
            }

            string temp = "Error";
            if(ChkBxComplete.IsChecked == true)
            {
                temp = "Completed";
            }
            else
            {
                temp = "Not Completed";
            }
            Debug.WriteLine(temp);
            MainWindow.taskList.Add(new Task(TxtBkTitle.Text, TxtBkDescription.Text, category, DatePckEvent.DisplayDate, priority, null, TxtBkLabels.Text, CmbBxUser.Text,temp));
            TaskPage.TaskRefresh();
            Debug.WriteLine("Apply Change");
            this.Close();
        }
    }
}
