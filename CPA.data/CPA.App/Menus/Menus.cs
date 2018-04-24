using System;
using System.Collections.Generic;
using System.Text;

namespace CPA.App
{
    class Menus
    {

        private void DisplayCustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Display a customers order history");
                Console.WriteLine("2. Quit");

                var choice = Console.ReadLine();
                if (choice == "1")
                {

                }
                else
                    break;

            }
            

        }
    }
}
