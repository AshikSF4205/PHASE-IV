using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    /// <summary>
    /// Class used to FoodDetails Datatype creation
    /// </summary>
    public class FoodDetails
    {
        //Properties: FoodID, FoodName, PricePerQuantity, QuantityAvailable

        // Field
        /// <summary>
        /// Static field for auto-incrementing the Food Id <see cref="FoodDetails"/> class
        /// </summary>
        private static int s_foodId = 100;

        // property
        /// <summary>
        /// Property name used to get Food ID
        /// </summary>
        /// <value>string returnType</value>
        public string FoodID { get; }

        // property
        /// <summary>
        /// Property name used to get food name
        /// </summary>
        /// <value>string returnType</value>
        public string FoodName { get; set; }

        // property
        /// <summary>
        /// Property name used to get price per quantity of the food
        /// </summary>
        /// <value>double returnType</value>
        public double PricePerQuantity { get; set; }

        // property
        /// <summary>
        /// Property name used to get food quantity available 
        /// </summary>
        /// <value>int returnType</value>
        public int QuantityAvailable { get; set; }

        // constructor
        /// <summary>
        /// Constructor used to get Food details
        /// </summary>
        /// <param name="foodName"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public FoodDetails(string foodName, double price, int quantity)
        {
            FoodID = "FID" + (++s_foodId);
            FoodName = foodName;
            PricePerQuantity = price;
            QuantityAvailable = quantity;

        }
    }
}