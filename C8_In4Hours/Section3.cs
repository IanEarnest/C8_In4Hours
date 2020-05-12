using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    /// <summary>
    /// Section 3 = Methods
    /// Section 3. Basics 3
	///       Methods, Enum and Exceptions
    ///   3.1 Enum, parse string
    ///   3.2 Methods, return, out, params
    ///   3.3 Debugging/ Exceptions, break points, step over, Try Catch
    /// </summary>
    class Section3
    {
        /* Notes
        Enum.TryParse("East", out directionVal);
        // Console colour uses enum
        Console.ForegroundColor = ConsoleColor.Cyan; 

        // Method (signature)
        //public            void        Lesson3_2() 
        //AccessModifier  returnType    MethodName(parameters)

        // Method Params - normal, ref, out, in, params
        // Noramlly use ref or out
        MethodByRef(ref i);     public void MethodByRef(ref int i)
        MethodByOut(out i);     public void MethodByOut(out int i)

        // ref/ params changes original variables, not copies
        MethodByRef(ref i);
        public void MethodByRef(ref int i)
        MethodByParams(j); 
        public void MethodByParams(params int[] j)

        Optional params
        MyMethod(int i, int b = 0); // b doesn't have to be defined
        MyMethod(myInt: 12, myString: "2002"); // can name variables in any order
         */

        /// <summary> Prints "Hello World!"
        /// </summary>
        public void PrintHello()
        {
            Console.WriteLine("S3 Hello World!");
        }


        /// <summary> Part of Lesson3_1
        /// </summary>
        enum MyDirections
        {
            North = 5,
            East = 2,
            South = 1,
            West = 7
        }
        /// <summary> Enum, parse string, foreground colour
        /// </summary>
        public void Lesson3_1()
        {
            // Enum is a set of fixed or Constants variables - 
            // e.g. Directions / Days of the week
            // Defaults first value 0, can set values
            // Enum.TryParse defaults to 0 if "East" cannot be found

            int direction = (int)MyDirections.North;
            Console.WriteLine($"Direction = {direction}"); // north = 5

            MyDirections directionVal;
            Enum.TryParse("East", out directionVal);
            int eastDirection = (int) directionVal;
            Console.WriteLine($"Direction East = {eastDirection}"); // east = 2

            Console.ForegroundColor = ConsoleColor.Cyan; // Console colour uses enum
        }

        // Methods for Lesson3_2
        public int Add(int a, int b)
        {
            return a + b;
        }
        public void MethodByVal(int i)
        {
            i = 11;
            Console.WriteLine($"\tPrint (normal): {i}");
        }
        public void MethodByRef(ref int i)
        {
            i = 12;
            Console.WriteLine($"\t\tPrint (ref): {i}");
        }
        public void MethodByOut(out int i)
        {
            i = 13; // Has to be assigned
            Console.WriteLine($"\t\tPrint (out): {i}");
        }
        public void MethodByIn(in int i)
        {
            //i = 14; // Cannot be assigned, read only
            Console.WriteLine($"\t\tPrint (in): {i}");
        }
        public void MethodByParams(params int[] j)
        {
            Console.Write($"\tPrint (params1): {j[0]}");
            j[0] = 17;
            Console.WriteLine($"\tPrint (params2): {j[0]}");
        }
        ///<summary> Methods, return, ref, out, in, params, params by value/ reference
        ///<para>   Uses Add, MethodByVal, MethodByRef, MethodByOut, MethodByIn, MethodByParams</para>
        ///</summary>
        public void Lesson3_2()
        {
            // Method (signature)
            //public            void        Lesson3_2() 
            //AccessModifier  returnType    MethodName(parameters)

            int a = 10;
            int b = 20;
            int r = a + b;

            int k = Add(10, 20);

            Console.WriteLine($"No method: {r}");
            Console.WriteLine($"Yes method: {k}");
            Console.WriteLine("");



            // print array
            // params - normal, ref, out, in, params
            int i = 10;
            int[] j = new int[] {15,2,3,4,5};

            // Normal
            Console.Write($"Before Print (normal): {i}"); // 10
            MethodByVal(i);         //value (normal)      // 11

            // Ref (changes original var)
            Console.Write($"Before Print (ref): {i}");   //10
            MethodByRef(ref i);         //12       //reference (needs to be assigned e.g. int i = 10)

            // Out
            Console.Write($"Before Print (out): {i}"); // 12
            MethodByOut(out i);	  //13  //out needs to be used inside method, use for Enum
            
            // In
            i = 14; // 14
            Console.Write($"Before Print (in): {i}");  //14 
            MethodByIn(in i);	//14    //in read only

            // Params (changes original var)
            Console.Write($"Before Print (params): {j[0]}"); // 14
            MethodByParams(j);      //16	    //params use values direct, no need for assigning array
            // params (in line array)
            Console.Write($"Before Print (params2): {j[0]}"); // 17
            MethodByParams(16,2,3,4,5);     //17 // Can pass just array values
        }


        ///<summary> Debugging/ Exceptions, break points, step over, Try Catch
        ///<para>   Contains break point</para>
        ///</summary>
        public void Lesson3_3()
        {
            //immediate window, locals
            // insert breakpoint F9
            // immediate window "number1" (shows 0)
            // F10 step over, F11 step into
            // log exception to file or windows events


            //DivideByZeroException/ IndexOutOfRangeException
            try
            {
                int a = 10;
                int b = 0;
                int c = 0;
                c  = a / b; // DivideByZeroException
                Console.WriteLine($"C = {c}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"EX / by 0 = {ex.Message}");
                //throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EX = {ex.Message}");
                //throw;
            }
            finally
            {
                Console.WriteLine($"Finally");
            }

            try
            {
                // int array, print > length
                int[] MyArray = new int[] { 1, 2, 3 };
                Console.WriteLine($"Int[] = {MyArray[5]}"); //IndexOutOfRangeException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"EX Index = {ex.Message}");
                //throw;
            }
        }
    }
}
