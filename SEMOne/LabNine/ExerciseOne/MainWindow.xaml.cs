using Microsoft.Win32;
using Newtonsoft.Json;
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

namespace ExerciseOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List
        ObservableCollection<Movie> MovieList = new ObservableCollection<Movie>();
        ObservableCollection<Movie> filteredMovies = new ObservableCollection<Movie>();

        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void LstbxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstbxMovies.SelectedItem != null)
            {
                txbkDetails.Text = "Featured: " + lstbxMovies.SelectedItem.ToString();
            }
            else
            {
                txbkDetails.Text = "Featured:";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Movie m1 = new Movie("Gone Girl", Movie.Genre.Drama, 5);
            MovieList.Add(m1);
            lstbxMovies.ItemsSource = MovieList;

            //Set Timer
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            cmbbxRating.ItemsSource =new int[] { 1,2,3,4,5};
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current second
            var date = DateTime.Now;
            txbkTime.Text = string.Format("{0:HH:mm:ss}",date);

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtbxMovieName.Text == null)
                txtbxMovieName.Text = "Unspecified";

            if (txtbxGenreName.Text == null)
                txtbxGenreName.Text = "Unknown";

            if (cmbbxRating.Text == null)
                cmbbxRating.Text = "0";

            if (txtbxMovieName.Text != null && txtbxGenreName.Text !=null && cmbbxRating.Text !=null)
            MovieList.Add(new Movie(txtbxMovieName.Text,Movie.GenreConvert(txtbxGenreName.Text),int.Parse(cmbbxRating.Text)));
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            Movie selectedMovie = lstbxMovies.SelectedItem as Movie;
            if (selectedMovie != null)
                MovieList.Remove(selectedMovie);
            
        }

        //public void ImportFile()
        //{
        //    OpenFileDialog fileDialog = new OpenFileDialog();

        //    fileDialog.DefaultExt = ".txt";
        //    Nullable<bool> result = fileDialog.ShowDialog();

        //    if (result == true)
        //    {
        //        // Open document 
        //        string filename = fileDialog.FileName;

        //        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        //        StreamReader sr = new StreamReader(fs);

        //        string dataInput;
        //        string[] dataSet = new string[3];
        //        dataInput = sr.ReadLine();

        //        while (dataInput != null)
        //        {
        //            dataSet = dataInput.Split(',');
        //            MovieList.Add(new Movie(dataSet[0],
        //                                            Movie.GenreConvert(dataSet[1]),
        //                                            int.Parse(dataSet[2])));
        //            dataInput = sr.ReadLine();
        //            //Debug.WriteLine("Read new line");
        //        }

        //        sr.Close();
        //    }
        //}

        //private void Export()
        //{

        //    SaveFileDialog saveFileDialog = new SaveFileDialog();

        //    saveFileDialog.DefaultExt = ".txt";
        //    Nullable<bool> result = saveFileDialog.ShowDialog();

        //    if (result == true)
        //    {

        //        string filename = saveFileDialog.FileName;
        //        string exportLine;

        //        FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
        //        StreamWriter sw = new StreamWriter(fs);


        //            for (int i = 0; i < lstbxMovies.Items.Count; i++)
        //            {
        //                Movie selectedMovie = lstbxMovies.Items[i] as Movie;
        //                exportLine = string.Format(selectedMovie.Title + ',' + selectedMovie.Type + ',' + selectedMovie.Rating);
        //                sw.WriteLine(exportLine);
        //            }


        //        sw.Close();
        //    }
        //}

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".json";
            Nullable<bool> result = fileDialog.ShowDialog();

            if (result == true)
            {
                string json;
                string filename = fileDialog.FileName;
                using (StreamReader sr = new StreamReader(filename))
                {
                    json = sr.ReadToEnd();
                    MovieList = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(json);
                }

                lstbxMovies.ItemsSource = MovieList;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".json";
            Nullable<bool> result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = saveFileDialog.FileName;

                string json = JsonConvert.SerializeObject(MovieList, Formatting.Indented);
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.Write(json);
                }
            }
        }

        private void TxbxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstbxMovies.ItemsSource = FilterMovies(txbxSearchBar.Text);
        }

        private ObservableCollection<Movie> FilterMovies(string movieName)
        {
            ObservableCollection<Movie> temp = new ObservableCollection<Movie>();
            foreach (Movie m in MovieList)
            {
                if (m.Title.ToUpper().Contains(movieName.ToUpper()))
                {
                    temp.Add(m);
                }
            }
            return temp;
        }
    }
}
