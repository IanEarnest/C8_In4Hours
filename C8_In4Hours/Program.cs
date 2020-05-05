using System;

namespace C8_In4Hours
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question - Struct?
            // Question - uses of string.empty
            // Question - valid uses of stringbuilder
            
            // Build/ Compile, CLR(JIT), MSIL, Machine Language

            // Section 1 = Intro
            var S1 = new Section1();
            S1.PrintHello();

            // Section 2 = Logic - // Current vid = 2.2
            var S2 = new Section2();
            S2.PrintHello(); // Hello World
            S2.Lesson2_1_2();
            S2.Lesson2_1_3();
            // Section 3 = Methods
            // Section 4 = OOP
            // Section 5 = Concepts
            // Section 6 = Project
        }

        // Lessons from Section 1
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

        // Lessons from Section 2
        public void S2_Methods()
        {
            //var S2 = new Section2();
            //S2.
        }

        /*Section 3. Basics 3
	        Methods, Enum and Exceptions
        3.1 Enum, parse string
        3.2 Methods, return, out, params
        3.3 Debugging/ Exceptions, break points, step over, Try Catch*/

        /*Section 4. OOP 1
	        Object-Oriented Programming in C#
        4.1 Encapsulation, classes, objects, data members, properties
        4.2 Inheritance, child classes, base classes
        4.3 Abstraction, override
        4.4 Polymorphism, interface vs abstract
        4.5 Concepts Related to Object Oriented Programming
	        Read-only, constants, protected, partial, static classes*/

        /*Section 5: Concepts 1
	        Advanced Programming Concepts in C#
        5.1 Assemblies, Exe, DLL, class library
        5.2 Nullable/ Anonymous Types, var
        5.3 Delegates and Multicast Delegates, pass method as param
        5.4 Anonymous Methods and Lambda Expressions
	        In-line anonymous method
        5.5 Generics and Events, Gen vs Array
        5.6 Asynchronous Programming, Await Win Forms*/

        /*Section 6: Project 1
	        Win Form Project in C#
        6.1 Requirement, design
        6.2 UI, controls, buttons
        6.3 Business Logic Implementation, Architecture, OOP
        6.4 Events in Win Form Project*/
    }
}
