using System;
using System.Collections.Generic;

namespace ExtendingCollectionInitializer
{
    class Program
    {
        static void Main(string[] args)
        {
   
            var p1 = new Person("Randel", default);
            var p2 = new Person("Germaine", default);

            // Goal: To add person and use name as key
            // We need to declare person object fist because we nee to access the name, we can't if we new up directly in the initializer
            var dictionary = new Dictionary<string, Person>
            {
                { p1.Name, p1 },
                { p2.Name, p2 }
            };

            // We can now simply the person object directly, the implementation is hidden in the extension method
            // This is possible because add is called during initialization
            // This is usually useful for testing purposes, when we're creating unit tests and intializing collections
            var dictionary2   = new Dictionary<string, Person>
            {
                { new Person("Randel", default) },
                 { new Person("Germaine", default) }
            };

            Console.ReadKey();
        }
    }
}
