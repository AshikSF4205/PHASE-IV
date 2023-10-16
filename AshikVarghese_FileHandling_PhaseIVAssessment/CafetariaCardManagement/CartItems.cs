using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class CartItems
    {
        private static int s_id = 100;
        private string _itemId;
        public string ItemID
        {
            get
            {
                return _itemId;
            }
        }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public double OrderPrice { get; set; }
        public int OrderQuantity { get; set; }
        public CartItems(string orderId, string foodId, double orderPrice, int orderQuantity)
        {
            s_id++;
            _itemId = "ITID" + s_id;
            OrderID = orderId;
            FoodID = foodId;
            OrderPrice = orderPrice;
            OrderQuantity = orderQuantity;
        }

         public CartItems(string items)
        {
            string[] cartArray =items.Split(",");
            s_id = Convert.ToInt32(cartArray[0].Remove(0, 4));
            _itemId = cartArray[0];
            OrderID = cartArray[1];
            FoodID = cartArray[2];
            OrderPrice = Convert.ToDouble(cartArray[3]);
            OrderQuantity = Convert.ToInt32(cartArray[4]);
        }
    }
}