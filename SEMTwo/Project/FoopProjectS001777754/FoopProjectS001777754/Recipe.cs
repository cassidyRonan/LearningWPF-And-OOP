using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoopProjectS001777754
{
    public class Recipe
    {
        //Variables
        public string Name { get; private set; }
        public string ImageFilePath { get; set; }
        public TimeSpan CookingTime { get; private set; }
        public TimeSpan PrepTime { get; private set; }
        public TimeSpan TotalTime { get { return CookingTime + PrepTime; } }
        public string MethodSteps { get; set; }
        public List<Ingredient> Ingredients { get; private set; }
        

        //Constructor
        public Recipe(string name,TimeSpan cookingTime, TimeSpan prepTime,string method,string filePath)
        {
            Name = name;
            CookingTime = cookingTime;
            PrepTime = prepTime;
            MethodSteps = method;
            ImageFilePath = filePath;
        }
        public Recipe(string name, TimeSpan cookingTime, TimeSpan prepTime, string method,string filePath, List<Ingredient> ingredients)
        {
            Name = name;
            CookingTime = cookingTime;
            PrepTime = prepTime;
            MethodSteps = method;
            ImageFilePath = filePath;
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public enum Measurement { Cups,Kilograms,Grams,Litres, Millilitres, Teaspoons,Tablespoons,Gallon,Quarts,Ounces,Pint,Pound,FluidOunces,Units}

    public class Ingredient
    {
        //Enum

        //Variable
        public double Amount { get; set; }
        public Measurement Type { get; set; }
        public string Name { get; set; }
        public bool AddMe { get; set; }

        //Constructor
        public Ingredient(double amount,Measurement type,string IngredientName,bool addMe)
        {
            Amount = amount;
            Type = type;
            Name = IngredientName;
            AddMe = addMe;
        }
        public Ingredient(double amount, Measurement type, string IngredientName)
        {
            Amount = amount;
            Type = type;
            Name = IngredientName;

        }

        public override string ToString()
        {
            return string.Format($"{Name} ");
            //return "testing";
        }
    }
}
