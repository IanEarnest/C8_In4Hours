using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    class Section4_CarFull : Section4_Car, Section4_IConvertableCar
    {
        public override void PrintHello()
        {
            Console.WriteLine($"\t Hello from Car Full");
            //throw new NotImplementedException();
        }

        bool roofUp;
        public bool ChangeRoofTop() 
        {
            roofUp = !roofUp;
            Console.WriteLine($"\tChanged roof top, now roof up = {roofUp}");
            return roofUp;
        }
    }
}
