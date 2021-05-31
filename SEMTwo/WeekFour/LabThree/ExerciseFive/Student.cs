using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseFour
{
    public class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public Student(string name,string id,string email,string phone)
        {
            Name = name;
            ID = id;
            EmailAddress = email;
            PhoneNumber = phone;
        }
    }
}
