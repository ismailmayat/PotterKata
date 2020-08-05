using System;
using System.Collections.Generic;
using System.Configuration;
using FluentAssertions;
using NUnit.Framework;
using PotterDiscount;

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
            
            var sut = new Discount();

            sut.Calculate(books).Should().Be(OneBookPrice);
        }

        [Test]
        public void Two_Different_Books_Gives_Five_Per_Cent_Discount()
        {
            var philosophersStone = new Book(OneBookPrice,"978-1408855652");
            
            var chamberOfSecrets = new Book(OneBookPrice,"978-1408855669");
            
            IEnumerable<Book> books = new List<Book>{philosophersStone,chamberOfSecrets};
            
            var sut = new Discount();

            sut.Calculate(books).Should().Be((decimal)15.20);
        }

    }

    public class Discount
    {
        public decimal Calculate(IEnumerable<Book> books)
        {
            decimal total=0;

            //how to determine we have different types and 
            
            foreach (var book in books)
            {
                total += book.BookPrice;
            }

            return total;
        }
    }
}