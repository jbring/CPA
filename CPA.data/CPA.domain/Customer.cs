using System;
using System.Collections.Generic;
using System.Text;
using CPA.domain;



namespace CPA.domain
{
    public class Customer
    {
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Purchase> Purchase { get; set; }

    }


}
