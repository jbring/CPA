using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPA.data;
using CPA.domain;
using Microsoft.EntityFrameworkCore;
using CPA.App.Display.Display;


namespace CPA.App
{
    public class App
    {
        public void Run()
        {
            //RecreateDatabase();
           

            //AddTenCustomers();
            var buys = AddNewBuy(10);
            var buyswithcustomers = AddCustomerToBuy(buys);




            AddNewListOfBuys(buyswithcustomers);
            var customer=GetCustomerWithBuys();
            var customers = GetCustomerWithBuys();
            var a = 10;


            Console.WriteLine(customers[0].Buy.Count);

            //AddNewBuy();
            //var customer = PickRandomCustomer();
            //Console.WriteLine(customer.FirstName);
        }

        private List<Customer> GetCustomerWithBuys()
        {
            using (var context = new CPAcontext())
            {
                var customer = context.Customers
                    .Include(b => b.Buy)
                    .ThenInclude(what=> what.What)
                    .Include(b => b.Buy)
                    .ThenInclude(when=>when.When)
                    .Include(b => b.Buy)
                    .ThenInclude(where => where.Where)
                    .Include(b => b.Buy)
                    .ThenInclude(why => why.Why)
                    .ToList();
                return customer;
            }
        }

        private List<Customer> AddBuyToCustomer(List<Buy> buys)
        {
            List<Customer> customersWithBuys = new List<Customer>();
            foreach (var buy in buys)
            {
                var customer = PickRandomCustomer();
                customer.Buy.Add(buy);
                customersWithBuys.Add(customer);
            }
            return customersWithBuys;
        }

        private void RecreateDatabase()
        {
            using (var context = new CPAcontext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        private void AddNewListOfBuys(List<Buy> listOfBuys)
        {
            using (var context = new CPAcontext())
            {
                foreach (var buy in listOfBuys)
                {
                    context.Buy.Add(buy);
                }
                context.SaveChanges();
            }
        }

        private List<Buy> AddCustomerToBuy(List<Buy> buys)
        {
            List<Buy> buysIncludingCustomer=new List<Buy>();
            foreach (var buy in buys)
            {
                buy.CustomerId = PickRandomCustomer().Id;
                buysIncludingCustomer.Add(buy);
            }
            return buysIncludingCustomer;
        }

        private Customer PickRandomCustomer()
        {

            using (var context = new CPAcontext())
            {
                var customers = context.Customers.ToList();
                var random = new Random();
                var rad = random.Next(1, customers.Count+1);

                var cust = context.Customers.First(n => n.Id == rad);
                return cust;
            }
        }

        private Customer AddOneCustomers()
        {
            var customer = new Customer()
            {
                FirstName = "Anna",
                LastName = "Toresson",
                Email = "AToresson@hotmail.com",
            };
            return customer;
        }

        public List<Buy> AddNewBuy(int amountOfBuys)
        {
            List<Buy> listOfBuys = new List<Buy>();
            for (int i = 0; i < amountOfBuys; i++)
            {
                var buy = new Buy
                {
                    What = new What()
                    {
                        Category = GetRandomCategory(),
                        PriceRange = GetRandomPriceRange(),

                    },
                    When = new When()
                    {
                        DateTime = GetRandomTime(new DateTime(2017, 01, 01, 00, 00, 00))
                    },
                    Why = new Why()
                    {
                        IsBarginBuy = GetTrueOrFalse(),
                        IsTestWinner = GetTrueOrFalse(),
                        IsFromPriceRunner = GetTrueOrFalse(),
                        Impulse = GetImpulseAnswer()
                    },
                    Where = new Where()
                    {
                        Platform = GetPlatform()
                    },
                };
                listOfBuys.Add(buy);
            }
            return listOfBuys;
        }


        private Platform GetPlatform()
        {
            var ran = new Random();
            var value = Enum.GetValues(typeof(Platform));
            Platform randomPlatform = (Platform) value.GetValue(ran.Next(0, value.Length));

            return randomPlatform;
        }

        private bool GetTrueOrFalse()
        {
            var random = new Random();
            int zeroOrOne = random.Next(0, 1);
            if (zeroOrOne == 0)
                return true;
            else
                return false;
        }

        private Impulse GetImpulseAnswer()
        {
            var ran = new Random();
            var value = Enum.GetValues(typeof(Impulse));
            Impulse randomCategory = (Impulse) value.GetValue(ran.Next(0, value.Length));

            return randomCategory;
        }

        private DateTime GetRandomTime(DateTime start)
        {
            Random gen = new Random();
            int range = (int) ((TimeSpan)(DateTime.Today - start)).TotalHours;
            var a = gen.Next(0, range);
            return start.AddHours(a);
        }


        private PriceRange GetRandomPriceRange()
        {
            var ran = new Random();
            var value = Enum.GetValues(typeof(PriceRange));
            PriceRange randomPriceRange = (PriceRange) value.GetValue(ran.Next(0, value.Length));

            return randomPriceRange;
        }

        private Category GetRandomCategory()
        {
            var ran = new Random();
            var value = Enum.GetValues(typeof(Category));
            Category randomCategory = (Category) value.GetValue(ran.Next(0, value.Length));

            return randomCategory;
        }

        private void AddTenCustomers()
        {
            var customer = new Customer()
            {
                FirstName = "Anna",
                LastName = "Toresson",
                Email = "AToresson@hotmail.com",
            };
            var customer1 = new Customer()
            {
                FirstName = "Anderas",
                LastName = "Hellström",
                Email = "AHellstrom@hotmail.com",
            };
            var customer2 = new Customer()
            {
                FirstName = "Joakim",
                LastName = "Bring",
                Email = "JBring@hotmail.com",
            };
            using (var context = new CPAcontext())
            {
                context.Customers.AddRange(customer, customer1, customer2);
                context.SaveChanges();
            }
        }

        public static decimal CollectPriceClass(decimal minPrice, decimal maxPrice, decimal price)
        {
            var partPrice = (maxPrice - minPrice) / 10;
            var result = (price - minPrice) / partPrice;
            return Math.Round(result, 0);
        }

        private void DisplayListOfCustomers(List<Customer> customer)
        {
            
            Console.WriteLine($"{"CustomerId",-20}{"Name", -20}{"Numbers of buys"}");
            foreach (var oneCustomer in customer)
            {
                Console.WriteLine($"{oneCustomer.Id,-20}{$"{oneCustomer.FirstName} {oneCustomer.LastName}",-20}{oneCustomer.Buy.Count}");
            }
           

        }
    }
}

