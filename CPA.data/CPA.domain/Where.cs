using System;
using System.Collections.Generic;
using System.Text;

namespace CPA.domain
{
    public class Where
    {
        public int Id { get; set; }
        public Platform Platform { get; set; }
    }

    public enum Platform
    {
       Ios, Windows, Android, Webpage, PhoneCall, Store
    }
}
