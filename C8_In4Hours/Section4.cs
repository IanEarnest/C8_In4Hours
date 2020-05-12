using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    /// <summary>
    /// Section 4 = 
    /// Section 4. OOP 1
    ///       Object-Oriented Programming in C#
    ///   4.1 Encapsulation, classes, objects, data members, properties
    ///   4.2 Inheritance, child classes, base classes
    ///   4.3 Abstraction, override
    ///   4.4 Polymorphism, interface vs abstract
    ///   4.5 Concepts Related to Object Oriented Programming
    ///       Read-only, constants, protected, partial, static classes
    /// </summary>
    class Section4
    {
        /* Notes
        A
         */
        
        /// <summary> Prints "Hello World!"
        /// </summary>
        public void PrintHello()
        {
            Console.WriteLine("S4 Hello World!");
        }


        
       
       
       
       
       

        //Section 4. OOP 1
        //  Object-Oriented Programming in C#
        //  Encapsulation, classes, objects, data members, properties
        // Encapsulation = keeping data private
        public void Lesson4_1()
        {
            //Encapsulation, classes
            // In Car class, 
            //      _model          = private
            //      PreviousOwners  = read-only

            // Access Modifier - Public, Private
            // private member uses _, _myInt
            // public property (get/ set), get = return, set = value (shorthand = propfull)
            // public int Year { get; set; } // quicker



            //Class Car - car model, year, colour, maxSpeed

            // Car 1 = all fail
            Section4_Car myCar1 = MyCarDetails("Car 1", 1800, Section4_Car.CarColours.Grey, 70);
            CheckMyCar(myCar1);

            // Car 2 = all pass
            MyCarDetailsAndCheck(0, "Car 2", 2000, Section4_Car.CarColours.Red, 90);
            
            // Car 3 = pass and fail
            MyCarDetailsAndCheck(0, "Car 3", 2000, Section4_Car.CarColours.Red, 60);
            

            
        }

        // For Lesson4_2 & 4_3, create class Car
        // Returns Car, used for CheckMyCar
        public Section4_Car MyCarDetails(string model, int year, Section4_Car.CarColours colour, int maxSpeed)
        {
            //Section4_Car myCar1 = MyCarDetails("H1", 2000, Section4_Car.CarColours.Grey, 70);
            Section4_Car myCar = new Section4_Car();

            myCar.Model = model;        //"H1";
            myCar.Year = year;          //1800;
            myCar.Colour = colour;      //Section4_Car.CarColours.Grey;
            myCar.MaxSpeed = maxSpeed;  //70;
            //CheckMyCar(myCar);
            return myCar;

            /* OLD CODE
            Section4_Car myCar1 = new Section4_Car();

            myCar1.Model = "H1";
            myCar1.Year = 1800;
            myCar1.Colour = Section4_Car.CarColours.Grey;
            myCar1.MaxSpeed = 70;
            //myCar1.PreviousOwners = 1; // read only
            Console.WriteLine("My Car 1");
            Console.WriteLine($"isPassed: {myCar1.CheckCar(myCar1)}");
            Console.WriteLine($"Owners: {myCar1.PreviousOwners}");
            Console.WriteLine("");
            */
        }
        // Same as above, no returns, just prints, contains int for which class to use, PrevOwners used only 
        // for ManualTrans
        public void MyCarDetailsAndCheck(int carClass, string model, int year, Section4_Car.CarColours colour, int maxSpeed,
            int PrevOwners = -1)
        {
            // Choosing which class to use, Car, Manual Car or Auto Car
            // Car makes random Previous owners, manual/ auto makes 0, (3) manual can adjust Prev owners
            if(carClass == 0) { 
                Section4_Car myCar = new Section4_Car
                {
                    Model = model,
                    Year = year,
                    Colour = colour,
                    MaxSpeed = maxSpeed,
                };
                CheckMyCar(myCar);
            }
            else if (carClass == 1)
            {
                // Manual always set to 0
                Section4_ManualTrans myCar = new Section4_ManualTrans(0)
                {
                    Model = model,
                    Year = year,
                    Colour = colour,
                    MaxSpeed = maxSpeed,
                };
                CheckMyCar(myCar);
            }
            else if (carClass == 2)
            {
                // Auto always set to 0
                Section4_AutoTrans myCar = new Section4_AutoTrans(0)
                {
                    Model = model,
                    Year = year,
                    Colour = colour,
                    MaxSpeed = maxSpeed,
                };
                CheckMyCar(myCar);
            }
            // Manual variation
            else if (carClass == 3)
            {
                // This is only case PrevOwners should not be -1
                Section4_ManualTrans myCar = new Section4_ManualTrans (PrevOwners)
                {
                    Model = model,
                    Year = year,
                    Colour = colour,
                    MaxSpeed = maxSpeed,
                };
                CheckMyCar(myCar);
            }
        }
        // Printing Car model, CheckCar results and previous owners
        public void CheckMyCar(Section4_Car myCar)
        {
            // Print/ check car
            Console.WriteLine($"My Car {myCar.Model}");
            Console.WriteLine($"isPassed: {myCar.CheckCar(myCar)}"); // myCar.CheckCar(myCar2)...
            Console.WriteLine($"Owners: {myCar.PreviousOwners}");
            Console.WriteLine("");
        }
        
        

        //  4.2 Inheritance, child classes, base classes
        public void Lesson4_2()
        {
            // Inheritance
            // Automatic/ Manual class
            // class Section4_ManualTrans : Section4_Car
                //vitrual method = overridable method
                // needs to be public to be overridden
                //base.run // base class
                // car()        // constructor of base
                // car(engine) // second constructor of base
                // auto(engine):base(engine) // override constructor of base class
            

            // 0 = car, 1 = manual, 2 = auto, 3 = manual (modify prev owners)
            //AutoTrans class   - Always passes     no previous owners   output different messages
            //ManualTrans class - Always fails      no previous owners   modify previous owners

            // Prev Owners = -1 // this means unused, optional param, only used for 3 (ManualTrans)

     
            // Car 5 = AutoTrans - passes (fail values), no prev, change message
            MyCarDetailsAndCheck(2, "Car 4 - AutoTrans", 1800, Section4_Car.CarColours.Gold, 90);


            // Car 6 = ManualTrans - fails, no previous
            MyCarDetailsAndCheck(1, "Car 5 - ManualTrans", 2000, Section4_Car.CarColours.Gold, 90);
            // Car 7 = ManualTrans - fails, change previous owners
            MyCarDetailsAndCheck(3, "Car 6 - ManualTrans", 2000, Section4_Car.CarColours.Gold, 90,
                                  55);
        }
        //  4.3 Abstraction, override
        public void Lesson4_3()
        {

        }
        //  4.4 Polymorphism, interface vs abstract
        public void Lesson4_4()
        {

        }
        //  4.5 Concepts Related to Object Oriented Programming
        //   Read-only, constants, protected, partial, static classes
        public void Lesson4_5()
        {

        }
    }
}
