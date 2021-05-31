using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTen
{
    class Bike
    {
        //Variables
        public int ID { get; private set; }
        public string Name { get; private set; }
        public double Cost { get; private set; }
        public string Gender { get; private set; }

        //Constructors
        public Bike(int iD) : this(iD, "Bike", 000.00, "Unknown")
        {
        }
        public Bike(int iD,string name) : this(iD, name, 000.00, "Unknown")
        {
        }
        public Bike(int iD,string name,double cost) : this(iD, name, cost, "Unknown")
        {
        }
        public Bike(int iD, string name, double cost, string gender)
        {
            ID = iD;
            Name = name;
            Cost = cost;
            Gender = gender;
        }

        //Overrides
        public override string ToString()
        {
            //return string.Format($"{ID}  {Name}  {Cost}  {Gender}");
            return string.Format("{0,-10}{1,-20}{2,-10}{3,-10}",ID,Name,Cost,Gender);
        }

    }
}
