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

namespace OddEven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variables
        int userInput = 0;
        bool noError = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            noError = int.TryParse(txtboxNumInput.Text,out userInput);

            if(userInput % 2 == 0)
            {
                txtblockOutcome.Text = "Number Is Even.";
                txtblockOutcome.Foreground = Brushes.White;
                txtblockOutcome.Background = Brushes.Green;
            }
            else
            {
                txtblockOutcome.Text = "Number Is Odd.";
                txtblockOutcome.Foreground = Brushes.White;
                txtblockOutcome.Background = Brushes.Red;
            }
        }

        
    }
}
