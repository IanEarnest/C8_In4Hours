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

        // Strings - methods, concatenation
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

        // Strings - Interpolation, string formatting
        public void Lesson2_1_3()
        {
            string name;
            int age;
            int wage = 1200;
            DateTime todaysDate = DateTime.Now;

            Console.WriteLine(String.Format("Date: {0:d}, Time: {0:t}", todaysDate)); // d = date, t = time
            // Interpolation
            Console.WriteLine($"Date: {todaysDate:d}, Time: {todaysDate:t}");

            // Reading user input
            Console.Write("Name? ");
            name = Console.ReadLine();
            Console.Write("Age? ");
            age = Convert.ToInt32(Console.ReadLine());
            
            // Different formatting
            Console.WriteLine("Name: " + name + ", Age: " + age);
            Console.WriteLine($"Name: {name}, Age: {age}");
            Console.WriteLine(String.Format("Name: {0}, Age: {1}", name, age));
            Console.WriteLine(String.Format("Name: {0}, Wage: {1:C2}", name, wage)); // currency 2
        }


        //2.2 If/ Else, switch
        // >, >=, <, <=, ==, ||, &&, !, !=
        public void Lesson2_2()
        {
            bool condition1 = true;
            bool condition2 = false;
            if (condition1 == true)
            {
                Console.WriteLine("True");
            }
            else if (condition1 == false)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("Other");
            }

            if (condition1 == true || condition2 == true)
            {
                Console.WriteLine("True");
            }
            if ((condition1 == true) || (condition2 == true))
            {
                Console.WriteLine("True");
            }

            if (condition1 == true && condition2 == true)
            {
                Console.WriteLine("True");
            }

            
        }
        
        // Switch statement
        public void Lesson2_2_2()
        {
            string state = Console.ReadLine().ToUpper();
            switch (state)
            {
                case "YES":
                    Console.WriteLine("Yes");
                    break;
                default:
                    break;
            }
        }

        //2.3 For loop, break, goto
        public void Lesson2_3()
        {
            restart:

            int length = 5;

            // for loop
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Hello {i}");
            }

            // Nested for loop
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Hello {i}");
                for (int j = 0; j < length; j++)
                {
                    if (j == 2)
                    {
                        continue;   // continue - skips one iteration of the loop
                        // break;   // break - exits loop
                    }
                    Console.WriteLine($"\tHello {j}");
                }
            }

            // while
            int k = 0;
            while (k < 5)
            {
                Console.WriteLine($"Hello {k}");
                k++;
            }

            // do at least once
            int l = 0;
            do
            {
                Console.WriteLine($"\tHello {l}");
                l++;
            } while (l < 5);


            // foreach
            Console.WriteLine("Hello foreach");
            string myString = "hello";
            int n = 0;
            foreach (char c in myString)
            {
                Console.WriteLine($"Hi, {myString[n]}, {c}");
                n++;
            }



            Console.WriteLine("Restart? (Any key)");
            string answer = Console.ReadLine();
            
            if (answer != string.Empty)
            {
                goto restart;
            }
        }

        //2.4 Arrays, For loop, sort
        public void Lesson2_4()
        {
            // Enter array length
            // type somethine for each item
            // print using string.join
            // array.sort, array.copy
            // array.sort custom (own code)

            // Enter array length
            Console.WriteLine("Enter array length:");
            int length = Convert.ToInt32(Console.ReadLine());
            int[] myArray = new int[length]; // Int array

            // type something for each item
            Console.WriteLine("Enter items in array (numbers):");
            for (int i = 0; i < length; i++) // int[3] is 0,1,2,3, i = 4 is not less than 4 (length)
            {
                myArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("");

            //print items
            Console.Write("items: ");
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write($"{i} = {myArray[i]}, "); // e.g. 0 = 23, 1 = 15,
            }
            Console.WriteLine("");

            //print using string.join
            //string myString = string.Join(",", myArray);
            Console.WriteLine($"items joined: {string.Join(",", myArray)}");



            // array.copy, array.sort, print
            int[] myArraySorted = new int[length]; // Int array
            Array.Copy(myArray, myArraySorted, length);
            Array.Sort(myArraySorted);
            Console.WriteLine($"sorted (.sort): {string.Join(",", myArraySorted)}");
            //Console.WriteLine($"sorted (.sort): {myArraySorted}"); // Cannot print array directly

            // array.sort custom (own code)
            for (int i = 0; i < myArray.Length; i++) // i = element to compare
            {
                for (int j = i+1; j < myArray.Length; j++) // j = all other elements
                {
                    // +1 of where i is
                    if(myArray[j] < myArray[i]) // if other elements are smaller than element
                    {
                        int temp = myArray[i];
                        myArray[i] = myArray[j];
                        myArray[j] = temp;
                    }
                }
            }
            Console.WriteLine($"sorted (manual): {string.Join(",", myArray)}");
        }
    }
}
