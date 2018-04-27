using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CPA.data;
using CPA.domain;
using Microsoft.EntityFrameworkCore;


namespace CPA.App
{
    public class App
    {
        public void Run()
        {
           RecreateDatabase();

            AddTenCustomers();
            var purchases = AddNewPurchase(50);
            var purchasesWithCustomers = AddCustomerToPurchase(purchases);




            AddNewListOfPurchases(purchasesWithCustomers);
            var customers = GetCustomerWithPurchases();



            Menus.StartMenu(customers);
            Menus.OneCustomerPurchaseMenu(customers);


            // TODO: Rensa
            //AddNewpurchase();
            //var customer = PickRandomCustomer();
            //Console.WriteLine(customer.FirstName);
        }

        private List<Customer> GetCustomerWithPurchases() // TODO: Borde kanske heta Customers
        {
            using (var context = new CPAcontext())
            {
                var customer = context.Customers            // TODO: Svårtydlig funktion pga upprepning och oklara namn
                    .Include(b => b.Purchase)
                    .ThenInclude(what=> what.What)
                    .Include(b => b.Purchase)
                    .ThenInclude(when=>when.When)
                    .Include(b => b.Purchase)
                    .ThenInclude(where => where.Where)
                    .Include(b => b.Purchase)
                    .ThenInclude(why => why.Why)
                    .ToList();
                return customer;
            }
        }

        private List<Customer> AddPurchaseToCustomer(List<Purchase> purchases)
        {
            List<Customer> customersWithPurchases = new List<Customer>();
            foreach (var purchase in purchases)
            {
                var customer = PickRandomCustomer();
                customer.Purchase.Add(purchase);
                customersWithPurchases.Add(customer);
            }
            return customersWithPurchases;
        }

        private void RecreateDatabase()
        {
            using (var context = new CPAcontext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        private void AddNewListOfPurchases(List<Purchase> listOfPurchases)
        {
            using (var context = new CPAcontext())
            {
                foreach (var purchase in listOfPurchases)
                {
                    context.Purchase.Add(purchase);
                }
                context.SaveChanges();
            }
        }

        private List<Purchase> AddCustomerToPurchase(List<Purchase> purchases)
        {
            List<Purchase> purchasesIncludingCustomer=new List<Purchase>();
            foreach (var purchase in purchases)
            {
                purchase.CustomerId = PickRandomCustomer().Id;
                purchasesIncludingCustomer.Add(purchase);
            }
            return purchasesIncludingCustomer;
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
            Console.WriteLine("Please enter firstname");
            var firstName = Console.ReadLine();
            CheckInputOfNames(firstName);
            Console.WriteLine("Please enter lastname");
            var lastName = Console.ReadLine();
            Console.WriteLine("Please enter E-Mail adress");
            var eMail = Console.ReadLine();

            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = eMail,
            };
            return customer;
        }

        public void CheckInputOfNames(string name) // TODO: Lägg validering i en egen class
        {
            var checkName = new Regex(@"^/[A-Za-z]+/g");
        }
        public List<Purchase> AddNewPurchase(int amountOfPurchases)
        {
            List<Purchase> listOfpurchases = new List<Purchase>();
            for (int i = 0; i < amountOfPurchases; i++)
            {
                var purchase = new Purchase
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
                        IsBarginPurchase = GetTrueOrFalse(),
                        IsTestWinner = GetTrueOrFalse(),
                        IsFromPriceRunner = GetTrueOrFalse(),
                        Impulse = GetImpulseAnswer()
                    },
                    Where = new Where()
                    {
                        Platform = GetPlatform()
                    },
                };
                listOfpurchases.Add(purchase);
            }
            return listOfpurchases;
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
            int zeroOrOne = random.Next(0, 2);
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
            var customer3 = new Customer()
            {
                FirstName = "Jon",
                LastName = "Jönsson",
                Email = "JJonson@hotmail.com",
            };
            var customer4 = new Customer()
            {
                FirstName = "Petra",
                LastName = "Svensson",
                Email = "PSvensson@hotmail.com",
            };
            var customer5 = new Customer()
            {
                FirstName = "Roland",
                LastName = "Andersson",
                Email = "RAndersson@hotmail.com",
            };
            var customer6 = new Customer()
            {
                FirstName = "Dennis",
                LastName = "Randevall",
                Email = "DennisR@hotmail.com",
            };
            var customer7 = new Customer()
            {
                FirstName = "Sofia",
                LastName = "Svensson",
                Email = "SS@hotmail.com",
            };
            var customer8 = new Customer()
            {
                FirstName = "Karl",
                LastName = "Karlsson",
                Email = "KKarlsson@hotmail.com",
            };
            var customer9 = new Customer()
            {
                FirstName = "Sara",
                LastName = "Persson",
                Email = "SaraP@hotmail.com",
            };
            using (var context = new CPAcontext())
            {
                context.Customers.AddRange(customer, customer1, customer2, customer3, customer4, customer5, customer6, customer7, customer8, customer9);
                context.SaveChanges();
            }
        }

        public static decimal CollectPriceClass(decimal minPrice, decimal maxPrice, decimal price)
        {
            var partPrice = (maxPrice - minPrice) / 10;
            var result = (price - minPrice) / partPrice;
            return Math.Round(result, 0);
        }
    }
}

