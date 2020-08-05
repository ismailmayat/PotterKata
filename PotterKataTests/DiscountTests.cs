using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PotterDiscount;
using PotterDiscount.Discounts;

namespace PotterKataTests
{
    [TestFixture]
    public class DiscountTests
    {
        private const decimal OneBookPrice = 8;

        [Test]
        public void One_Book_Costs_Fixed_Price()
        {
           
            var book = new Book(OneBookPrice,"978-1408855652");
            
            IEnumerable<Book> books = new List<Book>{book};

            var sut = ObjectMother.Builder.Discounter();
            
            sut.Apply(books).Should().Be(OneBookPrice);
            
        }
        
        [Test]
        public void Two_Different_Books_Gives_Five_Per_Cent_Discount()
        {
            var philosophersStone = new Book(OneBookPrice,"978-1408855652");
            
            var chamberOfSecrets = new Book(OneBookPrice,"978-1408855669");
            
            IEnumerable<Book> books = new List<Book>{philosophersStone,chamberOfSecrets};
            
            var sut = new TwoBookDiscount(2);
        
            sut.Calculate(books).Should().Be((decimal)15.20);
        }

    }
}