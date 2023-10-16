using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class FoodDetails
    {
        private static int s_id = 100;
        private string _foodId;
        public string FoodID
        {
            get
            {
                return _foodId;
            }
        }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public FoodDetails(string foodName, double foodPrice, int availableQuantity)
        {
            s_id++;
            _foodId = "FID" + s_id;
            FoodName = foodName;
            FoodPrice = foodPrice;
            AvailableQuantity = availableQuantity;
        }

        public FoodDetails(string food)
        {
            string[] foodArray = food.Split(",");
            s_id = Convert.ToInt32(foodArray[0].Remove(0, 3));
            _foodId = foodArray[0];
            FoodName = foodArray[1];
            FoodPrice = Convert.ToDouble(foodArray[2]);
            AvailableQuantity=Convert.ToInt32(foodArray[3]);

        }
    }
}