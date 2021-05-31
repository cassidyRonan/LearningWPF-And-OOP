using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabTen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Collections
        private ObservableCollection<Bike> Products;
        private ObservableCollection<Bike> Cart;
        private ObservableCollection<Bike> Filter;
        private double TotalCost;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Products = new ObservableCollection<Bike>();
            Cart = new ObservableCollection<Bike>();
            Filter = new ObservableCollection<Bike>();
            
            lstbxCart.ItemsSource = Cart;
            lstbxProducts.ItemsSource = Products;
            cmbbxBikeType.ItemsSource = Filter;

            Bike bk1 = new Bike(1234, "Adventure", 200.01, "Male");
            Bike bk2 = new Bike(1235, "Mountain Bike", 256.99, "Female");
            Bike bk3 = new Bike(1236, "Mountain Bike", 256.99, "Male");
            Bike bk4 = new Bike(1233, "Adventure", 200.01, "Female");
            Bike bk5 = new Bike(0728, "Hybrid Bike", 150, "Female");
            Bike bk6 = new Bike(0729, "Hybrid Bike", 150, "Male");

            string[] bikeVariations = { "All", "Male", "Female" };
            cmbbxBikeType.ItemsSource = bikeVariations;
            cmbbxBikeType.SelectedIndex = 0;

            Products.Add(bk5);
            Products.Add(bk6);
            Products.Add(bk4);
            Products.Add(bk1);
            Products.Add(bk2);
            Products.Add(bk3);

 

            TotalCost = 0;
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Bike selectedProduct = lstbxProducts.SelectedItem as Bike;

            if (selectedProduct != null)
            {
                TotalCost += selectedProduct.Cost;
                Cart.Add(selectedProduct);
                txbkTotalCost.Text = $"Total Cost:{TotalCost}";
            }

        }

        private void BtnRemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            Bike selectedProduct = lstbxCart.SelectedItem as Bike;
            

            if (selectedProduct != null)
            {
                TotalCost -= selectedProduct.Cost;
                Cart.Remove(lstbxCart.SelectedItem as Bike);
                txbkTotalCost.Text = $"Total Cost:{TotalCost}";
            }
            else
            {      
                Debug.WriteLine("Error - Null");
                
            }
            Debug.WriteLine("Items Left:" + lstbxCart.Items.Count);
            Debug.WriteLine("Items Left:" + Cart.Count);
        }

        private ObservableCollection<Bike> FilterProducts(string bikeVariation)
        {
            ObservableCollection<Bike> temp = new ObservableCollection<Bike>();
            foreach (Bike b in Products)
            {
                if (b.Gender.Equals(bikeVariation))
                {
                    temp.Add(b);
                }
            }
            return temp;
        }

        

        private void CmbbxBikeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string bikeVariation = cmbbxBikeType.SelectedValue.ToString();
            if (bikeVariation.Equals("All"))
                lstbxProducts.ItemsSource = Products;
            else if (bikeVariation.Equals("Male"))
                lstbxProducts.ItemsSource = FilterProducts("Male");
            else if (bikeVariation.Equals("Female"))
                lstbxProducts.ItemsSource = FilterProducts("Female");
        }
    }
}
