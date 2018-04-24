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
            string format = "{0,-20} {1,-20} {2,-20} {3,-20}";

            Console.WriteLine($"Here are {customer.FirstName} {customer.LastName}s buys");
            Console.WriteLine(format, "What", "When", "Where", "why");

            foreach (var buy in customer.Buy)
            {
                Console.WriteLine(format, buy.What.Category, buy.When.DateTime, buy.Where.Platform, buy.Why.Impulse);
            }
        }

    }
}
