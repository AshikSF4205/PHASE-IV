using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{

    public enum OrderStatusEnum { Default, Ordered, Cancelled }
    public class OrderDetails
    {
        /*
       Details Needed
       •	OrderID (Auto Increment – OID1001)
       •	CustomerID
       •	ProductID
       •	TotalPrice 
       •	PurchaseDate
       •	Quantity
       •	OrderStatus – (Enum- Default, Ordered, Cancelled)

       */

        //Fields
        private static int s_OrderId = 1000;



        //Properties
        public string OrderID { get; }

        public string CustomerID { get; set; }

        public string ProductID { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        //Constructor
        public OrderDetails() { }

        public OrderDetails(string customerID, string productID, int count, double totalPrice, DateTime purchaseDate, OrderStatusEnum orderStatus)
        {

            OrderID = "OID" + (++s_OrderId);
            CustomerID = customerID;
            ProductID = productID;
            Quantity = count;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            OrderStatus = orderStatus;

        }

        public OrderDetails(string order)

        {

            string[] orderArray = order.Split(",");
            s_OrderId = int.Parse(orderArray[0].Remove(0, 3));

            OrderID = orderArray[0];
            CustomerID = orderArray[1];
            ProductID = orderArray[2];
            TotalPrice = double.Parse(orderArray[3]);
            PurchaseDate = DateTime.ParseExact(orderArray[4], "dd/MM/yyyy", null);
            Quantity = int.Parse(orderArray[5]);
            OrderStatus = Enum.Parse<OrderStatusEnum>(orderArray[6], true);

        }

    }
}