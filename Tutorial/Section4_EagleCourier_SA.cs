using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    public partial class Section4_EagleCourier_SA : Section4_CourierServiceBase
    {
        public Section4_EagleCourier_SA()
        {
            this._companyRegistration = "EAGLE-SA1";
        }

        public override void SendItemsByAir(string item)
        {
            Packing(item);
            Console.WriteLine($"Sending: {item}, by Air");// print sending item
        }

        public override void SendItemsByRoad(string item)
        {
            Packing(item);
            Console.WriteLine($"Sending: {item}, by Road");// print sending item
        }
    }
}
