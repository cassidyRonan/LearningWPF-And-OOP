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

namespace AdventureWorks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdventureLiteEntities db = new AdventureLiteEntities();

        public MainWindow()
        {
            InitializeComponent();
            InitializeProgram();
        }

        public void InitializeProgram()
        {
            var query = db.Customers.Where(c => c.SalesOrderHeaders.Any() == true).Select(c => c.CompanyName).OrderBy(c => c);
            LstBxCustomers.ItemsSource = query.ToList();
        }

        private void LstBxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LstBxCustomers.SelectedValue != null)
            {
                string temp = (LstBxCustomers.SelectedValue as string);
                var query = db.SalesOrderHeaders.Where(o => o.Customer.CompanyName == temp).Select(n => n);
                    
                LstBxOrderSummary.ItemsSource = query.ToList();
            }
        }

        private void LstBxOrderSummary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstBxOrderSummary.SelectedValue != null)
            {
                int temp = ((LstBxOrderSummary.SelectedValue as SalesOrderHeader).SalesOrderID);
                Debug.WriteLine("TEMP " + temp);
                var query = db.SalesOrderDetails.Where(od => od.SalesOrderID == temp)
                                                .Select(od =>
                                                new
                                                {
                                                    ProductName = od.Product.Name,
                                                    Price = od.UnitPrice,
                                                    Discount = od.UnitPriceDiscount,
                                                    Quantity = od.OrderQty,
                                                    Total = od.LineTotal
                                                }
                                                );
                //Debug.WriteLine("TEST" + query);
                DgOrderDetails.ItemsSource = query.ToList();
            }
        }
    }

    public class OrderSummary
    {
        public string ProductName;
        public decimal Price;
        public decimal Discount;
        public short Quantity;
        public decimal Total;

        
    }
}
