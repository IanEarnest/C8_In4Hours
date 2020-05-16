using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    public class Section4_ShippingBusinessLogic
    {
        // Properties, read only/ vs constants	
        public const string ORGANIZATION_NAME = "ABC Corp Ltd."; // Constant you can only set when stated
        private readonly string _departmentName; // readonly can be set once

        public Section4_ShippingBusinessLogic(string departmentName)
        {
            // (constant) initialised then not changed
            _departmentName = departmentName; // readonly can be set once
        }

        public string OfficeLocation { get; set; }
        public string RegistrationNumber { get; set; }

        // Object initialiser/ change ToString/ class call
        // class System.Object overriding ToString method
        //all classes inherit from System.Object
        public override string ToString()
        {
            string myString = $"Organization - {ORGANIZATION_NAME}";
            return myString;
        }
    }
}
