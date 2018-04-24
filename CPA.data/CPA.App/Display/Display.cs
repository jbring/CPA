using System;
using System.Collections.Generic;
using System.Text;
using CPA.domain;

namespace CPA.App.Display
{
    public class Display
    {
        public static void DisplayAllBuysForOneCustomer(List<Customer> allCustomers, int customerId)
        {
            var customer = allCustomers.Find(c => c.Id == customerId);
            string format = "{0,-20} {1,-20} {2,-20} {3,-20}";

            Console.WriteLine($"Here are {customer.FirstName} {customer.LastName}s buys");
            Console.WriteLine(format, "What", "When", "Where", "why");

            foreach (var buy in customer.Buy)
            {
                Console.WriteLine(format, buy.What.Category, buy.When.DateTime, buy.Where.Platform, buy.Why.Impulse);
            }
        }


        public static void DisplayAllCustomers(List<Customer> customer)
        {
            Console.WriteLine($"{"CustomerId", -20}{"Name",-20}{"Amount of buys"}");
            foreach (var oneCustomer in customer)
            {
                Console.WriteLine($"{oneCustomer.Id,-20}" +
                                  $"{oneCustomer.FirstName} {oneCustomer.LastName}" +
                                  $"{"",-20}" +
                                  $"{oneCustomer.Buy.Count}");
            }

        }

    }
}
