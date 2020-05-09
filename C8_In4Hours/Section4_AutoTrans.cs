using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    class Section4_AutoTrans : Section4_Car
    {
        public Section4_AutoTrans()
        {
            base.Print(true, "Passed"); // base class
        }



        /// <summary> Print pass/ fail messages, Count pass/ fails
        /// <para> isPassed, message, e.g. Print (pass, "Max speed passed")</para>
        /// </summary>
        public override void Print(bool isPassed, string message)
        {
            if (isPassed)
                countPass++;
            if (!isPassed)
                countFail++;
            Console.WriteLine($"\t{message} + Auto");
        }
    }
}
