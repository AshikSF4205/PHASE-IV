using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace SynCart;

public static class FileHandling
{
    public static void Create()
    {
        if (Directory.Exists("SynCart"))
        {
            System.Console.WriteLine("SynCart Folder already exist!");
        }
        else
        {
            Directory.CreateDirectory("SynCart");
            System.Console.WriteLine("SynCart Folder created!");
        }

        if (File.Exists("SynCart/CustomerDetails.csv"))
        {
            System.Console.WriteLine("CustomerDetails File already exist!");
        }
        else
        {
            File.Create("SynCart/CustomerDetails.csv").Close();
            System.Console.WriteLine("CustomerDetails File created!");
        }

        if (File.Exists("SynCart/OrderDetails.csv"))
        {
            System.Console.WriteLine("OrderDetails File already exist!");
        }
        else
        {
            File.Create("SynCart/OrderDetails.csv").Close();
            System.Console.WriteLine("OrderDetails File created!");
        }

        if (File.Exists("SynCart/ProductDetails.csv"))
        {
            System.Console.WriteLine("ProductDetails File already exist!");
        }
        else
        {
            File.Create("SynCart/ProductDetails.csv").Close();
            System.Console.WriteLine("ProductDetails File created!");
        }
    }

    public static void WriteToCSV()
    {
        int i;
        string[] customerDetailsArray = new string[Operations.customerDetailsList.Count];

        for (i = 0; i < Operations.customerDetailsList.Count; i++)

        {

            customerDetailsArray[i] = $"{Operations.customerDetailsList[i].CustomerID},{Operations.customerDetailsList[i].Name},{Operations.customerDetailsList[i].City},{Operations.customerDetailsList[i].MobileNumber},{Operations.customerDetailsList[i].WalletBalance},{Operations.customerDetailsList[i].EmailID}";

        }



        File.WriteAllLines("SynCart/CustomerDetails.csv", customerDetailsArray);



        string[] productDetailsArray = new string[Operations.productDetailsList.Count];

        for (i = 0; i < Operations.productDetailsList.Count; i++)

        {

            productDetailsArray[i] = $"{Operations.productDetailsList[i].ProductID},{Operations.productDetailsList[i].ProductName},{Operations.productDetailsList[i].Price},{Operations.productDetailsList[i].Stock},{Operations.productDetailsList[i].ShippingDuration}";

        }

        File.WriteAllLines("SynCart/ProductDetails.csv", productDetailsArray);



        string[] orderDetailsArray = new string[Operations.orderDetailsList.Count];

        for (i = 0; i < Operations.orderDetailsList.Count; i++)

        {

            orderDetailsArray[i] = $"{Operations.orderDetailsList[i].OrderID},{Operations.orderDetailsList[i].CustomerID},{Operations.orderDetailsList[i].ProductID},{Operations.orderDetailsList[i].TotalPrice},{Operations.orderDetailsList[i].PurchaseDate.ToString("dd/MM/yyyy")},{Operations.orderDetailsList[i].Quantity},{Operations.orderDetailsList[i].OrderStatus}";

        }

        File.WriteAllLines("SynCart/OrderDetails.csv", orderDetailsArray);
    }

    public static void ReadFromCSV(){
        string[] customerDetailsArray = File.ReadAllLines("SynCart/CustomerDetails.csv");
        foreach (string customer in customerDetailsArray)
        {
            CustomerDetails customerObj = new CustomerDetails(customer);
            Operations.customerDetailsList.Add(customerObj);
        }

        string[] productDetailsArray = File.ReadAllLines("SynCart/ProductDetails.csv");
        foreach (string product in productDetailsArray)
        {
            ProductDetails productObj = new ProductDetails(product);
            Operations.productDetailsList.Add(productObj);
        }

        string[] orderDetailsArray =  File.ReadAllLines("SynCart/OrderDetails.csv");
        foreach (string order in orderDetailsArray)
        {
            OrderDetails orderObj = new OrderDetails(order);
            Operations.orderDetailsList.Add(orderObj);
        }

    }
}
