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
            var S1 = new Section1();
            S1.PrintHello(); // Hello World
            //S1.ReadUser();  // Read line, print name

            S1.Lesson1_6();
            S1.Lesson1_7();
        }
    }
}
