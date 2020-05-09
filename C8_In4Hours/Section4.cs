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

            // Access Modifier - Public, Private
            // private member uses _, _myInt
            // public property (get/ set), get = return, set = value (shorthand = propfull)
            // public int Year { get; set; } // quicker


            //Class Car
            // car model, year, colour, maxSpeed
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


            Section4_Car myCar2 = new Section4_Car 
            {
                Model = "H2",
                Year = 2000,
                Colour = Section4_Car.CarColours.Red,
                MaxSpeed = 90,
            };

            Console.WriteLine("My Car 2");
            Console.WriteLine($"isPassed: {myCar2.CheckCar(myCar2)}");
            Console.WriteLine($"Owners: {myCar2.PreviousOwners}");
            Console.WriteLine("");

            Section4_Car myCar3 = new Section4_Car
            {
                Model = "H3",
                Year = 2000,
                Colour = Section4_Car.CarColours.Red,
                MaxSpeed = 60,
            };
            Console.WriteLine("My Car 3");
            Console.WriteLine($"isPassed: {myCar3.CheckCar(myCar3)}");
            Console.WriteLine($"Owners: {myCar3.PreviousOwners}");
            Console.WriteLine("");
        }
        //  4.2 Inheritance, child classes, base classes
        public void Lesson4_2()
        {
            // Inheritance
            // automatic/ manual class
            // class Section4_ManualTrans : Section4_Car

            //vitrual method = overridable method
            //base.run // base class
            // car()
            // car(engine) // second constructor
            // auto(engine):base(engine)
            // needs to be public to be overridden

            // AutoTrans - passes and change message
            Section4_AutoTrans myCar4 = new Section4_AutoTrans
            {
                Model = "H4",
                Year = 2000,
                Colour = Section4_Car.CarColours.Gold,
                MaxSpeed = 90,
            };

            Console.WriteLine("My Car 4 - AutoTrans");
            Console.WriteLine($"isPassed: {myCar4.CheckCar(myCar4)}");
            Console.WriteLine($"Owners: {myCar4.PreviousOwners}");
            Console.WriteLine("");


            // ManualTrans - fails and no previous
            Section4_ManualTrans myCar5 = new Section4_ManualTrans
            {
                Model = "H5",
                Year = 2000,
                Colour = Section4_ManualTrans.CarColours.Gold,
                MaxSpeed = 90,
            };

            Console.WriteLine("My Car 5 - ManualTrans");
            Console.WriteLine($"isPassed: {myCar5.CheckCar(myCar5)}");
            Console.WriteLine($"Owners: {myCar5.PreviousOwners}");
            Console.WriteLine("");


            Section4_ManualTrans myCar5_1 = new Section4_ManualTrans(0) // 0 previous owners
            {
                Model = "H4_1",
                Year = 2000,
                Colour = Section4_Car.CarColours.Gold,
                MaxSpeed = 90,
            };

            Console.WriteLine("My Car 5_1 - ManualTrans");
            Console.WriteLine($"isPassed: {myCar5_1.CheckCar(myCar5_1)}");
            Console.WriteLine($"Owners: {myCar5_1.PreviousOwners}");
            Console.WriteLine("");
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
