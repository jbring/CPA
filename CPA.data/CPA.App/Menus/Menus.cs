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
            Console.WriteLine("2. Quit");                       // TODO: Quit funkar inte
            var action = Convert.ToInt32(Console.ReadLine());   // TODO: Överflödig konvertering, kraschar vid ogiltig inmatning, kanske bara string istället
            Console.Clear();

            if (action == 1)                                    // TODO: Exempelvis action == "1"
                Display.DisplayAllCustomers(customers);
            else if (action == 2)
            {
                // TODO: Quit
            }

        }
        public static void OneCustomerPurchaseMenu(List<Customer> customers) // TODO: Oklart metodnamn, oklart vad metoden gör
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select customer (customerId):");
            Console.ResetColor();
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Display.DisplayAllBuysForOneCustomer(customers, customerId);
        }
    }
}
