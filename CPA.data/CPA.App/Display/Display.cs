using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPA.domain;

namespace CPA.App
{
    public class Display
    {
        public static void DisplayAllBuysForOneCustomer(List<Customer> allCustomers, int customerId) // TODO: Sales istället för Buys?
        {
            var customer = allCustomers.Find(c => c.Id == customerId);
            string format = "{0,-15} {1,-23} {2,-10} {3,-12} {4,-12} {5,-12} {6,-12}";

            Console.Write($"Here are");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" {customer.FirstName} {customer.LastName}s ");
            Console.ResetColor();
            Console.Write("purchases!");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(format, "What", "When", "Where", "Impulse", "Bargin", "PriceRunner", "TestWinner"); // TODO: Stavning Bargain
            var builder = new StringBuilder();
            Console.WriteLine(builder.Append('-',105));
            Console.ResetColor();
            

            foreach (var buy in customer.Purchase)
            {
                var barginBuy = buy.Why.IsBarginPurchase == false ? "No" : "Yes";
                var priceRunner = buy.Why.IsFromPriceRunner == false ? "No" : "Yes"; // TODO: Sale.Reason istället för buy.Why ?
                var testWinner = buy.Why.IsFromPriceRunner == false ? "No" : "Yes";

                // TODO: Samt .Item istället för .What, .Time istället för .When, .Location istället för .Where ?
                Console.WriteLine(format, buy.What.Category, buy.When.DateTime, buy.Where.Platform, buy.Why.Impulse, barginBuy,priceRunner,testWinner);
            }

            Console.WriteLine();
        }
        public static void DisplayAllCustomers(List<Customer> customer)
        {
            var builder=new StringBuilder();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"CustomerId",-20}{"Name",-20}{"Number of purchases"}"); // TODO: Formatering
            Console.WriteLine(builder.Append('-',60));
            Console.ResetColor();
            foreach (var oneCustomer in customer)
            {
                Console.WriteLine($"{oneCustomer.Id,-20}{$"{oneCustomer.FirstName} {oneCustomer.LastName}",-20}{oneCustomer.Purchase.Count}");
            }

        }

        public static void DisplayTop3CustomersWithinMounth(List<Customer> customers)
        {
            Console.Clear();
            var top3 = customers.GroupBy(s => s)
                .OrderByDescending(b => b.Count()).Take(3);

            string format = "{1,-15}{1,-15}{1,-15}";
            Console.WriteLine(format,"First Name", "Last Name", "Number of purchases");
            Console.WriteLine("---------------------------------------------------------");
            foreach (var customer in top3)
                Console.WriteLine(format,customer.Key.FirstName,customer.Key.LastName,customer.Key.Buy.Count);
        }
    }
}
