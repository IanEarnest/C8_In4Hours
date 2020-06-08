using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using IHSLibs;
using Tutorial;

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
        
        // Value Type, Reference Type
        // Value        = Simple (Int, String, Bool), Enum, Struct, Nullable
        // Reference    = Class, Interface, Array, Delegate

        // nullable (int?, bool? .. etc)
        int? iNull = null; 

        // var 
        var myVar = "";
        dynamic myDy; // used for properties or returning values from a function
        Console.WriteLine($"Var: '{nameof(varA)}', Value: {varA}, Type: {varA.GetType()}");

        // Anonymous collection, use like enum (myAnonymousVar.CompanyName)
        var myAnonymousVars = new { CompanyName = "Hi", Year = 2000 }; 

        // Set delegate like method
        delegate void PrintDel(string message);
        // Call delegate like class
        PrintDel print = new PrintDel(MyPrintMethod);
        // or assign delegate
        PrintDel print = PrintShort; // method 1
        log += PrintLong;          // method 2


            "LessonExtend" from a tutorial, not working
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


            // Var
            var varA = "var a";
            var varB = 'b';
            var varC = 3;
            Console.WriteLine($"Var: '{nameof(varA)}', Value: {varA}, Type: {varA.GetType()}");
            Console.WriteLine($"Var: '{nameof(varB)}', Value: {varB}, Type: {varB.GetType()}");
            Console.WriteLine($"Var: '{nameof(varC)}', Value: {varC}, Type: {varC.GetType()}");

            // Dynamic
            // checks at runtime not compiletime
            // used for properties or returning values from a function
            dynamic dynA = "dyn a";
            dynamic dynB = 'b';
            dynamic dynC = 3;
            Console.WriteLine($"Dynamic: '{nameof(dynA)}', Value: {dynA}, Type: {dynA.GetType()}");
            Console.WriteLine($"Dynamic: '{nameof(dynB)}', Value: {dynB}, Type: {dynB.GetType()}");
            Console.WriteLine($"Dynamic: '{nameof(dynC)}', Value: {dynC}, Type: {dynC.GetType()}");
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
            //Calculate cal = new Calculate(Add);
            //Calculate cal = new Calculate(Sub);
            // or
            //Calculate cal = Add;

            Calculate cal = new Calculate(Add);
            Console.WriteLine($"delegate cal: {cal(10, 15)}"); // Could be either Add or Sub
            // or 
            // cal.Invoke(10, 15); 

            // Multicast delegates - Print methods
            PrintDel log = PrintShort; // method 1
            log += PrintLong;          // method 2

            log("Multicast delegate = Print log x 2: Log"); // Prints twice
        }
        // Lesson 5_3 delegates
        public delegate int Calculate(int first, int second);
        public delegate void PrintDel(string message);
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
            Console.WriteLine($"\tPrintShort: {message}");
        }
        public void PrintLong(string message)
        {
            Console.WriteLine($"\tPrintLong: {message}");
        }


        // Same as PrintDel
        //public delegate void PrintDelegate(string param);
        public void PrintShortDel(PrintDel message)
        {
            Console.WriteLine("PrintShortDel(PrintDel) called");
            message("Callback"); // callback with "message"
        }
        // Anonymous Methods and Lambda Expressions
        // In-line anonymous method/ using =>
        public void Lesson5_4()
        {
            // Anonymous method = inline without name
            // public delegate void PrintDel(string message);
            // public void PrintShortDel(PrintDel message)
            int i = 0;


            // Calling above method "PrintShortDel" + printing message from that method "Callback"
            // Performs "PrintShortDel" first then the delegate methods


            // inline (named method) using Lambda
            PrintDel log = (message) => Console.WriteLine($"{message}");
            log("Inline delegate Lambda");


            // delegate (printDelegate) contains PrintShort(string message) method
            //"PrintShortDel(PrintDel) called"
            //          PrintShort: Callback
            //          PrintShort: "PrintDel calling PrintShort"
            PrintDel HiPrint1 = new PrintDel(PrintShort);
            PrintShortDel(HiPrint1);
            HiPrint1("PrintDel calling PrintShort");

            // Anonymous method using Lambda
            //delegate void PrintDel(string message);
            //"PrintShortDel(PrintDel) called"
            //          L0: Callback
            //          L0: "PrintDel calling PrintShort"
            PrintDel HiPrint2 = new PrintDel((message) => Console.WriteLine($"\tL0:{message}"));
            PrintShortDel(HiPrint2);
            HiPrint2("PrintDel calling PrintShort");

            // Delegate anonymous method - inline
            //"PrintShortDel(PrintDel) called"
            //          "Print: Callback 1""
            i++;
            PrintShortDel(delegate (string message)
            {
                Console.WriteLine($"\tPrint: {message} {i}");
            });



            //Lambda
            // params, statement (delegate)
            //=>


            // Single line Lambda for PrintShortDel(PrintDel)
            //"PrintShortDel(PrintDel) called"
            //          "L1: Callback 2""
            i++;
            PrintShortDel((message) => Console.WriteLine($"\tL1: {message} {i}"));


            // Multi-line Lambda for PrintShortDel(PrintDel)
            //"PrintShortDel(PrintDel) called"
            //          "L2.1: Callback 3""
            //          "L2.2: Callback 3""
            i++;
            PrintShortDel((message) =>
            {
                Console.WriteLine($"\tL2.1: {message} {i}");
                Console.WriteLine($"\tL2.2: {message} {i}");
            });



            //C#1               - initialization with named method
            //PrintDel HiPrint1 = new PrintDel(PrintShort);
            //C#2               - initialization with inline code
            //PrintDel HiPrint1 = delegate (string message) { Console.WriteLine($"\{message}"); };
            //C#3               - initialization with lambda expression
            //PrintDel HiPrint1 = (message) => { Console.WriteLine($"{message}"); };
        }
        public void LessonExtend()
        {
            // Other stuff
            Console.WriteLine($"11am: {GetGreetingM(11)}"); // 11am
            // vs
            Console.WriteLine($"1pm: {GetGreeting(13)}"); // afternoon

            Console.WriteLine($"Greeting: {Greeting()}");


            // Extend method - not working
            string myButton = new StringBuilder()
                .Append("Hello ")
                //.AppendWhen(" my ", isMy)
                .Append("World")
                .ToString();
            Console.WriteLine($"StringBuilder {myButton}"); // Hello World
            // AppendWhen = true
            //AppendWhen(new StringBuilder(), "hi", true); // use above in myButton?
            Console.WriteLine($"StringBuilder extend {myButton}"); // Hello my World
        }
        public string GetGreeting(int hour) => hour < 12 ? "Good Morning" : "Good Afternoon";
        public string GetGreetingM(int hour)
        {
            string greeting; // placeholder

            if (hour < 12)
                greeting = "Good Morning";
            else
                greeting = "Good Afternoon";

            return greeting;
        }
        public string Greeting() => new StringBuilder()
            .Append("Hello ")
            .Append(" World ")
            .ToString()
            .TrimEnd()
            .ToUpper(); // HELLO WORLD

        //public StringBuilder AppendWhen(this StringBuilder sb, string value, bool predicate) 
        //    => predicate ? sb.Append(value) : sb;

        // Generics and Events, Gen vs Array, lists and methods acting on other methods actions
        public void Lesson5_5()
        {
            // Generic class/ method, <T> (type parameter)

            //  class Section5_MyGClass<T> //<T> added to make it generic
            //      public void Print(T param)
            Console.WriteLine("");
            Console.WriteLine("");

            // Generic - string
            Section5_MyGClass<string> strGClass = new Section5_MyGClass<string>();
            strGClass.Print("My String");

            // Generic - int
            Section5_MyGClass<int> intGClass = new Section5_MyGClass<int>();
            intGClass.Print(10);

            // List VS Arrays
            List<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(5);
            Console.WriteLine($"intList: 0={intList[0]}");


            // Events - publisher/ subscriber
            /*
                
                Section5_CustClass
	                CustID property
	                CustName property

                Section5_CustEventArg
	                CustName property
	                Store property

                Section5_CustBiz
                public event EventHandler<Section5_CustEventArg> customerAdded;
	                AddCustomer(Section5_CustClass cust)
		                print "adding a new customer"
		                System.Threading.Thread.Sleep(3000); // Wait for 3 seconds
		                this.CusAdded...
             */

            // New CustomerBiz class, add event listener onto method, add customer
            Section5_CustomerBiz objCustomerBiz = new Section5_CustomerBiz();
            objCustomerBiz.CustomerAdded += objCustomerBiz_CustomerAdded;

            Section5_Customer newCustomer = new Section5_Customer()
            {
                CustomerID = 12,
                CustomerName = "Steve"
            };

            // Add customer contains wait method
            objCustomerBiz.AddCustomer(newCustomer);
            objCustomerBiz.AddCustomer((new Section5_Customer { CustomerID = 22, CustomerName = "John" }));
        }

        //class Section5_CustomerEventArg
        //public string StoreName { get; set; }
        // public string CustomerName { get; set; }
        static void objCustomerBiz_CustomerAdded(object sender, Section5_CustomerEventArg e)
        {
            Console.WriteLine($"Customer: {e.CustomerName} added to store {e.StoreName}");
        }


        // Asynchronous Programming, Await Win Forms, keep app running, click and move on
        public void Lesson5_6()
        {
            /* Using the IssueTrackerApp form
             Windows forms app - two buttons (button1, button2) and a Calcualte method

             // Artificial wait
                private int Calculate()
                {
	                int total = 40;
	                System.Threading.Thread.Sleep(3000);
	                return total;
                }


                // button1
                "private void mybutton1"
                {
	                int result = 0;
	                result = Calculate();
	                MessageBox.Show($"Result : {result}");	
                }

                // button2 async
                "private async void mybutton2"
                {
	                // task int = int calculate
	                Task<int> task = new Task<int>(Calculate);
	                task.Stat();
	                result = await task;
	                MessageBox.Show($"Result : {result}");
                }
             */
        }
    }
}
