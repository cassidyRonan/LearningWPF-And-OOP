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

namespace FoopProjectS001777754
{
    /// <summary>
    /// Interaction logic for ShoppingList.xaml
    /// </summary>
    public partial class ShoppingList : Page
    {
        public static List<Ingredient> ShoppingIngredientList = new List<Ingredient>();

        public ShoppingList()
        {
            InitializeComponent();
            UpdateList();
        }

        private void LstBxShoppingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LstBxShoppingList_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            UpdateList();
        }

        public void UpdateList()
        {
            var test = ShoppingIngredientList.Select(o => o.Name);
            LstBxShoppingList.ItemsSource = test.GroupBy(t => t).ToList();
        }

    }

    class ShoppingItem
    {
        public string Name;
        public int Count;

        public ShoppingItem(string name,int count)
        {
            Name = name;
            Count = count;
        }

        public override string ToString()
        {
            return string.Format($"{Name} Amount:{Count}");
        }
    }
}
