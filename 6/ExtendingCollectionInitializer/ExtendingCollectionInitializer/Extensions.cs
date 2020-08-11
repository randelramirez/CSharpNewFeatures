using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendingCollectionInitializer
{
    public static class Extensions
    {
        public static void Add(this Dictionary<string, Person> dictionary, Person person) =>
            dictionary.Add(person.Name, person);
           
    }
}
