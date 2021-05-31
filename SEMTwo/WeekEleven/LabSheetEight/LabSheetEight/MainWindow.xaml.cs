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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabSheetEight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NORTHWNDEntities DB;

        public MainWindow()
        {
            InitializeComponent();
            InitializeApp();
        }

        public void InitializeApp()
        {
            DB = new NORTHWNDEntities();
            
        }

        private void BtnQuery_Click(object sender, RoutedEventArgs e)
        {
            var query = DB.Customers.GroupBy(c => c.Country).OrderByDescending(g => g.Count()).Select(o => new { Country = o.Key, Count = o.Count() });
            DgQuery.AutoGenerateColumns = true;
            DgQuery.ItemsSource = query.ToList();
        }

        private void BtnQueryEx2_Click(object sender, RoutedEventArgs e)
        {
            var query = DB.Customers.Where(c => c.Country == "Italy").Select(c => c);
            DgQueryEx2.ItemsSource = query.ToList();
        }

        private void BtnQueryEx3_Click(object sender, RoutedEventArgs e)
        {
            var query = DB.Products.Where(c => c.UnitsInStock > 0).Select(c => 
            new {
                Product = c.ProductName,
                Available = c.UnitsInStock
            });
            DgQueryEx3.ItemsSource = query.ToList();
        }

        private void BtnQueryEx4_Click(object sender, RoutedEventArgs e)
        {
            var query = DB.Order_Details.Where(od => od.Discount > 0)
                                        .Select(o => new {
                                                            ProductName = o.Product.ProductName,
                                                            DiscountGiven = o.Discount,
                                                            OrderID = o.OrderID
                                                        });
            DgQueryEx4.ItemsSource = query.ToList();
        }

        private void BtnQueryEx5_Click(object sender, RoutedEventArgs e)
        {
            var query = DB.Order_Details.Select(c => c.UnitPrice).Sum();
            TxtBlkQueryEx5.Text = $"The total value of freight for all order is €{Math.Round(query,2)}";
        }

        private void BtnQueryEx6_Click(object sender, RoutedEventArgs e)
        {
            var query = DB.Products.OrderBy(p => p.Category.CategoryName)
                                    .ThenByDescending(p => p.UnitPrice)
                                        .Select(p => new
                                        {
                                            CategoryID = p.CategoryID,
                                            CategoryName = p.Category.CategoryName,
                                            ProductName = p.ProductName,
                                            UnitPrice = p.UnitPrice
                                        });
                                        
            var results = query.ToList();
                                        
            DgQueryEx6.ItemsSource = results;
        }

        private void BtnQueryEx7_Click(object sender, RoutedEventArgs e)
        {
            var query = DB.Customers.OrderByDescending(o => o.Orders.Count)
                                    .Select(o => new { CustomerID = o.CustomerID, NumberOfOrders = o.Orders.Count });
            DgQueryEx7.ItemsSource = query.ToList();
        }

        private void BtnQueryEx8_Click(object sender, RoutedEventArgs e)
        {
            var query = DB.Customers.OrderByDescending(o => o.Orders.Count)
                                    .Select(o => new { CustomerID = o.CustomerID,CompanyName=o.CompanyName, NumberOfOrders = o.Orders.Count });
            DgQueryEx8.ItemsSource = query.ToList();
        }

        private void BtnQueryEx9_Click(object sender, RoutedEventArgs e)
        {
            var query = DB.Customers.Where(c => c.Orders.Count == 0).Select(c => new { c.CompanyName, NumberOfOrders = c.Orders.Count });
            DgQueryEx9.ItemsSource = query.ToList();
        }
    }
}
