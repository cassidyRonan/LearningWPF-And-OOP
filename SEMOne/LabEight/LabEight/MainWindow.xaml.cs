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

namespace LabEight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variables
        Random rng = new Random();
        int initialRandomNum = 0;
        int secondRandomNum = 0;
        string userChoice = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            initialRandomNum = rng.Next(1, 20);
            txboxInitialNum.Text = $"Initial Number: {initialRandomNum}";
        }

        private void RdbtnBigger_Checked(object sender, RoutedEventArgs e)
        {
            userChoice = "Bigger";
        }

        private void RdbtnSmaller_Checked(object sender, RoutedEventArgs e)
        {
            userChoice = "Smaller";
        }

        private void BtnGuess_Click(object sender, RoutedEventArgs e)
        {
            secondRandomNum = rng.Next(1,20);
            txtboxSecondNum.Text = $"Second Number: {secondRandomNum}";

            #region Win Logic
            if (userChoice == "Bigger" && secondRandomNum > initialRandomNum)
            {
                txtboxOutcome.Text = "You Win!";
            }
            else if (userChoice == "Smaller" && secondRandomNum < initialRandomNum)
            {
                txtboxOutcome.Text = "You Win!";
            }
            else if (userChoice == "Bigger" && secondRandomNum < initialRandomNum)
            {
                txtboxOutcome.Text = "You Lose!";
            }
            else if (userChoice == "Smaller" && secondRandomNum > initialRandomNum)
            {
                txtboxOutcome.Text = "You Lose!";
            }
            #endregion
        }
    }
}
