using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    public static class Section4_MyConstants
    {
        public const string APP_EU = "English";
    }

    public static class Section4_Helper
    {
        public static int count;
        public static void Log(string message) 
        {
            count++;
            Console.WriteLine($"Log {count}: {message}");
        }
    }
}
