using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    /// <summary>
    /// Section 5 = 
    /// Section 5: Concepts 1
    ///       Advanced Programming Concepts in C#
    ///   5.1 Assemblies, Exe, DLL, class library
    ///   5.2 Nullable/ Anonymous Types, var
    ///   5.3 Delegates and Multicast Delegates, pass method as param
    ///   5.4 Anonymous Methods and Lambda Expressions
    ///       In-line anonymous method
    ///   5.5 Generics and Events, Gen vs Array
    ///   5.6 Asynchronous Programming, Await Win Forms
    /// </summary>
    class Section5
    {
        /* Notes
        // nullable (int?, bool? .. etc)
        int? iNull = null; 

        // Anonymous collection, use like enum (myAnonymousVar.CompanyName)
        var myAnonymousVars = new { CompanyName = "Hi", Year = 2000 }; 
        

            // create app to do this?
            // GAC = create key, install and uninstall (using CMD Admin)
            //     sn -k 
            //     gacutil -i "C:\Users\ianea\source\repos\C8_In4Hours\C8_In4Hours\bin\Debug\netcoreapp3.1\IHSLibs2.dll"
            //     gacutil -u IHSLibs2
            //     /l   - lists all assemblies
            //     /ldl - downloaded files cache
            //     /lr - assemblies and references
            //C:\Windows\Microsoft.NET\assembly\
            // %windir%\assembly
         */

        /// <summary> Prints "Hello World!"
        /// </summary>
        public void PrintHello()
        {
            Console.WriteLine("S5 Hello World!");
        }

       
       
       
       

        //Advanced Programming Concepts in C#
        //   5.1 Assemblies, GAC, Exe/ DLL, private/ public class library
        public void Lesson5_1()
        {
            //compile/ build, debug exe, EXE vs DDL, 
            //-build, build solution - compiles and creates assembly 
            //-open folder in file explorer
            //strong named file = file with public and private key pair

            //	Assemblies - 
            //	.exe (executable - Console App, Windows App)
            //	.dll (dynamic link library - Class library project)

            // Private/ Public Library -
            // IHSLibs1 = private - GetMyName
            // IHSLibs2 = public - Print(message)

            // Private
            // New Class Library project - IHSLibs1 - public string GetMyName() return "Ian..."
            // add reference
            // using IHSLibs1 // IHSLibs1.dll private assembly (look for in folder)

            // Public
            // New Class Library project - IHSLibs2 - public void Print(message)
            //      Console.WriteLine($"Print from IHSLibs2: {message}");
            // GAC (Global Assembly Cache) = create key, sign project, install
            //      (create key) CMD Admin =     sn -k 
            //      (assign key) Visual Studio = properties - signing - sing the assembly (with key)
            //   if changing Private Library to Private Library = refrence - IHSLibs1 - copy local property false
            // 
            //      (install) CMD Admin =   gacutil -i "C:\Users\ianea\source\repos\C8_In4Hours\C8_In4Hours\bin\Debug\netcoreapp3.1\IHSLibs2.dll"
            //      (uninstall) CMD Admin = gacutil -u IHSLibs2
        }

        public void CheckAssembly(string location = @"C:\Windows\assembly\", string name = "IHSLibs2.dll")
        {
            // Doesn't exist? C:\Windows\Microsoft.NET\Framework\v3.5\System.Net.dll
            // location = 
            string file = location + name; // @"C:\Windows\assembly\IHSLibs2.dll"
            try
            {
                System.Reflection.AssemblyName testAssembly;

                testAssembly = System.Reflection.AssemblyName.GetAssemblyName(file);
                
                System.Console.WriteLine($"Yes, the file is an assembly : {testAssembly.FullName}");
            }

            catch (System.IO.FileNotFoundException)
            {
                System.Console.WriteLine("The file cannot be found.");
            }

            catch (System.BadImageFormatException)
            {
                System.Console.WriteLine("The file is not an assembly.");
            }

            catch (System.IO.FileLoadException)
            {
                System.Console.WriteLine("The assembly has already been loaded.");
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"E = {e}");
            }
        }

        //   5.2 Var, Nullable/ Anonymous Types, Value vs Reference
        public void Lesson5_2()
        {
            // Value Type, Reference Type
            // Value        = Simple (Int, String, Bool), Enum, Struct, Nullable
            // Reference    = Class, Interface, Array, Delegate

            // Value - cannot be null
            //int i = null // int i - cannot be null
            int? iNull = null; // works for int?, bool?
            int iNew = 0;

            Console.WriteLine("");
            Console.WriteLine($"before, iNull: {iNull}"); // (empty) before assignment

            iNull = 10;
            // When assigning a value to iNull, create new int
            if (iNull.HasValue)
            {
                iNew = iNull.Value;
            }
            Console.WriteLine($"after, iNull: {iNull}, iNew: {iNew}"); // (10, 10) after assignment
            Console.WriteLine("");


            // Anonymous types
            var myAnonymousVar = new { CompanyName = "Hi", Year = 2000 }; // Anonymous collection of multiple types
            var iMyInt = 10;
            var strMyString = "hi";

            Console.WriteLine($"var - Name: {myAnonymousVar.CompanyName}, Year: {myAnonymousVar.Year}");
            Console.WriteLine($"var int: {iMyInt}, var string: {strMyString}");
            Console.WriteLine("");
        }

        //   5.3 Delegates and Multicast Delegates, pass method as param
        public void Lesson5_3()
        {

        }

        //   5.4 Anonymous Methods and Lambda Expressions
        //  In-line anonymous method
        public void Lesson5_4()
        {

        }

        //   5.5 Generics and Events, Gen vs Array
        public void Lesson5_5()
        {

        }

        //   5.6 Asynchronous Programming, Await Win Forms
        public void Lesson5_6()
        {

        }
    }
}
