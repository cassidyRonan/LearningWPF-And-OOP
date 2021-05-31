using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Member : IComparable<Member>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string MemberID { get; set; }
        private decimal _price = 0;
        public decimal Price { get { return _price; } }
        public bool MembershipStatus = true;
        private string Membership = "";

        public static int AmountOfMembers;

        public Member(string firstName, string lastName, int age, string ID)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            MemberID = ID;
            MembershipStatus = false;

            PriceUpdate(age);
            AmountOfMembers++;
            CheckStatus();
        }

        public override string ToString()
        {
            //Console.WriteLine($"\nFirst Name: { FirstName}");
            //Console.WriteLine($"Last Name: { LastName}");
            //Console.WriteLine($"Age: {Age}");
            //Console.WriteLine($"ID: {MemberID}");
            //Console.WriteLine($"Membership Status: {MembershipStatus}");
            //Console.WriteLine($"Price: {Price}");

            return "First Name:" + FirstName + 
                "  Last Name:"+ LastName + 
                "  Age:"+ Age + 
                "  Member ID:"+ MemberID + 
                "  Membership Status:"+ Membership + 
                 "  Price: EUR " +  Price;
        }

        public void Changestatus()
        {
            //Console.WriteLine($"Before: {MembershipStatus}");
            MembershipStatus = !MembershipStatus;
            CheckStatus();
            //Console.WriteLine($"After: {MembershipStatus}");
        }

        private void CheckStatus()
        {
            Membership = MembershipStatus == true ? "Current" : "Expired";
        }

        private void PriceUpdate(int age)
        {
            _price = age < 18 ? 50 : 150;
        }

        public int CompareTo(Member otherMember)
        {
            return LastName.CompareTo(otherMember.LastName);
        }
    }
}
