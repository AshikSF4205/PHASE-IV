using System;
namespace ExceptionHandling;
class Program
{
    public static void Main(string[] args)
    {
        try
        {
            int[] numbers = new int[2];
            System.Console.WriteLine();
            System.Console.Write("Enter a 1st number: ");
            while (!int.TryParse(Console.ReadLine(), out numbers[0]))
            {
                System.Console.WriteLine();
                System.Console.Write("Invalid Format! Enter again : ");
            }

            System.Console.WriteLine();
            System.Console.Write("Enter a 2nd number: ");
            while (!int.TryParse(Console.ReadLine(), out numbers[0]))
            {
                System.Console.WriteLine();
                System.Console.Write("Invalid Format! Enter again: ");
            }
            System.Console.WriteLine();

            if (numbers[1] != 0)
            {
                int result = numbers[0] / numbers[1];
                System.Console.WriteLine();
                System.Console.Write("Result: " + result);
            }
            else
            {
                System.Console.WriteLine("Infinity");
            }
        }
        catch (FormatException e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
        }

    }
}