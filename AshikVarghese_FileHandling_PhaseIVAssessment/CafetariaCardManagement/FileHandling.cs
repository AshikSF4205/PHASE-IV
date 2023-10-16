using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
   
public static class FileHandling
{
    public static void Create()
    {
        if (Directory.Exists("CafeteriaData"))
        {
            System.Console.WriteLine("CafeteriaData Folder already exist!");
        }
        else
        {
            Directory.CreateDirectory("CafeteriaData");
            System.Console.WriteLine("CafeteriaData Folder created!");
        }
        if (File.Exists("CafeteriaData/UserDetails.csv"))
        {
            System.Console.WriteLine("UserDetails File already exist!");
        }
        else
        {
            File.Create("CafeteriaData/UserDetails.csv").Close();
            System.Console.WriteLine("UserDetails File created!");
        }
        if (File.Exists("CafeteriaData/FoodDetails.csv"))
        {
            System.Console.WriteLine("FoodDetails File already exist!");
        }
        else
        {
            File.Create("CafeteriaData/FoodDetails.csv").Close();
            System.Console.WriteLine("FoodDetails File created!");
        }
        if (File.Exists("CafeteriaData/CartItems.csv"))
        {
            System.Console.WriteLine("CartItems File already exist!");
        }
        else
        {
            File.Create("CafeteriaData/CartItems.csv").Close();
            System.Console.WriteLine("CartItems File created!");
        }
        if (File.Exists("CafeteriaData/OrderDetails.csv"))
        {
            System.Console.WriteLine("OrderDetails File already exist!");
        }
        else
        {
            File.Create("CafeteriaData/OrderDetails.csv").Close();
            System.Console.WriteLine("OrderDetails File created!");
        }
        
    }
    public static void WriteToCSV()
    {
        int i;
        string[] UserDetailsArray = new string[Cafetaria.userList.Count];
        for (i = 0; i < Cafetaria.userList.Count; i++)
        {
            UserDetailsArray[i] = $"{Cafetaria.userList[i].UserID},{Cafetaria.userList[i].Name},{Cafetaria.userList[i].FatherName},{Cafetaria.userList[i].Mobile},{Cafetaria.userList[i].MailID},{Cafetaria.userList[i].Gender},{Cafetaria.userList[i].WorkStationNumber},{Cafetaria.userList[i].WalletBalance}";
        }


        File.WriteAllLines("CafeteriaData/UserDetails.csv", UserDetailsArray);


        string[] FoodDetailsArray = new string[Cafetaria.foodList.Count];
        for (i = 0; i < Cafetaria.foodList.Count; i++)
        {
            FoodDetailsArray[i] = $"{Cafetaria.foodList[i].FoodID},{Cafetaria.foodList[i].FoodName},{Cafetaria.foodList[i].FoodPrice},{Cafetaria.foodList[i].AvailableQuantity}";
        }
        File.WriteAllLines("CafeteriaData/FoodDetails.csv", FoodDetailsArray);


        string[] orderDetailsArray = new string[Cafetaria.orderList.Count];
        for (i = 0; i < Cafetaria.orderList.Count; i++)
        {
            orderDetailsArray[i] = $"{Cafetaria.orderList[i].OrderID},{Cafetaria.orderList[i].UserID},{Cafetaria.orderList[i].OrderDate.ToString("dd/MM/yyyy")},{Cafetaria.orderList[i].TotalPrice},{Cafetaria.orderList[i].Status}";
        }
        File.WriteAllLines("CafeteriaData/OrderDetails.csv", orderDetailsArray);

        string[] cartItemsArray = new string[Cafetaria.cartlist.Count];
        for (i = 0; i < Cafetaria.cartlist.Count; i++)
        {
            cartItemsArray[i] = $"{Cafetaria.cartlist[i].ItemID},{Cafetaria.cartlist[i].OrderID},{Cafetaria.cartlist[i].FoodID},{Cafetaria.cartlist[i].OrderPrice},{Cafetaria.cartlist[i].OrderQuantity}";
        }
        File.WriteAllLines("CafeteriaData/CartItems.csv", cartItemsArray);
    }

    public static void ReadFromCSV(){
        string[] userDetailsArray = File.ReadAllLines("CafeteriaData/UserDetails.csv");
        foreach (string user in userDetailsArray)
        {
            UserDetails customerObj = new UserDetails(user);
            Cafetaria.userList.Add(customerObj);
        }

        string[] foodDetailsArray = File.ReadAllLines("CafeteriaData/FoodDetails.csv");
        foreach (string product in foodDetailsArray)
        {
            FoodDetails productObj = new FoodDetails(product);
            Cafetaria.foodList.Add(productObj);
        }

        string[] cartItemsArray = File.ReadAllLines("CafeteriaData/CartItems.csv");
        foreach (string items in cartItemsArray)
        {
            CartItems cartObj = new CartItems(items);
            Cafetaria.cartlist.Add(cartObj);
        }

        string[] orderDetailsArray =  File.ReadAllLines("CafeteriaData/OrderDetails.csv");
        foreach (string order in orderDetailsArray)
        {
            OrderDetails orderObj = new OrderDetails(order);
            Cafetaria.orderList.Add(orderObj);
        }
    }
}

}