using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{
    // Events - publisher/ subscriber
    
    class Section5_Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
    }

    class Section5_CustomerEventArg
    {
        public string StoreName { get; set; }
        public string CustomerName { get; set; }
    }

    
    class Section5_CustomerBiz
    {
        // Event listener
        public event EventHandler<Section5_CustomerEventArg> CustomerAdded;
        public void AddCustomer(Section5_Customer customer)
        {
            Console.WriteLine($"Adding a new customer");

            System.Threading.Thread.Sleep(3000); // Wait for 3 seconds
            //this.CusAdded...
            
            // Event - this class, new args (CustName, StoreName)
            // custEventArg has CustName and StoreName
            //              Event cust name = this AddCustomer name
            
            this.CustomerAdded(this, new Section5_CustomerEventArg
            { CustomerName = customer.CustomerName, StoreName = "My store" });

        }
    }
}
