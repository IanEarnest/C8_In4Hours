using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace C8_In4Hours
{
    class Section4_Car
    {
        // Constructor 
        public Section4_Car()
        {
            PreviousOwners = new Random().Next(1, 10);
        }

        public Section4_Car(int PrevOwners)
        {
            PreviousOwners = PrevOwners;
        }

        // car model, year, colour, maxSpeed

        private string _model;

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }


        public int Year { get; set; }
        public CarColours Colour { get; set; }
        public int MaxSpeed { get; set; }
        
        // Read only
        public int PreviousOwners { get; }

        

        public enum CarColours
        {
            Grey = 0,
            Red = 1,
            Green = 2,
            Purple = 5,
            Gold = 100,
        }
        /// <summary>
        /// Check car is defined and has a good standards
        /// maxspeed over 80, colour not grey, year above 1900
        /// </summary>
        /// <param name="car"></param>
        /// <returns>Bool</returns>
        public virtual bool CheckCar(Section4_Car car)
        {
            bool isAllPassed = false;
            string preMessagePass = "Pass - ";
            string preMessageFail = "Fail - ";

            if (car.MaxSpeed > 80)
                Print(true, $"{preMessagePass} Max speed ");
            else
                Print(false, $"{preMessageFail} Max speed");


            if (car.Colour != CarColours.Grey)
                Print(true, $"{preMessagePass} Colour");
            else
                Print(false, $"{preMessageFail} Colour");


            if (car.Year > 1900)
                Print(true, $"{preMessagePass} Year");
            else
                Print(false, $"{preMessageFail} Year");


            Console.WriteLine($"\tPass: {countPass} \t Fail: {countFail}");
            // If no fails, then pass
            if (countFail == 0)
                isAllPassed = true;
            //maxspeed over 80, colour not grey, year above 1900
            return isAllPassed;
        }
        public int countPass = 0;
        public int countFail = 0;

        /// <summary> Print pass/ fail messages, Count pass/ fails
        /// <para> isPassed, message, e.g. Print (pass, "Max speed passed")</para>
        /// </summary>
        public virtual void Print(bool isPassed, string message)
        {
            if (isPassed)
                countPass++;
            if (!isPassed)
                countFail++;
            Console.WriteLine($"\t{message}");
            // write?
        }
    }
}
