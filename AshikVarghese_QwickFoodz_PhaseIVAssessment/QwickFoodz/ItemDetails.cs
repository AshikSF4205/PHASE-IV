using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    /// <summary>
    /// Class used to ItemDetails Datatype creation
    /// </summary>
    public class ItemDetails
    {
        // Properties: ItemID – (ITID100), OrderID, FoodID, PurchaseCount, PriceOfOrder

        // Field
        /// <summary>
        /// Static field for auto-incrementing the Item Id <see cref="ItemDetails"/> class
        /// </summary>
        private static int s_itemId = 100;

        // property
        /// <summary>
        /// Property name used to get Item ID
        /// </summary>
        /// <value>string returnType</value>
        public string ItemID { get; }

        // property
        /// <summary>
        /// Property name used to get Order ID
        /// </summary>
        /// <value>string returnType</value>
        public string OrderID { get; set; }

        // property
        /// <summary>
        /// Property name used to get Food ID
        /// </summary>
        /// <value>string returnType</value>
        public string FoodID { get; set; }

        // property
        /// <summary>
        /// Property name used to get purchase count of food
        /// </summary>
        /// <value>int returnType</value>
        public int PurchaseCount { get; set; }

        // property
        /// <summary>
        /// Property name used to get price of the order item
        /// </summary>
        /// <value>double returnType</value>
        public double PriceOfOrder { get; set; }

        // constructor
        /// <summary>
        /// Constructor used to get Item details
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="foodId"></param>
        /// <param name="purchaseCount"></param>
        /// <param name="priceOfOrder"></param>
        public ItemDetails(string orderId, string foodId, int purchaseCount, double priceOfOrder)
        {
            ItemID = "ITID" + (++s_itemId);
            OrderID = orderId; ;
            FoodID = foodId;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }


    }
}