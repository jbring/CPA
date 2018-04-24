using System;
using System.Collections.Generic;

namespace CPA.domain
{
    public class Customer
    {
        //Försöker igen
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Buy> Buy { get; set; }

    }


}
