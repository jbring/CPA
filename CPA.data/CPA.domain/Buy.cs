
using System;
using System.Collections.Generic;
using System.Text;

namespace CPA.domain
{
    public class Buy
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public When When { get; set; }
        public What What { get; set; }
        public Where Where { get; set; }
        public Why Why { get; set; }

        ///hej hej
        /// hej
    }
}
