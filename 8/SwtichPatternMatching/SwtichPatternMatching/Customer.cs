using System;
using System.Collections.Generic;
using System.Text;

namespace SwtichPatternMatching
{
    public class Customer : Person
    {
        public Customer(string name, DateTime birthDate, string address) : base(name, birthDate)
        {
            this.Address = address;
        }

        public string Address { get; }

    }
}
