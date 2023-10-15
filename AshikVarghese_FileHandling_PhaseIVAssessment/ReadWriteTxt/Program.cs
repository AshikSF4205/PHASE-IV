using System;
using System.IO;
namespace ReadWriteTxt;
class Program
{
    public static void Main(string[] args)
    {
        if (!Directory.Exists("TestFolder"))
        {
            Directory.CreateDirectory("TestFolder");
            System.Console.WriteLine("Folder Created!");
        }
        else
        {
            System.Console.WriteLine("Folder Exist!");
        }

        if (!File.Exists("TestFolder/Test.txt"))
        {
            File.Create("TestFolder/Test.txt");
            System.Console.WriteLine("File Created!");
        }
        else
        {
            System.Console.WriteLine("File Exist!");
        }

        System.Console.WriteLine("\nSelect Option: \n1. Read File \n2. Write File");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                {
                    StreamReader sr = null;
                    try
                    {
                        sr = new StreamReader("TestFolder/Test.txt");
                        string line = sr.ReadLine();
                        while (line != null)
                        {
                            System.Console.WriteLine(line);
                            line = sr.ReadLine();
                        }
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        if (sr != null)
                        {
                            System.Console.WriteLine("Executing finally block");
                            sr.Close();
                        }
                    }
                    break;
                }

            case 2:
                {
                    StreamWriter sw = null;
                    try
                    {
                        string[] oldDataArray = File.ReadAllLines("TestFolder/Test.txt");
                        sw = new StreamWriter("TestFolder/Test.txt");
                        System.Console.WriteLine("Enter the new content to be placed in the file: ");
                        string newData = Console.ReadLine();
                        string data = "";
                        foreach (string text in oldDataArray)
                        {
                            data += text + "\n";
                        }
                        data += newData;
                        sw.WriteLine(data);

                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        if (sw != null)
                        {
                            System.Console.WriteLine("Executing finally block");
                            sw.Close();
                        }
                    }
                    break;
                }
        }

    }
}