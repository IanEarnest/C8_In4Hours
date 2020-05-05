using System;

namespace C8_In4Hours
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build/ Compile, CLR(JIT), MSIL, Machine Language

            // Section 1 = Basic syntax
            var S1 = new Section1();
            S1.PrintHello();

            //var S2 = new Section2();
            //S2.PrintHello(); // Hello World
        }

        public void S1_Methods()
        {
            // S1
            var S1 = new Section1();
            S1.PrintHello();
            S1.ReadUser();
            S1.Lesson1_6();
            S1.Lesson1_6_2();
            S1.Lesson1_7();
        }
        public void S2_Methods()
        {
            //var S2 = new Section2();
            //S2.
        }
    }
}
