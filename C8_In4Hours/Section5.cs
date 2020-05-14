using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using IHSLibs1;
using IHSLibs2;

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
            // WindowsKey + E (Explorer)    %windir%\assembly
            // 
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
            // IHSLibs1 = private - GetMyName()
            // IHSLibs2 = public  - Print()

            // Private
            // New Class Library project - IHSLibs1 - public string GetMyName() return "Ian..."
            // add reference (Dependencies, Projects, IHSLibs1)
            // Using IHSLibs1 // need to import
            Class1 IHSClass1 = new Class1();
            string myName = IHSClass1.GetMyName();
            Console.WriteLine($"IHSClass1 = Name: {myName}");


            // Public
            // New Class Library project - IHSLibs2 - public void Print(message)
            //      Console.WriteLine($"Print from IHSLibs2: {message}");
            // GAC (Global Assembly Cache) = create key, sign project, install
            //      (create key) CMD Admin =     sn -k "myStrongKey.snk" // store this anywhere (desktop)
            //      (assign key) Visual Studio = properties - signing - sing the assembly (with key)
            //      (refrence) IHSLibs2 - copy local property false
            //      (install) CMD Admin =   gacutil -i "C:\Users\ianea\source\repos\C8_In4Hours\IHSLibs2\bin\Debug\netcoreapp3.1\IHSLibs2.dll"
            //      (uninstall) CMD Admin = gacutil -u IHSLibs2
            // add reference (Dependencies, Assemblies, IHSLibs2)
            // Using IHSLibs2 // need to import
            Class2 IHSClass2 = new Class2();
            IHSClass2.Print("Hi IHS");
            IHSLibs2.Class2.MyPrint("Hi IHS again");

            CheckAssembly(1, 0); // System.Core
            CheckAssembly(1, 1); // IHSLibs2
            CheckAssembly(2, 2); // Full IHSLibs2 location
        }
        public void CheckAssembly(int location, int name)
        {
            string locationStr = "";
            string nameStr = "";

            if (location == 0) locationStr = @"C:\Windows\assembly\"; // .NET 3.5 and below
            if (location == 1) locationStr = @"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\";
            if (location == 2) locationStr = @"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\IHSLibs2\v4.0_1.0.0.0__22e507a759643b56\";

            if (name == 0) nameStr = @"System.Core";
            if (name == 1) nameStr = @"IHSLibs2";
            if (name == 2) nameStr = @"IHSLibs2.dll";

            CheckAssembly(locationStr, nameStr);
        }

        public void CheckAssembly(string location, string name)
        {
            string file = location + name; // @"C:\Windows\assembly\IHSLibs2.dll"

            Console.WriteLine($"\tLooking for: {file}");
            
            try
            {
                // System.Reflection
                AssemblyName testAssembly;

                testAssembly = AssemblyName.GetAssemblyName(file);
                
                Console.WriteLine($"\tYes, the file is an assembly : {testAssembly.FullName}");
                
                Assembly myDll = Assembly.Load("IHSLibs2"); //IHSLibs2 cannot find??
                Console.WriteLine($"\t{myDll.FullName}");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("\tThe file cannot be found.");
            }

            catch (BadImageFormatException)
            {
                Console.WriteLine("\tThe file is not an assembly.");
            }

            catch (System.IO.FileLoadException)
            {
                System.Console.WriteLine("\tThe assembly has already been loaded.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\tE = {e}");
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
