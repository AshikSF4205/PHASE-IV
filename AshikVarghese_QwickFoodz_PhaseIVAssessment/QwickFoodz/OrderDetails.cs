using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public enum OrderStatus { Default, Initiated, Ordered, Cancelled }

    /// <summary>
    /// Class used to OrderDetails Datatype creation
    /// </summary>
    public class OrderDetails
    {
        // Properties: OrderID, CustomerID, TotalPrice, DateOfOrder, OrderStatus – {Default, Initiated, Ordered, Cancelled}.

        // Field
        /// <summary>
        /// Static field for auto-incrementing the Order Id <see cref="OrderDetails"/> class
        /// </summary>
        private static int s_orderId = 3000;

        // property
        /// <summary>
        /// Property name used to get Order ID
        /// </summary>
        /// <value>string returnType</value>
        public string OrderID { get; }

        // property
        /// <summary>
        /// Property name used to get Customer ID
        /// </summary>
        /// <value>string returnType</value>
        public string CustomerID { get; set; }

        // property
        /// <summary>
        /// Property name used to get total price of the order
        /// </summary>
        /// <value>double returnType</value>
        public double TotalPrice { get; set; }

        // property
        /// <summary>
        /// Property name used to get order date
        /// </summary>
        /// <value>DateTime returnType</value>
        public DateTime DateOfOrder { get; set; }

        // property
        /// <summary>
        /// Property name used to get order status
        /// </summary>
        /// <value>OrderStatus returnType</value>
        public OrderStatus Status { get; set; }

        // constructor
        /// <summary>
        /// Constructor used to get Order details
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="totalPrice"></param>
        /// <param name="dateOfOrder"></param>
        /// <param name="status"></param>
        public OrderDetails(string customerId, double totalPrice, DateTime dateOfOrder, OrderStatus status)
        {

            OrderID = "OID" + (++s_orderId);
            CustomerID = customerId;
            TotalPrice = totalPrice;
            DateOfOrder = dateOfOrder;
            Status = status;
        }


    }
}