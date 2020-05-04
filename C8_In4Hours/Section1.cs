using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    class Section1
    {


        public void PrintHello()
        {
            Console.WriteLine("Hello World!");
        }

        public void ReadUser()
        {
            Console.WriteLine("Input name:");
            string name = Console.ReadLine();
            Console.WriteLine("name = " + name);

            
        }

        public void ReadUser2()
        {
            // Identifiers = name for class, methods, variables     "System", "C8_In4Hours", "Section1", "ReadUser"
            // class/ method        = pascal case   "Section1", "PrintHello"
            // variable/ parameter  = camel case    "myName", "myString"

            // Keywords = related with compiler "using", "namespace", "class", "static", "void", "string"
            // Statements = action - declaration, expression, selection
            int i;      // = Declaration statement
            i = 10;     // = Expression statement
            if (i > 5)  // = Selection statement
            {
                PrintHello();
            }
            // Literals = "10" "hi"
            // Punctuators = "{} , ;"
            // Operators = + - / * == %
            // Comments // /**/
        }
    }
}
