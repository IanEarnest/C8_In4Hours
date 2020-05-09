using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    class Section4_ManualTrans : Section4_Car
    {

        public Section4_ManualTrans()
        {
            //PrevOwners = 0; //?
            //base.PreviousOwners = 0;
            //base.CarColours.Gold = 100;
        }

        public Section4_ManualTrans(int PrevOwners) : base(PrevOwners)
        {
            //base.PreviousOwners = PrevOwners; // read only for child/ parent?
            PrevOwners = 0; //?
        }


        public override bool CheckCar(Section4_Car car)
        {
            return false;
        }
    }
}
