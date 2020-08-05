using System.Collections.Generic;
using PotterDiscount.Discounts;

namespace PotterKataTests.ObjectMother
{
    public static class Builder
    {
        public static Discounter Discounter()
        {
            IDiscount oneBookDiscount = new OneBookDiscount(1);
            
            IDiscount twoBookDiscount = new TwoBookDiscount(2);
            
            IEnumerable<IDiscount> discounts = new List<IDiscount>{oneBookDiscount,twoBookDiscount};
            
            var discounter = new Discounter(discounts);

            return discounter;
        }
    }
}