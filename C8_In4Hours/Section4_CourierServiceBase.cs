using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    public abstract class Section4_CourierServiceBase
    {
		// Protected and public CompanyRegistration
		protected string _companyRegistration;
	public string CompanyRegistration // returns name
	{
		get
		{
			// if companyRegistration not set, set as Eagle-00
			if(string.IsNullOrEmpty(_companyRegistration)) { _companyRegistration = "Eagle-00"; }
			
			return _companyRegistration;
		} 
	}
		public abstract void SendItemsByAir(string item);
		public abstract void SendItemsByRoad(string item);
		internal void Packing(string item) 
		{
			Console.WriteLine($"Packing: {item}");// print "Packing: laptop"
			//internal Packing // marked internal (accessed in library)
		}


	}
}
