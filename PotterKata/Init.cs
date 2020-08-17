using System.Collections.Generic;
using PotterKata.Discounts;

namespace PotterKata
{
    public static class Init
    {
        public static Discounter Discounter()
        { 
            IDiscount twoBookDiscount = new BookDiscount(2,5);
            
            IDiscount threeBookDiscount = new BookDiscount(3,10);
            
            IDiscount fourBookDiscount = new BookDiscount(4,20);
            
            IDiscount fiveBookDiscount = new BookDiscount(5,25);
            
            IEnumerable<IDiscount> discounts = new List<IDiscount>{twoBookDiscount,threeBookDiscount,fourBookDiscount,fiveBookDiscount};
            
            var discounter = new Discounter(discounts,8M,5);

            return discounter;
        }
    }
}