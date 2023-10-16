using System;
namespace HospitalManagement;
class Program
{

    public static void Main(string[] args)
    {
        System.Console.WriteLine("-----------------------------HOSPITAL MANAGEMENT SYSTEM APPLICATION-----------------------------");
        System.Console.WriteLine("|                                                                                              |");

        FileHandling.Create();

        FileHandling.ReadFromCSV();

        HospitalManagement.MainMenu();

        FileHandling.WriteToCSV();


        System.Console.WriteLine("|                                                                                              |");
        System.Console.WriteLine("-------------------------------------THANK YOU VISIT AGAIN!-------------------------------------");
    }

    
}
