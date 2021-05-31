using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFour
{
    class Lunch
    {
        //Variables
        private string _entree, _sideDish, _drink;

        public string Entree
        {
            get { return _entree; }
            set { _entree = value; }
        }
        public string SideDish
        {
            get { return _sideDish; }
            set { _sideDish = value; }
        }
        public string Drink
        {
            get { return _drink; }
            set { _drink = value; }
        }

        public Lunch(string EntreeInput, string SideDishInput, string DrinkInput)
        {
            Entree = EntreeInput;
            SideDish = SideDishInput;
            Drink = DrinkInput;
        }
    }
}
