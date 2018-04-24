using System;
using System.Collections.Generic;
using System.Text;
using CPA.domain;

namespace CPA.App
{
    public class Menus
    {
        public void StartMenu(List<Customer> customers)
        {
            Console.WriteLine("Hello. Make a choise");
            Console.WriteLine("1. Dislay all customers");
            Console.WriteLine("2. Quit");
            int action = Convert.ToInt32(Console.ReadLine());

            if (action==1)
                Display.DisplayAllBuysForOneCustomer(customers);
            else if (action == 2)
            {
                //Quit
            }
        }
    }
}
    