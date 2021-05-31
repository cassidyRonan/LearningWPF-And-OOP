using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Threading;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace CA1_Sem4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public ObservableCollection<Task> taskList = new ObservableCollection<Task>();
        static public ObservableCollection<string> UserList = new ObservableCollection<string>();
        static public ObservableCollection<string> LabelList = new ObservableCollection<string>();
        DispatcherTimer dt = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            InitializeApp();
            
        }

        private void InitializeApp()
        {
            foreach (var task in taskList)
            {
                if (!UserList.Contains(task.Responsibility))
                {
                    UserList.Add(task.Responsibility);
                }
            }
            UserList.Add("None");

            CmbBxCategory.ItemsSource = Enum.GetValues(typeof(TaskCategory));
            CmbBxPriority.ItemsSource = Enum.GetValues(typeof(PriorityLevel));
            CmbBxUser.ItemsSource = UserList;
            CmbBxCategory.SelectedIndex = 0;
            CmbBxPriority.SelectedIndex = 0;
            CmbBxUser.SelectedIndex = 0;
            LabelList.Add("None");
            UpdateList();

            //Filters
            CmbBxFilterCategory.ItemsSource = Enum.GetValues(typeof(TaskCategory));
            CmbBxFilterPriority.ItemsSource = Enum.GetValues(typeof(PriorityLevel));
            CmbBxFilterUser.ItemsSource = UserList;
            CmbBxFilterLabelOne.ItemsSource = LabelList;
            CmbBxFilterLabelTwo.ItemsSource = LabelList;
            CmbBxFilterLabelThree.ItemsSource = LabelList;

            CmbBxFilterCategory.SelectedIndex = 0;
            CmbBxFilterPriority.SelectedIndex = 0;
            CmbBxFilterUser.SelectedIndex = 0;
            CmbBxFilterLabelOne.SelectedIndex = 0;
            CmbBxFilterLabelTwo.SelectedIndex = 0;
            CmbBxFilterLabelThree.SelectedIndex = 0;

            TxtBxUserNameInput.Text = "Enter User Name Here";
            TxtBxUserNameInput.Foreground = Brushes.Gray;

            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();  
        }

        private void BtnAddEvent_Click(object sender, RoutedEventArgs e)
        {
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
            if (TxtBkTitle.Text != null && TxtBkDescription.Text != null && DatePckEvent.SelectedDate != null && TxtBkLabels.Text != null && CmbBxUser.Text != null) 
            {
                taskList.Add(new Task(
                    TxtBkTitle.Text, TxtBkDescription.Text, category, DatePckEvent.SelectedDate.HasValue == true ? (DateTime)DatePckEvent.SelectedDate : new DateTime(),
                    priority,null, TxtBkLabels.Text, CmbBxUser.Text));
            }

            UpdateList();
        }

        public void dt_Tick(object sender, EventArgs e)
        {
            LblClock.Content = DateTime.Now.ToLongTimeString();
        }

        //User List Field
        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if(TxtBxUserNameInput.Text != "Enter User Name Here" || TxtBxUserNameInput.Text != "" || TxtBxUserNameInput.Text != " ")
            {
                UserList.Add(TxtBxUserNameInput.Text);
            }
            LstBxUsers.ItemsSource = null;
            LstBxUsers.ItemsSource = UserList;
            TxtBxUserNameInput.Text = "Enter User Name Here";
            TxtBxUserNameInput.Foreground = Brushes.Gray;
        }

        private void BtnRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if(LstBxUsers.SelectedItem != null)
            {
                UserList.Remove(LstBxUsers.SelectedItem as string);
                LstBxUsers.ItemsSource = null;
                LstBxUsers.ItemsSource = UserList;
            }
        }


        //Save and loading of data
        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            string JSON = JsonConvert.SerializeObject(taskList);
            SaveFileDialog saveFile = new SaveFileDialog();

            if(saveFile.ShowDialog() == true)
            {
                File.WriteAllText(saveFile.FileName,JSON);
            }
        }

        private void BtnLoadData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == true)
            {
                var fileStream = openFile.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string content = reader.ReadToEnd();
                    taskList = JsonConvert.DeserializeObject<ObservableCollection<Task>>(content);
                }

                foreach (var task in taskList)
                {
                    if (!UserList.Contains(task.Responsibility))
                    {
                        UserList.Add(task.Responsibility);
                    }
                }
                LstBxUsers.ItemsSource = null;
                LstBxUsers.ItemsSource = UserList;
                UpdateList();
                TaskPage.TaskRefresh();
            }
            else
            {
                throw new Exception("Path Not Found");
            }
        }

        //Search bar
        private void TxtBxTaskSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if(TxtBxTaskSearch.Text == "Search")
            {
                TxtBxTaskSearch.Text = "";
            }            
        }

        private void TxtBxTaskSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtBxTaskSearch.Text.ToUpper() == "" || TxtBxTaskSearch.Text.ToUpper() == " ")
            {
                TaskPage.lstbxTasks.ItemsSource = null;
                TaskPage.lstbxTasks.ItemsSource = taskList;
            }
            else
            {
                ObservableCollection<Task> temp = new ObservableCollection<Task>();
                foreach (var tsk in taskList)
                {
                    if (tsk.Description.ToUpper().Contains(TxtBxTaskSearch.Text.ToUpper()) || tsk.Title.ToUpper().Contains(TxtBxTaskSearch.Text.ToUpper()))
                    {
                        temp.Add(tsk);
                    }
                }

                if (TaskPage.lstbxTasks != null)
                {
                    TaskPage.lstbxTasks.ItemsSource = null;
                    TaskPage.lstbxTasks.ItemsSource = temp;
                }
            }
        }

        private void BtnFilterSearch_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Task> TempList = new ObservableCollection<Task>();
            foreach (var tsk in taskList)
            {
                #region Nested If - Working
                //if( (TaskCategory)CmbBxFilterCategory.SelectedIndex == tsk.Category || (TaskCategory)CmbBxFilterCategory.SelectedIndex == TaskCategory.Misc)
                //{
                //    if ((PriorityLevel)CmbBxFilterPriority.SelectedValue == tsk.Priority || (PriorityLevel)CmbBxFilterPriority.SelectedValue == PriorityLevel.None)
                //    {
                //        if (CmbBxFilterUser.SelectedValue as string == tsk.Responsibility || CmbBxFilterUser.SelectedValue as string == "None")
                //        {
                //            if (DatePckStartDate.SelectedDate <= tsk.DueDate && DatePckEndDate.SelectedDate >= tsk.DueDate || DatePckStartDate.SelectedDate <= tsk.DueDate && DatePckEndDate.SelectedDate == null
                //                || DatePckStartDate.SelectedDate == null && DatePckEndDate.SelectedDate >= tsk.DueDate || DatePckStartDate.SelectedDate == null && DatePckEndDate.SelectedDate == null)
                //            {
                //                if (tsk.Labels.Contains(CmbBxFilterLabelOne.SelectedValue as string) || CmbBxFilterLabelOne.SelectedValue as string == "None")
                //                {
                //                    if (tsk.Labels.Contains(CmbBxFilterLabelTwo.SelectedValue as string) || CmbBxFilterLabelTwo.SelectedValue as string == "None")
                //                    {
                //                        if (tsk.Labels.Contains(CmbBxFilterLabelThree.SelectedValue as string) || CmbBxFilterLabelThree.SelectedValue as string == "None")
                //                        {
                //                            TempList.Add(tsk);
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion

                //Filter logic
                if (((TaskCategory)CmbBxFilterCategory.SelectedIndex == tsk.Category || (TaskCategory)CmbBxFilterCategory.SelectedIndex == TaskCategory.Misc)
                    && ((PriorityLevel)CmbBxFilterPriority.SelectedValue == tsk.Priority || (PriorityLevel)CmbBxFilterPriority.SelectedValue == PriorityLevel.None)
                    && (CmbBxFilterUser.SelectedValue as string == tsk.Responsibility || CmbBxFilterUser.SelectedValue as string == "None")
                    && (DatePckStartDate.SelectedDate <= tsk.DueDate && DatePckEndDate.SelectedDate >= tsk.DueDate || DatePckStartDate.SelectedDate <= tsk.DueDate && DatePckEndDate.SelectedDate == null
                    || DatePckStartDate.SelectedDate == null && DatePckEndDate.SelectedDate >= tsk.DueDate || DatePckStartDate.SelectedDate == null && DatePckEndDate.SelectedDate == null)
                    && (tsk.Labels.Contains(CmbBxFilterLabelOne.SelectedValue as string) || CmbBxFilterLabelOne.SelectedValue as string == "None")
                    && (tsk.Labels.Contains(CmbBxFilterLabelTwo.SelectedValue as string) || CmbBxFilterLabelTwo.SelectedValue as string == "None")
                    && (tsk.Labels.Contains(CmbBxFilterLabelThree.SelectedValue as string) || CmbBxFilterLabelThree.SelectedValue as string == "None"))
                {
                    TempList.Add(tsk);
                }
                TaskPage.lstbxTasks.ItemsSource = null;
                TaskPage.lstbxTasks.ItemsSource = TempList;

            }
        }

        //Update label methods
        public void UpdateList()
        {
            foreach (var task in taskList)
            {
                foreach (var lbl in task.Labels)
                {
                    if (!LabelList.Contains(lbl))
                        LabelList.Add(lbl);
                }
            }
        }

        private void TxtBxUserNameInput_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtBxUserNameInput.Text = "";
            TxtBxUserNameInput.Foreground = Brushes.Black;
        }
    }
}

