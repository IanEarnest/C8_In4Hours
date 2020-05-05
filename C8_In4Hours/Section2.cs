using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    /// <summary>
    /// Hello World, read user input, basic syntax, types and variables, arithmetic operators,
    /// </summary>
    class Section2
    {
        /* Notes
        A
         */


        /// <summary> Prints "Hello World!"
        /// </summary>
        public void PrintHello()
        {
            Console.WriteLine("S2 Hello World!");
        }




        //2.1 Strings - maniuplate strings
        public void Lesson2_1()
        {
            // Character and String - '' = character, "" = string
            char charA = 'a';
            string stringApple = "apple";

            // Print Char
            Console.WriteLine("charA = " + charA);
            charA = char.ToUpper(charA);
            Console.WriteLine("charA (upper) = " + charA);
            // Print String
            Console.WriteLine("stringApple = " + stringApple);
            int aPosition = stringApple.IndexOf('a'); // random thing
            Console.WriteLine("stringApple a = " + stringApple[aPosition]); // gets a from apple
            Console.WriteLine("");

            // empty string
            string emptyString1 = "";
            string emptyString2 = String.Empty;
            string emptyString3 = null; // null string (cannot access, causes error)
            Console.WriteLine("emptyString1 = [" + emptyString1 + "] Length = " + emptyString1.Length);
            Console.WriteLine("emptyString2 = [" + emptyString2 + "] Length = " + emptyString2.Length);
            Console.WriteLine("emptyString3 = [" + emptyString3 + "] Length = " + "NULL REFERENCE EXCEPTION!");
            Console.WriteLine("");

            // Escape sequence (starts with "\")
            // "/n" = new line
            // "/t" = tab
            // "\\" = \
            Console.WriteLine("Line 1, Line 2");
            Console.WriteLine("Line 1, \n Line 2");
            Console.WriteLine("Line 1, \t Line 2");
            Console.WriteLine("Line 1, \\ Line 2");
        }

        public void Lesson2_1_2()
        {
            // String Methods
            string myString = "Hello World, Hello I live in Germany.";
            Console.WriteLine("myString = " + myString);
            Console.WriteLine(" Contains \"World\": " + myString.Contains("World")); // .Contains
            Console.WriteLine(" StartsWith \"Hello\": " + myString.StartsWith("Hello")); // .StartsWith
            Console.WriteLine(" EndsWith \"Germany.\": " + myString.EndsWith("Germany.")); // .EndsWith
            Console.WriteLine(" IndexOf \"live\": " + myString.IndexOf("live")); // .IndexOf
            Console.WriteLine(" IndexOf \"lost\": " + myString.IndexOf("lost")); // .IndexOf (-1 = not there)
            Console.WriteLine(" lastIndexOf \"Hello\": " + myString.LastIndexOf("Hello")); // .lastIndexOf
            Console.WriteLine(" Substring: " + myString.Substring(18, 3)); // .Substring
            Console.WriteLine(" Insert \"And\": " + myString.Insert(36, " And ")); // .Insert
            Console.WriteLine(" Remove \"in\": " + myString.Remove(26, 3)); // .Remove
            Console.WriteLine(" Replace \"Germany\": " + myString.Replace("Germany.", "Italy.")); // .Replace

            // Concatenation
            // String is immutable (created new string when changed)
            string myString1 = "hi";
            string myString2 = ", hey";
            string myString3 = myString1 + myString2;
            Console.WriteLine("myString1 = " + myString1 + ", myString2 = " + myString2 + ", myString3 = " + myString3);

            StringBuilder sb = new StringBuilder();
            sb.Append(myString1);
            sb.Append(myString2);
            string myString4 = sb.ToString();
            Console.WriteLine("myString4 = " + myString4);
        }

        public void Lesson2_1_3()
        {
            // string = readline()
            // int age = Convert.ToInt32(Console.ReadLine());

            // writeline string.format("Hi {0}, bye {1}", var1, var2)
            // writeline string.format("Hi {0}, bye {1:C2}", var1, dollar2) // currency 2

            // DateTime todaysDate = DateTime.now
            // writeline string.format("Hi {0:d}, bye {0:t}", todaysDate) // d = date, t = time

            // Interpolation
            // writeline string.format("Hi {var1}, bye {dollar2:C2}", var1, dollar2) // currency 2
        }


        //2.2 If/ Else
        public void Lesson2_2()
        {
            
        }

        //2.3 For loop, break, goto
        public void Lesson2_3()
        {

        }

        //2.4 Arrays, For loop, sort
        public void Lesson2_4()
        {

        }
    }
}
