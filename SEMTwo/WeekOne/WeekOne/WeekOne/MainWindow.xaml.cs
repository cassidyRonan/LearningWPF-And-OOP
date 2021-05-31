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
using Newtonsoft.Json;

namespace WeekOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Band> BandList;
        List<string> genres;

        public MainWindow()
        {
            InitializeComponent();

            #region ListCreation
            BandList = new ObservableCollection<Band>();
            BandList.Add(new RockBand("Led Zepplin", "1968", "Robert Plant,Jimmy Page,John Bonham", 
            new List<Album>()
            {
                new Album("Stairway",1968),
                new Album("Heavan",1968),
                new Album("Best Hits",1968)
            }
            ));

            BandList.Add(new PopBand("The Beatles", "1960", "John Lennon,Paul McCartney,Ringo Starr",
            new List<Album>()
            {
                new Album("Bugs",1960),
                new Album("Liver",1960),
                new Album("2000",1960)
            }));

            BandList.Add(new IndieBand("Smash Mouth", "1994", "Steve Harwell, Greg Camp, Paul De Lisle",
            new List<Album>()
            {
                new Album("Hand",1994),
                new Album("Shrek",1994),
                new Album("Brawl",1994)
            }));

            BandList.Add(new PopBand("ABBA", "1972","Agnetha Fältskog,Björn Ulvaeus,Benny Andersson,Anni-Frid Lyngstad",
            new List<Album>()
            {
                new Album("Mamma!",1972),
                new Album("Dance",1972),
                new Album("20 Years",1972)
            }));

            BandList.Add(new RockBand("The Clash", "1976", "Joe Strummer,Mick Jones,Paul Simonon",
            new List<Album>()
            {
                new Album("Decisions",1976),
                new Album("Stranger Things",1976),
                new Album("Clashing Steel",1976)
            }));

            BandList.Add(new RockBand("Deep Purple", "1968", "Ritchie Blackmore,Ian Gillan,Jon Lord",
            new List<Album>()
            {
                new Album("Red + Blue",1968),
                new Album("Lighter Purple",1968),
                new Album("Purple is purple",1968)
            }));

            Sort();
            
            lstBxBands.ItemsSource = BandList;
            #endregion

            genres = new List<string>();

            genres.Add("All");
            foreach (var item in BandList)
            {
                bool exists = false;
                string genre = "";
                genre = item.GetType().ToString();
                genre = genre.Remove(0,8);
                genre = genre.Remove(genre.Length - 4, 4);

                foreach (var g in genres)
                {
                    if(genre.ToUpper() == g.ToUpper())
                    {
                        exists = true;
                    }
                }

                if (!exists)
                    genres.Add(genre);

                cmbBxGenre.ItemsSource = genres;
                cmbBxGenre.SelectedIndex = 0;

                GenreSort();
            }
        }

        private void LstBxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band band = lstBxBands.SelectedItem as Band;

            if (band != null)
            {
                txbkBandInfo.Text = band.BandInfo();
                lstBxAlbums.ItemsSource = band.Albums;
            }
        }

        private void Sort()
        {
            
            BandList = new ObservableCollection<Band>(BandList.OrderBy(activityComparer => activityComparer, new BandSort()));
        }

        public void GenreSort()
        {
            ObservableCollection<Band> temp = new ObservableCollection<Band>();
                Debug.WriteLine(cmbBxGenre.Text);

            if (cmbBxGenre.Text != "All")
            {
                foreach (var band in BandList)
                {
                    if (band.ToString().Contains(cmbBxGenre.Text))
                    {
                        temp.Add(band);
                    }
                }

                lstBxBands.ItemsSource = temp;
            }
            else
            {
                lstBxBands.ItemsSource = BandList;
            }
        }

        private void CmbBxGenre_DropDownClosed(object sender, EventArgs e)
        {
            GenreSort();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Band temp = lstBxBands.SelectedItem as Band;
            
            if(temp != null)
            {
                string output = JsonConvert.SerializeObject(temp);
                string path = @"BandName.txt";

                using(StreamWriter sr = File.AppendText(path) )
                {
                    sr.WriteLine(output);
                    sr.Close();
                }
            }
        }
    }
}
