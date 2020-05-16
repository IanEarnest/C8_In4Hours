using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    class Section4_AutoTrans : Section4_Car
    {
        public Section4_AutoTrans()
        {
            //base.PreviousOwners = 0;
        }

        public Section4_AutoTrans(int PrevOwners) : base(PrevOwners)
        {
            base.Print(true, "AutoTrans = Passed - print modified"); // base class
            //base.CarColours.Gold = 100;
        }



        public override bool CheckCar(Section4_Car car)
        {
            Print(true, $"All passed");
            return true;
        }
        

        /// <summary> Print pass/ fail messages, Count pass/ fails
        /// <para> isPassed, message, e.g. Print (pass, "Max speed passed")</para>
        /// </summary>
        public override void Print(bool isPassed, string message)
        {
            /*
            if (isPassed)
                countPass++;
            if (!isPassed)
                countFail++;
            */
            Console.WriteLine($"\t{message} + Auto");
        }

        // Abstract
        public override void PrintHello()
        {
            Console.WriteLine($"\t Hello from Car Auto");
            //throw new NotImplementedException();
        }
    }
}
