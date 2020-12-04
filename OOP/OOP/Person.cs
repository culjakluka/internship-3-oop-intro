using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Person
    {
        public Person(string firstName, string lastName, long oIB, long phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            OIB = oIB;
            PhoneNumber = phoneNumber;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long OIB { get; set; }
        public long PhoneNumber { get; set; }
    }
}
