using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyTestLibrary
{
    public class AssemblyTestLibraryLogic
    {
           public string GetMyName()
        {
            return "IanHS2";
        }

        public void Print(string message)
        {
            Console.WriteLine($"Print from AssemblyTestLibrary: {message}");
        }
        public static void MyPrint(string message)
        {
            Console.WriteLine($"Print from AssemblyTestLibrary: {message}");
        }
    }
}
