using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using IHSLibs;

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
            // create app to do this?
            // GAC = create key, install and uninstall (using CMD Admin)
            //     sn -k 
            //     gacutil -i "C:\Users\ianea\source\repos\C8_In4Hours\C8_In4Hours\bin\Debug\netcoreapp3.1\IHSLibs2.dll"
            //     gacutil -u IHSLibs2
            //     /l   - lists all assemblies
            //     /ldl - downloaded files cache
            //     /lr - assemblies and references
            //C:\Windows\Microsoft.NET\assembly\GAC_MSIL\
            // WindowsKey + E (Explorer)    %windir%\assembly
            // 
            // Problem - unable to use GAC assembly (copy local false = cannot find assembly)
            //
        // Value Type, Reference Type
        // Value        = Simple (Int, String, Bool), Enum, Struct, Nullable
        // Reference    = Class, Interface, Array, Delegate

        // nullable (int?, bool? .. etc)
        int? iNull = null; 

        // Anonymous collection, use like enum (myAnonymousVar.CompanyName)
        var myAnonymousVars = new { CompanyName = "Hi", Year = 2000 }; 

        // Set delegate like method
        delegate void PrintDel(string message);
        // Call delegate like class
        PrintDel print = new PrintDel(MyPrintMethod);
        // or assign delegate
        PrintDel print = PrintShort; // method 1
        log += PrintLong;          // method 2

         */

        /// <summary> Prints "Hello World!"
        /// </summary>
        public void PrintHello()
        {
            Console.WriteLine("S5 Hello World!");
        }



        // Assemblies (EXE/ DLL), GAC, private/ public class library
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
            // New Class Library project - IHSLibs - public string GetMyName() return "Ian..."
            // add reference (Dependencies, Projects, IHSLibs)
            // Using IHSLibs // need to import
            MyClassLogic IHSClass = new MyClassLogic();
            string myName = IHSClass.GetMyName();
            Console.WriteLine($"IHSClass = Name: {myName}");


            // Public - Cannot do with .NET Core (this project), need .NET Framework
            // AssemblyTest = .NET Framework
            // AssemblyTestLibrary = .NET Framework
            // New Class Library project - AssemblyTestLibrary - public void Print(message)
            //      Console.WriteLine($"Print from AssemblyTestLibrary: {message}");
            // GAC (Global Assembly Cache) = create key, sign project, install
            //      (create key) CMD Admin =     sn -k "myStrongKey.snk" // store this anywhere (desktop)
            //      (assign key) Visual Studio = properties - signing - sing the assembly (with key)
            //      (refrence) AssemblyTestLibrary - copy local property false
            //      (install) CMD Admin =   gacutil -i "C:\Users\ianea\source\repos\C8_In4Hours\AssemblyTestLibrary\bin\Debug\AssemblyTestLibrary.dll"
            //      (uninstall) CMD Admin = gacutil -u AssemblyTestLibrary
            // add reference (Dependencies, Assemblies, IHSLibs2)
            // Using AssemblyTestLibrary; // need to import

            // Need to update GAC when update Library
            // gacutil -i "C:\Users\ianea\source\repos\C8_In4Hours\AssemblyTestLibrary\bin\Debug\AssemblyTestLibrary.dll"
            // gacutil -u AssemblyTestLibrary

            /* AssemblyTest
            AssemblyTestLibraryLogic myName = new AssemblyTestLibraryLogic();
            Console.WriteLine($"Logic: {myName.GetMyName()}");
            myName.Print("Hello");
            Console.ReadLine();
            */

            CheckAssembly(1, 0); // System.Core
            CheckAssembly(1, 1); // AssemblyTestLibrary
            CheckAssembly(2, 2); // Full AssemblyTestLibrary location
        }
        public void CheckAssembly(int location, int name)
        {
            string locationStr = "";
            string nameStr = "";

            if (location == 0) locationStr = @"C:\Windows\assembly\"; // .NET 3.5 and below
            if (location == 1) locationStr = @"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\";
            if (location == 2) locationStr = @"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\AssemblyTestLibrary\v4.0_1.0.0.0__22e507a759643b56\";

            if (name == 0) nameStr = @"System.Core";
            if (name == 1) nameStr = @"AssemblyTestLibrary";
            if (name == 2) nameStr = @"AssemblyTestLibrary.dll";

            CheckAssembly(locationStr, nameStr);
        }
        public void CheckAssembly(string location, string name)
        {
            string file = location + name; // @"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\AssemblyTestLibrary.dll"

            Console.WriteLine($"\tLooking for: {file}");
            
            try
            {
                // System.Reflection
                AssemblyName testAssembly;

                testAssembly = AssemblyName.GetAssemblyName(file);
                
                Console.WriteLine($"\tYes, the file is an assembly : {testAssembly.FullName}");
                
                //Assembly myDll = Assembly.Load("AssemblyTestLibrary"); //AssemblyTestLibrary cannot find??
                //Console.WriteLine($"\t{myDll.FullName}");
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

        // Value vs Reference, Var, Nullable variables, Var acts like Enum without name (Anonymous Types)
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

        
        // Delegates and Multicast Delegates, pass method as param
        // defines method signature, looks for methods with the same return and paramaters
        public void Lesson5_3()
        {
            // e.g. delegate int Calculate(int first, int second);
            // look for:  return(int)   params(int, int)
            // found:	int Add (int x, int y)
            Console.WriteLine("");
            Console.WriteLine("");

            // Assign delegate either new Method or equals method
            Calculate cal = new Calculate(Add);
            //Calculate cal = new Calculate(Sub);
            // or
            //PrintDel log = PrintShort;

            Console.WriteLine(cal(10, 15)); // Could be either Add or Sub
            // or 
            // cal.Invoke(10, 15); 

            // Multicast delegates - Print methods
            PrintDel log = PrintShort; // method 1
            log += PrintLong;          // method 2

            log("Hello"); // Prints twice
        }
        // Lesson 5_3 delegates
        delegate int Calculate(int first, int second);
        delegate void PrintDel(string message);
        // Add, Sub and Print used for Lesson5_3
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
        public void PrintShort(string message)
        {
            Console.WriteLine($"\tPrint: {message}");
        }
        public void PrintLong(string message)
        {
            Console.WriteLine($"\tPrint from Long: {message}");
        }

        // Anonymous Methods and Lambda Expressions
        // In-line anonymous method/ using =>
        public void Lesson5_4()
        {
            //MyDelegate del = (string msg) =>  Console.WriteLine(msg);
        }

        // Generics and Events, Gen vs Array, lists and methods acting on other methods actions
        public void Lesson5_5()
        {

        }

        // Asynchronous Programming, Await Win Forms, keep app running, click and move on
        public void Lesson5_6()
        {

        }
    }
}
