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

namespace LabSeven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum StockLevel {Low,Normal,Overstocked};
        NORTHWNDEntities db = new NORTHWNDEntities();

        StockLevel stock;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        public void InitializeData()
        {
            LstBxStockLevel.ItemsSource = Enum.GetValues(typeof(StockLevel));
            LstBxSuppliers.ItemsSource = db.Suppliers.Select(s => s.CompanyName).ToList();
            LstBxCountry.ItemsSource = db.Suppliers.Select(r => r.Country).ToList();
            LstBxProducts.ItemsSource = db.Products.Select(p => p.ProductName).ToList();
        }

        private void LstBxStockLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stock = (StockLevel)LstBxStockLevel.SelectedIndex;

            List<Product> query2 = db.Products.ToList();

            switch (stock)
            {
                case StockLevel.Low:
                    query2 = query2.Where(p => p.UnitsInStock <= 50).ToList();
                    break;

                case StockLevel.Normal:
                    query2 = query2.Where(p => p.UnitsInStock > 50 && p.UnitsInStock <= 100).ToList();
                    break;

                case StockLevel.Overstocked:
                    query2 = query2.Where(p => p.UnitsInStock > 100).ToList();
                    break;

                default:
                    break;
            }

            LstBxProducts.ItemsSource = null;
            LstBxProducts.ItemsSource = query2.Select(p => p.ProductName);
        }

        private void LstBxSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Product> query2 = db.Products.ToList();

            if (LstBxSuppliers.SelectedValue != null)
            {
                query2 = query2.Where(p => p.Supplier.CompanyName == LstBxSuppliers.SelectedValue as string).ToList();
            }
            LstBxProducts.ItemsSource = null;
            LstBxProducts.ItemsSource = query2.Select(p => p.ProductName);
        }

        private void LstBxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
            List<Product> query2 = db.Products.ToList();

            if (LstBxCountry.SelectedValue != null)
                query2 = query2.Where(p => p.Supplier.Country == LstBxCountry.SelectedValue as string).ToList();
            LstBxProducts.ItemsSource = null;
            LstBxProducts.ItemsSource = query2.Select(p => p.ProductName);
        }

        private void Filter()
        {


            List<Product> query2 = db.Products.ToList();
            switch (stock)
            {
                case StockLevel.Low:
                    query2 = query2.Where(p => p.UnitsInStock <= 50).ToList();
                    break;

                case StockLevel.Normal:
                    query2 = query2.Where(p => p.UnitsInStock > 50 && p.UnitsInStock <= 100).ToList();
                    break;

                case StockLevel.Overstocked:
                    query2 = query2.Where(p => p.UnitsInStock > 100).ToList();
                    break;

                default:
                    break;
            }

            if (LstBxSuppliers.SelectedValue != null)
            {
                query2 = query2.Where(p => p.Supplier.CompanyName == LstBxSuppliers.SelectedValue as string).ToList();
            }


            if(LstBxCountry.SelectedValue != null)
            query2 = query2.Where(p => p.Supplier.Country == LstBxCountry.SelectedValue as string).ToList();

            LstBxProducts.ItemsSource = null;
            LstBxProducts.ItemsSource = query2.Select(p => p.ProductName);
        }
    }
}
