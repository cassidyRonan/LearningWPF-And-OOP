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

namespace FoopProjectS001777754
{
    /// <summary>
    /// Interaction logic for RecipeBinder.xaml
    /// </summary>
    public partial class RecipeBinder : Page
    {
        List<Recipe> recipes = new List<Recipe>();

        public RecipeBinder()
        {
            InitializeComponent();

            recipes = new List<Recipe>()
            {
                new Recipe("Cake",new TimeSpan(1,30,0),new TimeSpan(0,20,0),"1. Bake The Cake\n2. Eat The Cake",null,
                new List<Ingredient>()
                {
                    new Ingredient(1,Measurement.Cups,"Ginger")
                }),
                new Recipe("Burrito",new TimeSpan(1,10,0),new TimeSpan(0,5,0),"1. Cook food\n2. Eat The food",null),
                new Recipe("Apple",new TimeSpan(0,0,0),new TimeSpan(0,0,0),"1.Eat The Apple",null),
                new Recipe("Sheppard Pie",new TimeSpan(1,0,0),new TimeSpan(0,10,0),"1. Prep The Food\n2. Eat The pie",null),
            };

            lstbxRecipes.ItemsSource = recipes;
        }

        private void TxbxSearchRecipe_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = recipes.Where(r => r.Name.ToLower().Contains(txbxSearchRecipe.Text.ToLower()));
            lstbxRecipes.ItemsSource = filter.ToList();
        }

        private void LstbxRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstbxRecipes.SelectedItem != null)
            {
                Recipe temp = lstbxRecipes.SelectedItem as Recipe;
                TxtBlkMethod.Text = temp.MethodSteps;
                LstBxIngredientList.ItemsSource = null;

                LstBxIngredientList.ItemsSource = temp.Ingredients;

                if(temp.ImageFilePath != null)
                ImgRcp.Source = new BitmapImage(new Uri(($@"{temp.ImageFilePath}")));
            }
            else
            {
                TxtBlkMethod.Text = null;
                LstBxIngredientList.ItemsSource = null;
                ImgRcp.Source = null;
            }
        }

        private void BtnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if(LstBxIngredientList.ItemsSource != null)
            {
                foreach (var item in LstBxIngredientList.ItemsSource)
                {
                    Ingredient temp = item as Ingredient;
                        if (temp.AddMe)
                        {
                            ShoppingList.ShoppingIngredientList.Add(temp);
                        }
                    
                    
                }
            }


        }
    }
}
