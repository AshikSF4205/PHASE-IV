using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleTables;

namespace QwickFoodz
{
    public class QwickFoodz
    {

        static CustomerDetails currentlyLoggedInCustomer;

        public static CustomList<CustomerDetails> customerDetailsList = new CustomList<CustomerDetails>();

        public static CustomList<FoodDetails> foodDetailsList = new CustomList<FoodDetails>();

        public static CustomList<ItemDetails> itemDetailsList = new CustomList<ItemDetails>();

        public static CustomList<OrderDetails> orderDetailsList = new CustomList<OrderDetails>();

        public static void MainMenu()
        {
            bool tryParseChecker, exitChecker = false;
            do
            {
                //Main Menu
                System.Console.WriteLine("\nMAIN MENU:");
                //Listing Main Menu
                System.Console.WriteLine("1. Customer Registration \n2. Customer Login \n3. Exit");
                System.Console.Write("Enter the  Appropriate digit[1/2/3]: ");
                tryParseChecker = int.TryParse(Console.ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        {
                            //Customer Register
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            //Customer Login
                            Login();
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

            bool nameCheck = true;
            string name;
            do
            {
                System.Console.Write("Enter Name: ");
                name = Console.ReadLine();
                if (!Regex.IsMatch(name, @"^[a-z A-Z]+$")) System.Console.WriteLine("NUMBERS NOT ALLOWED!");
                else nameCheck = false;
            } while (nameCheck);

            System.Console.Write("Enter your Father's Name: ");
            string fatherName = Console.ReadLine();
            while (!Regex.IsMatch(fatherName, @"^[a-z A-Z]+$"))
            {
                System.Console.WriteLine("ONLY ALPHABETS ALLOWED!");
                System.Console.Write("Enter Valid Father's Name: ");
                fatherName = Console.ReadLine();
            }

            System.Console.Write("Enter your Gender[Male / Female / Transgender]: ");
            bool boolGender = Enum.TryParse<GenderType>(Console.ReadLine(), true, out GenderType gender);
            while (!(boolGender && (gender == GenderType.Female || gender == GenderType.Transgender || gender == GenderType.Male)))
            {
                System.Console.WriteLine("INVALID   GENDER!");
                System.Console.Write("Enter Correct Gender: ");
                boolGender = Enum.TryParse<GenderType>(Console.ReadLine(), true, out gender); ;
            }

            System.Console.Write("Enter Mobile Number(10-digits): (+91) ");
            bool boolMobile = long.TryParse(Console.ReadLine(), out long mobileNumber);
            while (!(boolMobile && mobileNumber > 1000000000 && mobileNumber < 9999999999))
            {
                System.Console.WriteLine("INVALID PHONE NUMBER!");
                System.Console.Write("Enter Correct Phone Number(10-digits): (+91) ");
                boolMobile = long.TryParse(Console.ReadLine(), out mobileNumber);
            }

            System.Console.Write("Enter DOB[dd/MM/yyyy]: ");
            bool booldob = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob);
            while (!booldob)
            {
                System.Console.WriteLine("INVALID DOB!");
                System.Console.Write("Enter Correct DOB: ");
                booldob = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            }

            System.Console.Write("Enter Mail Id: ");
            string mailId = Console.ReadLine().ToLower();
            while (!(mailId.Contains(".") && mailId.Contains("@")))
            {
                System.Console.WriteLine("INVALID MAIL ID!");
                System.Console.Write("Enter Correct Mail Id: ");
                mailId = Console.ReadLine();
            }

            bool locationCheck = true;
            string location;
            do
            {
                System.Console.Write("Enter Location: ");
                location = Console.ReadLine();
                if (!Regex.IsMatch(location, @"^[a-z A-Z]+$")) System.Console.WriteLine("NUMBERS NOT ALLOWED!");
                else locationCheck = false;
            } while (locationCheck);


            System.Console.Write("Enter Initial Wallet Top-up in Rupees: Rs.");
            bool boolBal = double.TryParse(Console.ReadLine(), out double balance);
            while (!boolBal && Math.Round(balance, 2) > 0)
            {
                System.Console.WriteLine("INVALID AMOUNT!");
                System.Console.Write("Enter Correct Amount in Rupees: Rs.");
                boolBal = double.TryParse(Console.ReadLine(), out balance);
            }

            //Saving Customer details in customerDetails List
            CustomerDetails customer = new CustomerDetails(name, fatherName, gender, mobileNumber, dob, mailId, location, balance);
            customerDetailsList.Add(customer);

            //Displaying Customer ID after completion of Registration
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("\nCUSTOMER REGISTRATION SUCCESSFUL!");
            System.Console.WriteLine("---------------------------------------\n");
            System.Console.WriteLine("YOUR CUSTOMER ID IS " + customer.CustomerID);
            System.Console.WriteLine("Please note down your CUSTOMER ID.");
            System.Console.WriteLine("\n---------------------------------------\n");
            Console.ResetColor();

        }


        public static void Login()
        {
            System.Console.WriteLine("\nLOGIN");
            // Ask for the  customerID  of the customer
            System.Console.Write("Enter Your customer ID: ");
            string customerId = Console.ReadLine().ToUpper();
            bool custCond = true;
            // Check the CustomerID  in the customer list
            foreach (CustomerDetails customer in customerDetailsList)
            {
                if (customerId.Equals(customer.CustomerID))
                {
                    custCond = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("\n-------------VALID CARD ID-------------\n");
                    System.Console.WriteLine("LOGGED IN SUCCESSFULLY!");
                    System.Console.WriteLine($"Welcome {customer.Name}!");
                    System.Console.WriteLine("\n---------------------------------------\n");
                    Console.ResetColor();
                    currentlyLoggedInCustomer = customer;
                    // Calling submenu
                    SubMenu();
                    break;
                }
            }
            if (custCond)
            {
                System.Console.WriteLine("INVALID CUSTOMER ID!");
            }
        }


        public static void SubMenu()
        {
            bool tryParseChecker, exitChecker = false;
            do
            {
                //Listing Sub-Menu
                System.Console.WriteLine("\n1. Show Profile  \n2. Order Food \n3. Cancel Order \n4. Modify Order \n5. Order History \n6. Recharge Wallet \n7. Show Wallet Balance \n8. Exit ");
                System.Console.Write("\nEnter the  Appropriate digit[ENTER - 1/2/3/4/5/6/7/8]: ");
                tryParseChecker = int.TryParse(Console.ReadLine(), out int subOption);
                switch (subOption)
                {
                    case 1:
                        {
                            ShowProfile();
                            break;
                        }
                    case 2:
                        {
                            OrderFood();
                            break;
                        }
                    case 3:
                        {
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            RechargeWallet();
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            //Exit
                            exitChecker = true;
                            System.Console.WriteLine("\nRedirecting back to MAIN MENU.....");
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("INVALID ENTRY! [ENTER - 1 / 2 / 3 / 4 / 5 / 6 / 7 / 8 ]");
                            break;
                        }
                }
            } while (!(tryParseChecker && exitChecker));


        }

        public static void ShowProfile()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("\n---------------------------------------\n");
            //Displaying Customer Details
            System.Console.WriteLine($"\n Customer ID: {currentlyLoggedInCustomer.CustomerID}\n Name: {currentlyLoggedInCustomer.Name}\n FatherName: {currentlyLoggedInCustomer.FatherName}\n Gender: {currentlyLoggedInCustomer.Gender}\n Mobile: {currentlyLoggedInCustomer.Mobile}\n DOB: {currentlyLoggedInCustomer.DOB.ToString("dd/MM/yyyy")}\n Mail ID: {currentlyLoggedInCustomer.MailID}\n Location: {currentlyLoggedInCustomer.Location}");
            ShowWalletBalance();
            System.Console.WriteLine("\n---------------------------------------\n");
            Console.ResetColor();
        }

        public static void OrderFood()
        {
            System.Console.WriteLine("\nORDER FOOD");
            double totalPrice = 0;
            OrderDetails order = new OrderDetails(currentlyLoggedInCustomer.CustomerID, totalPrice, DateTime.Now, OrderStatus.Initiated);
            List<ItemDetails> localItemList = new List<ItemDetails>();
            //Listing Food Details
            string choice;
            do
            {
                var table = new ConsoleTable("Food ID", "Food Name", "Price Per Quantity", "Quantity Available");
                foreach (FoodDetails food in foodDetailsList)
                {
                    table.AddRow(food.FoodID, food.FoodName, food.PricePerQuantity, food.QuantityAvailable);
                }
                System.Console.Write(table);
                System.Console.WriteLine();
                System.Console.Write("\nSelect the Food with Food ID: ");
                string foodId = Console.ReadLine().ToUpper();
                bool boolFood = false;
                ItemDetails item;
                double itemPrice;
                foreach (FoodDetails food in foodDetailsList)
                {
                    if (foodId.Equals(food.FoodID))
                    {
                        boolFood = true;
                        System.Console.Write("\nEnter the Food Quantity(In whole numbers): ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        if (quantity > 0 && quantity <= food.QuantityAvailable)
                        {
                            itemPrice = food.PricePerQuantity * quantity;
                            item = new ItemDetails(order.OrderID, food.FoodID, quantity, itemPrice);
                            food.QuantityAvailable -= quantity;
                            localItemList.Add(item);
                            totalPrice += itemPrice;
                        }
                        else
                        {
                            System.Console.WriteLine("FOOD QUANTITY NOT AVAILABLE!");
                            System.Console.WriteLine("Available quantity is " + food.QuantityAvailable);
                        }
                        break;
                    }

                }
                if (!boolFood) System.Console.WriteLine("INVALID FOOD ID!");

                System.Console.WriteLine("\nDo you want to Order anything else or give an food quantity which is available? (Yes/No): ");
                choice = Console.ReadLine().ToLower();
                while (choice != "yes" || choice != "no")
                {
                    System.Console.WriteLine("INVALID ENTRY! ENTER YES / NO.");
                    choice = Console.ReadLine();

                }

            } while (choice == "yes");

            System.Console.WriteLine("Do you want to confirm the purchase? (Yes/No): ");
            choice = Console.ReadLine().ToLower();
            while (choice != "yes" || choice != "no")
            {
                System.Console.WriteLine("INVALID ENTRY! ENTER YES / NO.");
                choice = Console.ReadLine();

            }
            string rechargeChoice = "";
            if (choice == "yes")
            {
                bool boolBal = false;
                do
                {
                    if (currentlyLoggedInCustomer.WalletBalance >= totalPrice)
                    {

                        order.TotalPrice = totalPrice;
                        order.Status = OrderStatus.Ordered;
                        currentlyLoggedInCustomer.DeductBalance(totalPrice);
                        foreach (ItemDetails item in localItemList)
                        {
                            itemDetailsList.Add(item);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("INSUFFICIENT BALANCE! Total Price is " + totalPrice);
                        System.Console.WriteLine("Your");
                        ShowWalletBalance();
                        System.Console.WriteLine("Do you want to Recharge? (Yes/No): ");
                        rechargeChoice = Console.ReadLine().ToLower();
                        while (rechargeChoice != "yes" || rechargeChoice != "no")
                        {
                            System.Console.WriteLine("INVALID ENTRY! ENTER YES / NO.");
                            rechargeChoice = Console.ReadLine();

                        }
                        if (rechargeChoice == "yes")
                        {
                            RechargeWallet();
                            boolBal = true;

                        }
                        else
                        {
                            boolBal = false;
                        }

                    }
                } while (boolBal);
            }
            if (choice == "no" || rechargeChoice == "no")
            {

                foreach (FoodDetails food in foodDetailsList)
                {
                    foreach (ItemDetails item in localItemList)
                    {

                        if (food.FoodID.Equals(item.FoodID))
                        {
                            food.QuantityAvailable += item.PurchaseCount;
                        }
                    }
                }

            }

        }



        public static void CancelOrder()
        {
         
                // foreach (FoodDetails food in foodDetailsList)
                // {
                //     foreach (ItemDetails item in localItemList)
                //     {

                //         if (food.FoodID.Equals(item.FoodID))
                //         {
                //             food.QuantityAvailable += item.PurchaseCount;
                //         }
                //     }
                // }

                // currentlyLoggedInCustomer.WalletRecharge(totalPrice);
            
        }

        public static void ModifyOrder()
        {

        }

        public static void OrderHistory()
        {
            System.Console.WriteLine("\nORDER HISTORY");
            //Listing Order history of the particular Customer
            var table = new ConsoleTable("Order ID", "Customer ID", "Total Price", "Date of Order", "Order Status");
            foreach (OrderDetails order in orderDetailsList)
            {
                if (currentlyLoggedInCustomer.CustomerID.Equals(order.CustomerID))
                    table.AddRow(order.OrderID, order.CustomerID, order.TotalPrice, order.DateOfOrder, order.Status);
            }
            System.Console.Write(table);
            System.Console.WriteLine();

        }


        public static void RechargeWallet()
        {
            System.Console.WriteLine("\nWALLET RECHARGE");
            //Getting the amount to be recharged
            System.Console.Write("Enter the amount to be recharged: ");
            bool boolAmt = double.TryParse(Console.ReadLine(), out double amount);
            while (!(boolAmt && Math.Round(amount, 2) > 0))
            {
                System.Console.WriteLine("INVALID AMOUNT!");
                System.Console.Write("Enter valid amount (Amount should not be negative and less than Rs. 1): ");
                boolAmt = double.TryParse(Console.ReadLine(), out amount);
            }
            //Calling Wallet Recharge method
            currentlyLoggedInCustomer.WalletRecharge(amount);
            System.Console.WriteLine("RECHARGE SUCCESSFUL!");
            ShowWalletBalance();
        }


        public static void ShowWalletBalance()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("\n---------------------------------------\n");
            System.Console.WriteLine("\nWALLET BALANCE");
            //Displaying Wallet Balance
            System.Console.WriteLine($"{currentlyLoggedInCustomer.Name} your balance is Rs. {currentlyLoggedInCustomer.WalletBalance}");
            System.Console.WriteLine("\n---------------------------------------\n");
            Console.ResetColor();
        }


    }
}