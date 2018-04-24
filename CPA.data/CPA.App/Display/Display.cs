using System;
using System.Collections.Generic;
using System.Text;
using CPA.domain;

namespace CPA.App
{
    public class Display
    {
        public static void DisplayAllBuysForOneCustomer(List<Customer> allCustomers, int customerId)
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
            Console.WriteLine(format, "What", "When", "Where", "Impulse", "Bargin", "PriceRunner", "TestWinner");
            var builder = new StringBuilder();
            Console.WriteLine(builder.Append('-',105));
            Console.ResetColor();
            

            foreach (var buy in customer.Buy)
            {
                var barginBuy = buy.Why.IsBarginBuy == false ? "No" : "Yes";
                var priceRunner = buy.Why.IsFromPriceRunner == false ? "No" : "Yes";
                var testWinner = buy.Why.IsFromPriceRunner == false ? "No" : "Yes";

                Console.WriteLine(format, buy.What.Category, buy.When.DateTime, buy.Where.Platform, buy.Why.Impulse, barginBuy,priceRunner,testWinner);
            }

            Console.WriteLine();
        }
        public static void DisplayAllCustomers(List<Customer> customer)
        {
            var builder=new StringBuilder();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"CustomerId",-20}{"Name",-20}{"Number of purchases"}");
            Console.WriteLine(builder.Append('-',60));
            Console.ResetColor();
            foreach (var oneCustomer in customer)
            {
                Console.WriteLine($"{oneCustomer.Id,-20}{$"{oneCustomer.FirstName} {oneCustomer.LastName}",-20}{oneCustomer.Buy.Count}");
            }

        }
    }
}
