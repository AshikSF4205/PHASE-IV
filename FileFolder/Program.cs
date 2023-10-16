using System;
using System.IO;
namespace FileFolder;
class Program
{
    public static void Main(string[] args)
    {
        string path = @"C:\Users\AshikVargheseThomas\OneDrive - Syncfusion\Desktop\MyFolder";
        string folderPath = path + "\\Ashik";

        if (Directory.Exists(folderPath))
        {
            System.Console.WriteLine("Directory Found!");
        }
        else
        {
            System.Console.WriteLine("Directory Not Found!, So Creating a Folder");
            Directory.CreateDirectory(folderPath);
        }

        string filePath = path + "//NewFile.txt";
        if (File.Exists(filePath))
        {
            System.Console.WriteLine("File Found!");

        }
        else
        {
            System.Console.WriteLine("File Not Found!, So Creating a File");
            File.Create(filePath).Close();
        }

        
    }
}