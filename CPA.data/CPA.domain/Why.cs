using System;
using System.Collections.Generic;
using System.Text;

namespace CPA.domain
{
    public class Why
    {
        public int Id { get; set; }
        public bool IsFromPriceRunner { get; set; }
        public bool IsBarginPurchase { get; set; }
        public bool IsTestWinner { get; set; }
        public Impulse Impulse { get; set; }
    }

    public enum Impulse
    {
        UpTo5min, UpTo15min, UpTo30min, Over30min
    }
}
