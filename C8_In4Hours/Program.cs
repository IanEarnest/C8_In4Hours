using System;

namespace C8_In4Hours
{
    class Program
    {
        public static Section1 S1 = new Section1();
        public static Section2 S2 = new Section2();
        public static Section3 S3 = new Section3();
        public static Section4 S4 = new Section4();
        public static Section5 S5 = new Section5();
        public static Section6 S6 = new Section6();

        // Question - Struct?
        // Question - uses of string.empty
        // Question - valid uses of stringbuilder
        // Question - "Interpolation"

        // Tips - use $: Console.WriteLine($"Name: {name}, Age: {age}");
        // C# use "ref" keyword for direct reference to variable instead of copies
        // cw - shorthand

        // Build/ Compile, CLR(JIT), MSIL, Machine Language

        static void Main(string[] args)
        {
            // Section 1 = Intro
            S1.PrintHello();
            //S1_Methods();

            // Section 2 = Logic
            S2.PrintHello(); // TODO = tidy S2

            // Section 3 = Methods  - // Current vid = 3.1
            S3.PrintHello();



            // Section 4 = OOP
            S4.PrintHello();

            // Section 5 = Concepts
            S5.PrintHello();

            // Section 6 = Project
            S6.PrintHello();
        }

        // Lessons from Section 1
        public static void S1_Methods()
        {
            S1.PrintHello();
            S1.ReadUser();
            S1.Lesson1_6();
            S1.Lesson1_6_2();
            S1.Lesson1_7();
        }

        // Lessons from Section 2
        public static void S2_Methods()
        {
            S2.Lesson2_1();
            S2.Lesson2_1_2 ();
            S2.Lesson2_1_3();
            S2.Lesson2_2();
            S2.Lesson2_2_2();
            S2.Lesson2_3();
            S2.Lesson2_4();
        }

        public static void S3_Methods()
        {
            //S3.Lesson3_1();
            //S3.Lesson3_2();
            //S3.Lesson3_3();
        }

        public static void S4_Methods()
        {
            //S4.Lesson4_1();
            //S4.Lesson4_2();
            //S4.Lesson4_3();
            //S4.Lesson4_4();
            //S4.Lesson4_5();
        }

        public static void S5_Methods()
        {
            //S5.Lesson5_1();
            //S5.Lesson5_2();
            //S5.Lesson5_3();
            //S5.Lesson5_4();
            //S5.Lesson5_5();
            //S5.Lesson5_6();
        }

        public static void S6_Methods()
        {
            //S6.Lesson6_1();
            //S6.Lesson6_2();
            //S6.Lesson6_3();
            //S6.Lesson6_4();
        }
    }
}
