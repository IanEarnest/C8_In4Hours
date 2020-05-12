using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    class Section4_ManualTrans : Section4_Car
    {

        public Section4_ManualTrans() : base()
        {
            //base.PreviousOwners = 0;
        }

        public Section4_ManualTrans(int PrevOwners) : base(PrevOwners)
        {
            //base.PreviousOwners = PrevOwners; // read only for child/ parent?
        }


        public override bool CheckCar(Section4_Car car)
        {
            return false;
        }

        // Abstract
        public override void PrintHello()
        {
            Console.WriteLine($"\t Hello from Car Manual");
            //throw new NotImplementedException();
        }
    }
}
