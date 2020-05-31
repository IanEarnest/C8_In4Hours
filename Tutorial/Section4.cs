using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    /// <summary>
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
        Encapsulation 	= keeping data private
        Inheritance	    = child class, use methods from another
        Abstraction  	= hide class, modify abstract method
        Polymorphism	= child/ using derived classes
        interface vs abstract = inheritance, use of methods 

        Constants/ Read-only
        Object initialiser (ToString)
        Access modifiers (Protected, internal)
        Classes (partial/ static)
         */

        /// <summary> Prints "Hello World!"
        /// </summary>
        public void PrintHello()
        {
            Console.WriteLine("S4 Hello World!");
        }


        
       
       
       
       
       


        // For Lesson4_2 & 4_3, create class Car
        // Returns Car, used for CheckMyCar
        public Section4_CarFull MyCarDetails(string model, int year, Section4_Car.CarColours colour, int maxSpeed)
        {
            //Section4_Car myCar1 = MyCarDetails("H1", 2000, Section4_Car.CarColours.Grey, 70);

            Section4_CarFull myCar = new Section4_CarFull();
            //Section4_Car myCar = new Section4_Car();

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

             
            /* Other
             // inline
                Section4_Car myCar2 = new Section4_Car()
                {
                    Model = model,
                    Year = year,
                    Colour = colour,
                    MaxSpeed = maxSpeed,
                };
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
                Section4_ManualTrans myCar = new Section4_ManualTrans
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


        //  4.1 Encapsulation, classes, objects, data members, properties, Encapsulation = keeping data private
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
            Section4_CarFull myCar1 = MyCarDetails("1 - all fail", 1800, Section4_Car.CarColours.Grey, 70);
            CheckMyCar(myCar1);

            // Car 2 = all pass
            Section4_CarFull myCar2 = MyCarDetails("2 - all pass", 2000, Section4_Car.CarColours.Red, 90);
            CheckMyCar(myCar2);

            // Car 3 = pass and fail
            Section4_CarFull myCar3 = MyCarDetails("3 - pass and fail", 2000, Section4_Car.CarColours.Red, 60);
            CheckMyCar(myCar3);
        }

        //  4.2 Inheritance, child classes, base classes, use methods from another class, virtual
        public void Lesson4_2()
        {
            // Inheritance
            // Automatic/ Manual class
            // class Section4_ManualTrans : Section4_Car
                //vitrual method = overridable method
                // needs to be public to be overridden
                // base.run // base class
                // car()        // constructor of base
                // car(engine) // second constructor of base
                // auto(engine):base(engine) // override constructor of base class
            

            // 0 = manual(was car), 1 = manual 0 prev, 2 = auto, 3 = manual (modify prev owners)
            //AutoTrans class   - Always passes     no previous owners   output different messages
            //ManualTrans class - Always fails      no previous owners   modify previous owners

            // Prev Owners = -1 // this means unused, optional param, only used for 3 (ManualTrans)

     
            // Car 4 = AutoTrans - passes (fail values), no prev, change message
            MyCarDetailsAndCheck(2, "4 - AutoTrans", 1800, Section4_Car.CarColours.Gold, 90);


            // Car 5 = ManualTrans - fails, no previous
            MyCarDetailsAndCheck(1, "5 - ManualTrans 0", 2000, Section4_Car.CarColours.Gold, 90);
            // Car 6 = ManualTrans - fails, change previous owners
            MyCarDetailsAndCheck(3, "6 - ManualTrans 55", 2000, Section4_Car.CarColours.Gold, 90,
                                  55);
        }

        //  4.3 Abstraction, override, hide class, modify abstract method
        public void Lesson4_3()
        {
            // Manual/ AutoTrans uses car.PrintHello() differently

            // Abstract, cannot create instance, only inherited
                // Section4_Car myCar = new Section4_Car(); // Cannot use
            // public abstract class Car // // atleast 1 abstract class (cannot use car, only Auto or Manual)
                // public abstract void PrintHello();


            // Car 7 = Print hello
            Section4_CarFull myCar = MyCarDetails("7 - hello", 2000, Section4_Car.CarColours.Red, 60);
            myCar.PrintHello(); // Abstract
            CheckMyCar(myCar);
        }

        //  4.4 Polymorphism, using derived/ child classes, changing assignments (Car with CarManual/ CarAuto)
        // Hello from Car Manual
        public void Lesson4_4()
        {
            // Car 8 = Print hello
            Section4_Car myCar;
            myCar = new Section4_ManualTrans();
            //myCar = new Section4_AutoTrans();
            //myCar = new Section4_CarFull();
            myCar.PrintHello(); // Hello from Car Manual
            

            // Polymorphism
            // Parent can point to any derived classes
            // Car myCar
            // myCar = new Section4_CarManual // Section4_ManualTrans : Car
            // myCar = new Section4_CarAuto   // Section4_AutoTrans : Car
            // myCar = new Section4_CarFull   // Section4_CarFull : Car
            // myCar.PrintHello();
        }

        //interface vs abstract
        // Hello from Car Full
        // Roof top change
        public void Lesson4_4_2()
        {
            // abstract = half blind = we know some properties/ methods to be used
            // abstract = constants, method stubs and members   single inheritance
            // Car 8 = Print hello - abstract
            Section4_CarFull myCar = new Section4_CarFull();
            myCar.PrintHello();
            /*  
             *  "CarFull" inherits abstract class "Car" and contains "PrintHello()" abstract method
            public abstract class Section4_Car
                public abstract void PrintHello();

             class Section4_CarFull : Section4_Car    // inherit/ contains abstract
                public override void PrintHello()
                     Console.WriteLine($"\t Hello from Car Full");
                    */
                


            // interface = blind = don't know implementation (just properties and methods names)
            // interfaces = constants and method stubs          multiple inheritance
            // Car 8 = Change roof top - interface
            // Keep everything private except interface methods
            Section4_IConvertableCar myCar2 = new Section4_CarFull();
            myCar2.ChangeRoofTop(); // Method only in Section4_IConvertableCar
            myCar2.ChangeRoofTop();
            /* 
             * "CarFull" inherits interface class "IConvertableCar" and contains "ChangeRoofTop()" method
             public interface Section4_IConvertableCar
                bool ChangeRoofTop(); // only declare methods

            class Section4_CarFull : Section4_Car, Section4_IConvertableCar // Multiple inheritance
                public bool ChangeRoofTop()
                   Console.WriteLine($"changed roof top, now roof up = {roofUp}");
                   */
        }

        //  4.5 Concepts Related to Object Oriented Programming
        // Constants/ Read-only
        // Object initialiser (ToString)
        // Access modifiers (Protected, internal)
        // Classes (partial/ static)
        public void Lesson4_5()
        {
            // Properties, read only/ vs constants and Object initialiser
            Section4_ShippingBusinessLogic objShippingBiz = new Section4_ShippingBusinessLogic
            ("MyStore") // Setting private readonly
            {
                OfficeLocation = "London",
                RegistrationNumber = "TN12-B23"
            };

            // Both private/ cannot change
            //objShippingBiz.ORGANIZATION_NAME  // ORGANIZATION_NAME = "ABC Corp Ltd."; 
            //objShippingBiz._departmentName    // _departmentName = departmentName (constructor)

            // (ToString changed) - class System.Object overriding ToString method
            // Before "C8_In4Hours.Section4_ShippingBusinessLogic"
            // After "Organization - ABC Corp Ltd." 
            Console.WriteLine($"Class = {objShippingBiz}"); // ToString
            // "public override string ToString()" was used in "Section4_ShippingBusinessLogic"
            Console.WriteLine("");


            // access modifiers Protected, internal, protected internal 
            //CourierServiceBase 	- abstract
            //EagleCourier_SA 	    - inherit CourierServiceBase
            //EagleCourier_NA 	    - inherit CourierServiceBase

            // CompanyRegistration (protected)
            // Packing (internal)
            Section4_CourierServiceBase myServiceSA = new Section4_EagleCourier_SA();
            Console.WriteLine($"Courier : {myServiceSA.CompanyRegistration}");
            //myServiceSA.Packing("Laptop");
            myServiceSA.SendItemsByAir("Laptop"); // "Sending" packs the item first
            
            Console.WriteLine("");

            Section4_CourierServiceBase myServiceNA = new Section4_EagleCourier_NA();
            Console.WriteLine($"Courier : {myServiceNA.CompanyRegistration}");
            //myServiceNA.Packing("Car");
            myServiceNA.SendItemsByRoad("Car"); // "Sending" packs the item first
            
            Console.WriteLine("");



            // Partial classes = combines classes files (used for multiple developers)
            // public partial class Section4_EagleCourier_SA : Section4_CourierServiceBase
            // partial class Section4_EagleCourier_SA  // second EagleCourier_SA class in folder "Ext"

            // Cost in "Ext" folder "Section4_EagleCourier_SA" file
            Section4_EagleCourier_SA mySA = new Section4_EagleCourier_SA();
            Console.WriteLine($"Courier : {mySA.CompanyRegistration}, Cost: {mySA.Cost()}");
            //mySA.Packing("Car");
            mySA.SendItemsByRoad("Car");

            Console.WriteLine("");


            // static classes = shared class
            // static means shareable, cannot create instances/ only one version
            //public static class Section4_MyConstants (also contains Helper)
            string EUString = Section4_MyConstants.APP_EU;
            Section4_Helper.Log($"Hello from {EUString}");
        }
    }
}
