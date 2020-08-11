using System;
using System.Collections.Generic;
using System.Text;

namespace SwtichPatternMatching
{
    public class Employee : Person
    {
        public Employee(string name, DateTime birthDate, string company) : base(name, birthDate)
        {
            this.Company = company;
        }

        public string Company { get; }
    }
}
