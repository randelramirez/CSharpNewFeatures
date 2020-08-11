using System;
using System.Collections.Generic;
using System.Text;

namespace SwtichPatternMatching
{
    public abstract class Person
    {
        public Person(string name, DateTime birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; }

        public DateTime BirthDate { get; }

    }
}
