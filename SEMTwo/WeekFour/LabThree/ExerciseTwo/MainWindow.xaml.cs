using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ExerciseTwo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Band[] bands = new Band[6];

        public MainWindow()
        {
            InitializeComponent();
            bands = new Band[] {
            new Band("Arctic Monkeys", @"images\articmonkeys.jpg"),
            new Band("Beatles", @"images\beatles.jpg"),
            new Band("Foo Figthers", @"images\foo.jpg"),
            new Band("Green Day", @"images\greenday.jpg"),
            new Band("Rolling Stones", @"images\rollingstones.jpg"),
            new Band("The Strokes", @"images\strokes.jpg") };

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lstBxBands.ItemsSource = bands;
            /*
            Band temp = lstBxBands.SelectedItem as Band;
            if (temp != null)
            {

            }*/
        }
    }
}
