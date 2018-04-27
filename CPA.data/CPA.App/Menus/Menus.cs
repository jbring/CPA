using System;
using System.Collections.Generic;
using System.Text;
using CPA.domain;

namespace CPA.App
{
    public class Menus
    {
        public static void StartMenu(List<Customer> customers)
        {
            Console.WriteLine("Hello, make a choice");
            Console.WriteLine("1. Display all customers");
            Console.WriteLine("2. Quit");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (action == 1)
                Display.DisplayAllCustomers(customers);
            else if (action == 2)
            {
                //Quit
            }

        }
        public static void OneCustomerPurchaseMenu(List<Customer> customers)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select customer (customerId):");
            Console.ResetColor();
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Display.DisplayAllBuysForOneCustomer(customers, customerId);
        }
        public static void MenuToPickWhenCustomersMakeTheirPurchases(List<Customer> customers)
        {
            while (true)
            {
                Console.WriteLine("What mounth are you running the campaign? Answer with a number 1-12");
                Console.WriteLine("1. January\n2. February\n3. March\n4. April\n5. May\n6. June\n7. July\n8. August\n9. September\n10. October\n11. November\n12. December");
                string answer = Console.ReadLine();
                if (answer=="1"||answer=="2"||answer=="3"||answer=="4"||answer == "5" || answer == "6" || answer == "7" || answer == "8" || answer == "9" || answer == "10" || answer == "11" || answer == "12")
                {
                    var top3Customers = App.GetTop3CustomersWithinMounth(Convert.ToInt16(answer));
                    Display.DisplayTop3CustomersWithinMounth(top3Customers);
                }
                else
                    Console.WriteLine("Invalid input");
            }

        }
    }
}
