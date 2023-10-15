using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class CustomerDetails
    {

        /*
        Details Needed
        •	CustomerID (Auto Increment -CID1000)
        •	Name
        •	City
        •	MobileNumber
        •	WalletBalance
        •	EmailID

        */

        //Fields
        private static int s_customerId = 1000;



        //Properties
        public string CustomerID { get; }

        public string Name { get; set; }

        public string City { get; set; }

        public long MobileNumber { get; set; }

        public double WalletBalance { get; set; }

        public string EmailID { get; set; }

        //Constructor
        public CustomerDetails() { }

        public CustomerDetails(string name, string city, long mobileNumber, string emailID, double walletBalance)
        {


            CustomerID = "CID" + (++s_customerId);
            Name = name;
            City = city;
            MobileNumber = mobileNumber;
            WalletBalance = walletBalance;
            EmailID = emailID;

        }

        public CustomerDetails(string customer)
        {
            string[] customerArray = customer.Split(",");

            s_customerId = int.Parse(customerArray[0].Remove(0,3));

            CustomerID = customerArray[0];
            Name = customerArray[1];
            City = customerArray[2];
            MobileNumber = long.Parse(customerArray[3]);
            WalletBalance = double.Parse(customerArray[4]);
            EmailID = customerArray[5];
        }

        public void WalletRecharge(double amount)
        {

            WalletBalance += amount;

        }

        public void DeductBalance(double amount)
        {
            WalletBalance -= amount;
        }
    }
}
