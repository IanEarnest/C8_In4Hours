using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    public class Section4_EagleCourier_NA : Section4_CourierServiceBase
    {
        public Section4_EagleCourier_NA()
        {
            this._companyRegistration = "EAGLE-NA1";
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
