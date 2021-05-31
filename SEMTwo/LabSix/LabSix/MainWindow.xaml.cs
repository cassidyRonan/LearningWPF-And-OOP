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

namespace LabSix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        NORTHWNDEntities db = new NORTHWNDEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnQuery_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Customers.Select(c => c.CompanyName);
            LstBxCustomersEx1.ItemsSource = query.ToList();
        }

        private void BtnQueryEx2_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Customers.Select(c => c);
            DgCustomersEx2.ItemsSource = query.ToList();
        }

        private void BtnQueryEx3_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Orders.Where(o => o.Customer.City.Equals("London")
                                            || o.Customer.City.Equals("Paris")
                                            || o.Customer.Country.Equals("USA"))
                                 .OrderBy(o => o.Customer.CompanyName)
                                 .Select(o =>
                                     new {
                                         CustomerName = o.Customer.CompanyName,
                                         City = o.Customer.City,
                                         Address = o.ShipAddress
                                     });

            DgCustomersEx3.ItemsSource = query.ToList().Distinct();
        }

        private void BtnQueryEx4_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Products.Where(p => p.Category.CategoryName.Equals("Beverages"))
                                   .OrderByDescending(p => p.ProductID)
                                   .Select(p =>
                                   new
                                   {
                                       p.ProductID,
                                       p.ProductName,
                                       p.Category.CategoryName,
                                       p.UnitPrice
                                   }
                                    );

            DgCustomersEx4.ItemsSource = query.ToList();
        }

        private void BtnQueryEx5_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product()
            {
                ProductName = "Kickapoo Jungle Joy Juice",
                UnitPrice = 12.49m,
                CategoryID = 1
            };

            db.Products.Add(p);
            db.SaveChanges();

            ShowProducts(DgCustomersEx5);
        }

        private void ShowProducts(DataGrid dg)
        {        
            var query = db.Products.Where(p => p.Category.CategoryName.Equals("Beverages"))
                                    .OrderByDescending(p => p.ProductID)
                                    .Select(p =>
                                    new
                                    {
                                        p.ProductID,
                                        p.ProductName,
                                        p.Category.CategoryName,
                                        p.UnitPrice
                                    }
                                        );

            dg.ItemsSource = query.ToList();
            
        }

        private void BtnQueryEx6_Click(object sender, RoutedEventArgs e)
        {
            if ((db.Products.Where(p => p.ProductName.StartsWith("Kick"))
                            .Select(p => p)).FirstOrDefault() == null)
            {
                db.Products.Add(
                new Product()
                {
                    ProductName = "Kickapoo Jungle Joy Juice",
                    UnitPrice = 12.49m,
                    CategoryID = 1
                }
                );
                db.SaveChanges();
            }

            Product p1 = (db.Products
                            .Where(p => p.ProductName.StartsWith("Kick"))
                            .Select(p => p)).First();

            p1.UnitPrice = 100m;

            db.SaveChanges();
            ShowProducts(DgCustomersEx6);
        }

        private void BtnQueryEx7_Click(object sender, RoutedEventArgs e)
        {
            if ((db.Products.Where(p => p.ProductName.StartsWith("Kick"))
                            .Select(p => p)).FirstOrDefault() == null)
            {
                db.Products.Add(
                new Product()
                {
                    ProductName = "Kickapoo Jungle Joy Juice",
                    UnitPrice = 12.49m,
                    CategoryID = 1
                }
                );
                db.SaveChanges();
            }

            var products = db.Products.Where(p => p.ProductName.StartsWith("Kick")).Select(p => p);

            foreach (var item in products)
            {
                item.UnitPrice = 100m;
            }

            db.SaveChanges();
            ShowProducts(DgCustomersEx7);
        }

        private void BtnQueryEx8_Click(object sender, RoutedEventArgs e)
        {
            if ((db.Products.Where(p => p.ProductName.StartsWith("Kick"))
                            .Select(p => p)).FirstOrDefault() == null)
            {
                db.Products.Add(
                new Product()
                {
                    ProductName = "Kickapoo Jungle Joy Juice",
                    UnitPrice = 12.49m,
                    CategoryID = 1
                }
                );
                db.SaveChanges();
            }

            var products = db.Products.Where(p => p.ProductName.StartsWith("Kick")).Select(p => p);

            db.Products.RemoveRange(products);

            db.SaveChanges();
            ShowProducts(DgCustomersEx8);
        }

        private void BtnQueryEx9_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Customers_By_City("London");
            DgCustomersEx9.ItemsSource = query.ToList();
        }
    }
}
