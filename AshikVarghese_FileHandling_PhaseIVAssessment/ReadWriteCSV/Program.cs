using System;
using System.Collections.Generic;
using System.IO;
namespace ReadWriteCSV;
class Program
{
    static List<StudentDetails> saveStudentDetailsList = new List<StudentDetails>();

    static List<StudentDetails> getStudentDetailsList = new List<StudentDetails>();

    public static void Main(string[] args)
    {
        if (!Directory.Exists("TestFolder"))
        {
            Directory.CreateDirectory("TestFolder");
            System.Console.WriteLine("Folder Created!");
        }
        else
        {
            System.Console.WriteLine("Folder Found!");
        }

        if (!File.Exists("TestFolder/Test.csv"))
        {
            File.Create("TestFolder/Test.csv");
            System.Console.WriteLine("CSVFile Created!");
        }
        else
        {
            System.Console.WriteLine("File Found!");
        }

        DataLoad();

        Insert();

        Display();

    }

    static void DataLoad()
    {

        saveStudentDetailsList.Add(
            new StudentDetails()
            {
                Name = "Ashik",
                FatherName = "Thomas",
                Gender = GenderEnum.Male,
                DOB = new DateTime(2001, 12, 25),
                Mark = 513
            }
        );

        saveStudentDetailsList.Add(
            new StudentDetails()
            {
                Name = "Ashok",
                FatherName = "Kumar",
                Gender = GenderEnum.Male,
                DOB = new DateTime(1999, 01, 22),
                Mark = 430
            }
        );

        saveStudentDetailsList.Add(
            new StudentDetails()
            {
                Name = "Ashwini",
                FatherName = "Aravind",
                Gender = GenderEnum.Female,
                DOB = new DateTime(2001, 11, 25),
                Mark = 590
            }
        );

        saveStudentDetailsList.Add(
            new StudentDetails()
            {
                Name = "Ashina",
                FatherName = "Stalin",
                Gender = GenderEnum.Female,
                DOB = new DateTime(2001, 03, 12),
                Mark = 550
            }
        );
    }

    public static void Insert()
    {
        StreamWriter sw = new StreamWriter(File.OpenWrite("TestFolder/Test.csv"));
        foreach (StudentDetails student in saveStudentDetailsList)
        {
            sw.WriteLine($"{student.Name},{student.FatherName},{student.Gender},{student.DOB.ToString("dd/MM/yyyy")},{student.Mark}");
        }
        sw.Close();
    }

    public static void Display()
    {
        StreamReader sr = null;
        if (File.Exists("TestFolder/Test.csv"))
        {
            sr = new StreamReader(File.OpenRead("TestFolder/Test.csv"));
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(",");
                if (values[0] != "")
                {
                    getStudentDetailsList.Add(
                    new StudentDetails()
                    {
                        Name = values[0],
                        FatherName = values[1],
                        Gender = Enum.Parse<GenderEnum>(values[2]),
                        DOB = DateTime.ParseExact(values[3], "dd/MM/yyyy", null),
                        Mark = double.Parse(values[4])
                    }
                    );
                }
            }
        }
        else
        {
            System.Console.WriteLine("File doesn't exist");
        }
        sr.Close();
        foreach (StudentDetails student in getStudentDetailsList)
        {
            System.Console.WriteLine($"\n----------------------------------\nYour Name: {student.Name}\nFather Name: {student.FatherName}\nGender: {student.Gender}\nDOB: {student.DOB.ToString("dd/MM/yyyy")}\nMark: {student.Mark}\n----------------------------------\n");
        }
    }
}