using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    /// <summary>
    /// Hello World, read user input, basic syntax, types and variables, arithmetic operators,
    /// </summary>
    class Section1
    {
        /* Notes
        .NET framework (year 2000)
	    Presentation 			        - Web apps (ASP.NET), Win Forms, WPF
	    Framework class libraries 	    - strings, arrays
	    CLR (common language runtime) 	- JIT compiler, Garbage collection, Exeption handling, security
         
         Console.WriteLine("Is he an empoyee? " + (cust.isEmployee ? "Yes" : "No"));
         // shorthand = cw = console.writeline
         */

        /// <summary> Prints "Hello World!"
        /// </summary>
        public void PrintHello()
        {
            Console.WriteLine("S1 Hello World!");
        }

        /// <summary> Waits for user to input name and then prints it
        /// <para>  Example:  </para>
        /// <para>  'Input name: '  </para>
        /// <para>  -Steve          </para>
        /// <para>  'name = Steve'  </para>
        /// </summary>
        public void ReadUser()
        {
            Console.WriteLine("Input name:");
            string name = Console.ReadLine();
            Console.WriteLine("name = " + name);
        }




        /// <summary> Prints "Hello World!"
        /// <para>    Types and Variables (Contains comments)</para>
        /// <example> Code:
        /// <code>
        ///     int i;
        ///     i = 10;
        ///     if (i > 5)
        ///     {
        ///         PrintHello();
        ///     }
        /// </code>
        /// </example>
        /// </summary>
        public void Lesson1_6()
        {
            // Identifiers = name for class, methods, variables     "System", "C8_In4Hours", "Section1", "ReadUser"
            //      class/ method        = pascal case   "Section1", "PrintHello"
            //      variable/ parameter  = camel case    "myName", "myString"

            // Keywords = related with compiler "using", "namespace", "class", "static", "void", "string"
            // Statements = action - declaration, expression, selection
            int i;      // = Declaration statement
            i = 10;     // = Expression statement
            if (i > 5)  // = Selection statement
            {
                PrintHello();
            }
            // Literals     = "10" "hi"
            // Punctuators  = "{} , ;"
            // Operators    = + - / * == %
            // Comments     = // /**/
        }

        /// <summary>Part of Lesson1_6_2 </summary>
        struct Customer
        {
            public int age;
            public string name;
            public bool isEmployee;
        }
        /// <summary> Struct for Customer, printing struct variables, writeline inline condition
        /// <para></para>
        ///<example> Code:
        /// <code>
        ///     Console.WriteLine("Is he an empoyee? " + (cust.isEmployee ? "Yes" : "No"));
        /// </code>
        /// </example>
        /// </summary>
        public void Lesson1_6_2()
        {
            // shorthand = cw = console.writeline
            Customer cust;
            cust.age = 35;
            cust.name = "Steve";
            cust.isEmployee = true;
            Console.ForegroundColor = ConsoleColor.Yellow; // text colour
            Console.WriteLine(cust.name + " is " + cust.age + " years old.");
            Console.WriteLine("Is he an empoyee? " + (cust.isEmployee ? "Yes" : "No"));
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary> Uses operators +, -, *, /, %, to calculate answer, includes decimal and increment
        /// <para>    e.g. 15 + 3 = 18</para>
        /// </summary>
        public void Lesson1_7()
        {
            int firstOperand = 15;
            int secondOperand = 3;

            //Adding: 15 + 3 = 18
            int additionResult = firstOperand + secondOperand;
            int subtractResult = firstOperand - secondOperand;
            int multiplyResult = firstOperand * secondOperand;
            int divisionResult = firstOperand / secondOperand;
            Console.WriteLine("Adding: " + firstOperand + " + " + secondOperand + " = " + additionResult);
            Console.WriteLine("Subtracting: " + firstOperand + " - " + secondOperand + " = " + subtractResult);
            Console.WriteLine("Multiplying: " + firstOperand + " * " + secondOperand + " = " + multiplyResult);
            Console.WriteLine("Dividing: " + firstOperand + " / " + secondOperand + " = " + divisionResult);

            //Adding (decimal): 15 + 3 = answer
            decimal firstOperandDecimal = 15.0m; // literal to decimal (use M)
            decimal secondOperandDecimal = 3.0m; // literal to decimal (use M)
            decimal additionResultDecimal = firstOperandDecimal + secondOperandDecimal;
            Console.WriteLine("");
            Console.WriteLine("Adding (decimal): " + firstOperandDecimal + " + " + secondOperandDecimal + " = " + additionResultDecimal);

            // Operator = % (remainder)
            // firstNum / secondNum = 2 (7/3 = 2)
            // firstNum % secondNum = 1 (7/3 = 2 with 1 remaining)
            int firstNum = 7;
            int secondNum = 3;
            Console.WriteLine("% operator: " + firstNum + "/" + secondNum + " = " + firstNum/secondNum +  
                " (remaining = " + firstNum % secondNum + ")");
            Console.WriteLine("");

            // Increment and decrement "++" "--"
            int i = 3;
            int increment = i;
            Console.WriteLine("i = " + increment);
            increment = i;
            increment++;
            Console.WriteLine("i++ = " + increment);
            increment = i;
            increment--;
            Console.WriteLine("i-- = " + increment);
        }

    }
}
