using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class HospitalManagement
    {
        public static void MainMenu()
        {
            bool tryParseChecker, exitChecker = false;
            do
            {
                //Main Menu
                System.Console.WriteLine("\nMAIN MENU:");
                System.Console.WriteLine("1. Patient Registration \n2. User Login \n3. Exit");
                System.Console.Write("Enter the  Appropriate digit[1/2/3]: ");
                tryParseChecker = int.TryParse(Console.ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        {
                            //Register
                            //PatientRegistration();
                            break;
                        }
                    case 2:
                        {
                            //Login
                            // UserLogin();
                            break;
                        }
                    case 3:
                        {
                            //Exit
                            exitChecker = true;
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("INVALID ENTRY! [ENTER - 1 / 2 / 3 ]");
                            break;
                        }
                }
            } while (!(tryParseChecker && exitChecker));
        }

        public static void Registration()
        {
            System.Console.WriteLine("REGISTRATION IS SELECTED");

            //Getting Customer Details

            bool userNameCheck = true;
            string userName;
            do
            {
                System.Console.Write("Enter Patient Name: ");
                userName = Console.ReadLine();

                if (!Regex.IsMatch(userName, @"^[a-z A-Z]+$")) System.Console.WriteLine("NUMBERS NOT ALLOWED!");
                else userNameCheck = false;
            } while (userNameCheck);

            System.Console.Write("Enter your Father's Name: ");
            string fatherName = Console.ReadLine();
            while (!Regex.IsMatch(fatherName, @"^[a-z A-Z]+$"))
            {
                System.Console.WriteLine("ONLY ALPHABETS ALLOWED!");
                System.Console.Write("Enter Valid Father's Name: ");
                fatherName = Console.ReadLine();

            }

            System.Console.Write("Enter Mobile Number(10-digits): (+91) ");
            string phNo = Console.ReadLine();
            bool tempPhno = long.TryParse(phNo, out long mobileNumber);
            while (!(tempPhno && phNo.Length == 10))
            {
                System.Console.WriteLine("INVALID PHONE NUMBER!");
                System.Console.Write("Enter Correct Phone Number(10-digits): (+91) ");
                phNo = Console.ReadLine();
                tempPhno = long.TryParse(phNo, out mobileNumber);
            }

            System.Console.Write("Enter Mail Id: ");
            string mailId = Console.ReadLine().ToLower();
            while (!(mailId.Contains(".") && mailId.Contains("@")))
            {
                System.Console.WriteLine("INVALID MAIL ID!");
                System.Console.Write("Enter Correct Mail Id: ");
                mailId = Console.ReadLine();

            }

            System.Console.Write("Enter Initial Wallet Top-up in Rupees: Rs.");
            bool tempBal = int.TryParse(Console.ReadLine(), out int balance);
            while (!tempBal && balance > 0)
            {
                System.Console.WriteLine("INVALID AMOUNT!");
                System.Console.Write("Enter Correct Amount in Rupees: Rs.");
                tempBal = int.TryParse(Console.ReadLine(), out balance);
            }

            //Saving Customer details in customerDetails List
            CustomerDetails customer = new CustomerDetails(name, city, mobileNumber, mailId, balance);
            customerDetailsList.Add(customer);

            //Displaying Customer ID after completion of Registration
            System.Console.WriteLine("REGISTRATION SUCCESSFUL!");
            System.Console.WriteLine("\n--------------------------------\n");
            System.Console.WriteLine("YOUR ID IS " + customer.CustomerID);
            System.Console.WriteLine("Please note down your user ID.");
            System.Console.WriteLine("\n---------------------------------\n");


        }
    }
}