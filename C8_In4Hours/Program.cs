using System;

namespace C8_In4Hours
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hi there, hey
            //Console.WriteLine("Hello World!");
            // Build/ Compile, CLR(JIT), MSIL, Machine Language
            var s1 = new Section1();
            s1.printHello(); // Hello World
            s1.readUser();  // Read line, print name
        }
    }
}
