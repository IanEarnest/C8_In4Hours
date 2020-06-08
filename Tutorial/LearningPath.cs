using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{
    class LearningPath
    {
        /* Reminders/ Useful
         
           Programming day = 3h code, 2h comms/plans, 1h learning

        // Question - Struct? vs enum?
        // Question - uses of string.empty
        // Question - valid uses of stringbuilder
        // Question - "Interpolation"
        // Question - useful encapsulation?
        // Question - why use abstract instead of inheriting (hides class?)
        // Question - GAC for .NET Core?
        // Question - mutable vs immutable (change state and don't change state)
        //(encapsulation - change of variables)


       // Make all Sections examples fit the same case (e.g. BugFixer (bugname, description etc))
        // Ideas - sorting Arrays (myArray.Sort(myArray, highestFirst))
            // Email client - class (send email, inbox, mail has address, from, header, body)
            // Trip planner - store Hotel reservations tickets, weblinks, important phone numbers, addresses of places to visit and restaurants
            // GAC - create key, install, uninstall from an interface
            // ?Build/ Compile, CLR(JIT), MSIL, Machine Language
            // AFTER = Old projects, basic examples to put on portfolio

        /// Section 4 = https://raygun.com/blog/oop-concepts-java/
        /// create concept: ice cream machine - donut(with/ without holes)
        ///                 Series/ films/ netflix
        ///                 Operating system
        ///                 Email, Messaging, Trello/ Basecamp, Evernote
        ///                 Browser (file checker/ Google Drive/ explorer.exe)
        ///                 Internet (firefox)
        ///                 MSPaint, Excel, Solitaire
        ///                 Wordpress
        ///                 Accounting - quickbooks
        ///                 Payment - paypal
        ///                 Social - TweetDeck, Buffer, Hootsuite
        ///                 Medical industry?

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
         */

        /* Learning C# full list
        
           0. C constructs
           0. basic Data Structures
           0. high level idea of OOP
        
           1. What is C#/ why Microsoft created C# in 2002 
               what is the .NET framework
               what are managed/ unmanaged languages
           2. why to use StringBuilder class
           3. boxing and unboxing, typecasting, stack and heap
           4. inheritance in C#, types (Single, Multilevel and Hierarchical)
           5. specific scenarios for Abstract, partial and static classes
           6. Custom exceptions
           7. ArrayList, HashSet, HashTable, List<T>, Dictionary<T>, Tuple
           8. interfaces IEnumerable<T>, ICollection<T>, IList<T> and when to use appropriately
           foreach loop - only 
           IEnumerable<T> collections or 
           System.Array data structures can iterate through
           9. Learn how to compare and sort complex objects using IComparble<T> and IComparer<T> interface
           10. create indexers 
           11. LINQ - Learn the LINQ operators(from, let, select, in, group by, order by). Learn the importance of LINQ. There are 2 ways to write a LINQ query one is the query syntax and other is using Extension methods, learn them both.
           12. File handling, file/ TextWriter/ StreamWriter classes, serialization and deserialization
           BinaryFormatter class(BinarySerialization). JSON and XML Serialization
           13. Threads
           14. task, difference between Task and Task<T> and go through the Task Parallel Library

           And then
           Webforms (or Razor pages)
           MVC
           WPF + MVVM?
           MDI forms in WPF?
           SQL Server (Express?)
           Web Services
           WCF
           Web API
           15.? Forms
           16. WPF and XAML
           Xamarin forms
           Bot Framework and LUIS

           Tech question - why interface instead of just multiple inheritance


           16. WPF - 
           XAML: Learn about XAML and how it is used in WPF applications.
           Layout: Learn about layout panels and how they are used to construct user interfaces.
           Data binding: Learn how WPF data binding works and how it can be used.
           Data templates and triggers: Learn how data templates and triggers work and how they can be used.
           Styles: Learn about how UIs can be styled in WPF.

           winforms/ wpf
               Winforms = GUI for .net framework desktop apps
               WPF = 2006, vector GUI 
           WPF
               Extendable (but more complicated)
               Seperate UI and Logic
               Storyboarding + animation tools, 3D graphics...
               Databinding better? virtualisation
               data/ control templates	
               XAML design (even when VS Designer is off)

           WinForm life = Load, Activate, Deactivate, Closing, Closed, Dispose of


            // examples?
            #define 
            #if 
            #elif 


            //What?
            static string F(Func<string> func) => func();
           */
    }
}
