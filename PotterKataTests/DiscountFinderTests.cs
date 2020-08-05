using System.Collections.Generic;
using NUnit.Framework;
using PotterDiscount;
using PotterDiscount.Discounts;

namespace PotterKataTests
{
    [TestFixture]
    public class DiscountFinderTests
    {
        private const decimal OneBookPrice = 8;
        
        [Test]
        public void When_Two_Different_Books_Two_Discount_IsApplied()
        {
            var philosophersStone = new Book(OneBookPrice,"978-1408855652");
            
            var chamberOfSecrets = new Book(OneBookPrice,"978-1408855669");
            
            IEnumerable<Book> books = new List<Book>{philosophersStone,chamberOfSecrets};
            
            IDiscount oneBookDiscount = new OneBookDiscount(1);
            
            IDiscount twoBookDiscount = new TwoBookDiscount(2);
            
            IEnumerable<IDiscount> discounts = new List<IDiscount>{oneBookDiscount,twoBookDiscount};
            
            var discounter = new Discounter(discounts);

            discounter.Apply(books);
        }
    }
}