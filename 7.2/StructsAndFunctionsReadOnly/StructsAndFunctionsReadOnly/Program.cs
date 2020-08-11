using System;

namespace StructsAndFunctionsReadOnly
{
    public struct Point
    {
        public Point(int x, int y, int z)
        {
            // Struct: all properties must be initialized on constructor
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        // C# 8.0
        public readonly void Mutate()
        {
            // We cannot modify properties on a readonly method
            //this.X = 23; illegal code

        }
    }

    public readonly struct PointReadOnly
    {
        // no need to add read only field, readonly is modifier applied on struct level
        // adding set accessor causes error
        public int X { get; }
    }

    public struct PointPropertyReadOnly
    {
        public PointPropertyReadOnly(int x, int y)
        {
            this.X = 26;

            // struct: must intialize all properties
            this.Y = 11;
        }

        // We can only set values on the constructor
        public readonly int X { get; }

        public int Y { get; set; }

    }
}

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello World!");

        Console.ReadKey();
    }

}
