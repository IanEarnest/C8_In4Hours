﻿using AssemblyTestLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyTestLibraryLogic myName = new AssemblyTestLibraryLogic();
            Console.WriteLine($"Logic: {myName.GetMyName()}");
            myName.Print("Hello");
            Console.ReadLine();
        }
    }
}
