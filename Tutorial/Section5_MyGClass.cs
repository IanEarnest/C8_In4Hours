using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{
    class Section5_MyGClass<T>
    {
        public void Print(T param)
        {
            Console.WriteLine($"MyGClass: {param}");
        }
    }
}
