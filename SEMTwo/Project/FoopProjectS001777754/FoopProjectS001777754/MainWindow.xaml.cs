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
using System.Windows.Threading;

namespace FoopProjectS001777754
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        public string Time { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();
        }

        public void dt_Tick(object sender, EventArgs e)
        {
            Time = DateTime.Now.ToLongTimeString();
            txblkTimer.Text = Time;
        }

        private void TxBlkRecipeBinder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Uri("RecipeBinder.xaml", UriKind.Relative));
        }

        private void TxBlkShoppingList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Uri("ShoppingList.xaml", UriKind.Relative));
        }

        private void TxBlkMealPlanner_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Uri("MealPlanner.xaml", UriKind.Relative));
        }

        private void TxBlkCookingMode_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Uri("CookingMode.xaml", UriKind.Relative));
        }
    }
}
