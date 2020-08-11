using System;

namespace SwtichPatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {

            TestPatternMatching("gem");
            TestPatternMatching(26);
            TestPatternMatching(11);
            Console.WriteLine();


            var testPerson1 = new Customer("Randel", default, default);
            var testPerson2 = new Employee("Germaine", default, default);

            PrintForCustomer(testPerson1);
            PrintForCustomer(testPerson2);
            Console.WriteLine();


            PrintInfo(testPerson1);
            PrintInfo(testPerson1);
            Console.WriteLine();


            var p1 = new Employee("Officemate", new DateTime(), "Willis Towers Watson");
            Console.WriteLine($"{p1.Name}: {GiveVIPAccess(p1)}");

            var p2 = new Employee("Gem", new DateTime(), string.Empty);
            Console.WriteLine($"{p2.Name}: {GiveVIPAccess(p2)}");

            var p3 = new Customer("Randel", new DateTime(), string.Empty);
            Console.WriteLine($"{p3.Name}: {GiveVIPAccess(p3)}");

            // true because, this is an instance of Employee that has a name Randel 
            var p4 = new WorkFromHomeEmployee("Randel", new DateTime(), "Willis Towers Watson", "rande329");
            Console.WriteLine($"{p4.Name}: {GiveVIPAccess(p4)}");

            var p5 = new Employee("Germaine", new DateTime(), "HP");
            Console.WriteLine($"{p5.Name}: {GiveVIPAccess(p5)}");

            var p6 = new WorkFromHomeEmployee("Germaine", new DateTime(), "HP", "germaine.montemayor");
            Console.WriteLine($"{p6.Name}: {GiveVIPAccess(p6)}");

            var p7 = new Customer("Gem", new DateTime(), "8 Brasilia Street Intercity Homes Cupang, Muntinlupa");
            Console.WriteLine($"{p7.Name}: {GiveVIPAccess(p7)}");

            var p8 = new Customer("Gem", new DateTime(), "8 Brasilia Street Intercity Homes");
            Console.WriteLine($"{p8.Name}: {GiveVIPAccess(p8)}");

            Console.ReadKey();

        }

        static void TestPatternMatching(object obj)
        {

            //if (obj is int && (int)obj == 3)
            //    Console.WriteLine("Number 11");


            // or

            // C# won't let you use the == operator, because obj is object.
            // However, we can use 'is'
            if (obj is 11)
            {
                Console.WriteLine("Number 11");
            }
            else
            {
                Console.WriteLine("Different number");
            }

        }

        static void PrintForCustomer(Person person)
        {
            //Goal: instead of using as/if

            // set variable so we can access customer properties
            if (person is Customer customer)
            {
                Console.WriteLine($"{customer.Name} is a Customer");
            }
            else
            {
                Console.WriteLine($"{person.Name} is not a Customer, this person is a {person.GetType().Name}");
            }
        }

        static void PrintInfo(Person person)
        {
            // Pattern matching (Type pattern)
            switch (person)
            {
                case Employee employee:
                    Console.WriteLine("It's an employee");
                    break;

                case Customer customer:
                    Console.WriteLine("It's an employee");
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }

        static bool GiveVIPAccess(Person person)
        {
            // Polymorhpic pattern matching

            return person switch
            {
                // if person is type Employee and has a name "Gem"
                Employee employee when employee.Name == "Gem" => true,

                // if person is type Customer and has a name "Randel"
                Customer customer when customer.Name == "Randel" => true,

                // assign variable to property
                Customer { Address: string address } customer when address.Contains("Muntinlupa") => true,

                // if person is type Employee and has a name "Randel"
                // no need to declare variable name at the end before => true
                Employee { Name: "Randel" } => true,

                // Additional type checking with when 
                Employee { Name: "Germaine", Company: "HP" } employee when (employee is IWorkFromHome) => true,

                //_ => false
                _ => throw new InvalidOperationException()
            };
        }

        // Same as method above with a different syntax
        // In this syntax we can do multiple things insde the case block unline the new syntax(C# 8)
        static bool GiveVIPAccess2(Person person)
        {
            // Polymorhpic pattern matching

            switch(person)
            {
                // if person is type Employee and has a name "Gem"
                case Employee employee when employee.Name == "Gem":
                    return true;

                // if person is type Employee and has a name "Gem"
                case Employee employee when employee.Name == "Gem":
                    Console.WriteLine("I can do extra things here");
                    return true;

                // if person is type Customer and has a name "Randel"
                case Customer customer when customer.Name == "Randel":
                    return true;

                // assign variable to property
                case Customer { Address: string address } customer when address.Contains("Muntinlupa"):
                    return true;

                // if person is type Employee and has a name "Randel"
                // no need to declare variable name at the end before => true
                case Employee { Name: "Randel" }:
                    return true;

                // Additional type checking with when 
                case Employee { Name: "Germaine", Company: "HP" } employee when (employee is IWorkFromHome):
                    return true;

                //default:
                //    return false;

                case var personType:
                    Console.WriteLine("Alternative to default");
                    Console.WriteLine($"We have access to the type of person {personType.GetType()}");
                    throw new InvalidOperationException();
            };
        }
    }
}
