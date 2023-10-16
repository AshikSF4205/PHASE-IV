using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class ProductDetails
    {
        /*
       Details Needed
       •	ProductID (Auto Increment – PID101)
       •	ProductName
       •	Price
       •	Stock 
       •	ShippingDuration
       */

        //Fields
        private static int s_productId = 100;

        //Properties
        public string Ecommerce { get; set; }
        public string ProductID { get; }

        public string ProductName { get; set; }

        public int Stock { get; set; }

        public double Price { get; set; }

        public int ShippingDuration { get; set; }

        //Constructor
        public ProductDetails() { }

        public ProductDetails(string productName, int stock, double price, int shippingDuration)
        {

            ProductID = "PID" + (++s_productId);
            ProductName = productName;
            Stock = stock;
            Price = price;
            ShippingDuration = shippingDuration;

        }

        public ProductDetails(string product)

        {

            string[] productArray = product.Split(",");

            s_productId = int.Parse(productArray[0].Remove(0, 3));

            ProductID = productArray[0];
            ProductName = productArray[1];
            Price = double.Parse(productArray[2]);
            Stock = int.Parse(productArray[3]);
            ShippingDuration = int.Parse(productArray[4]);

        }

    }
}