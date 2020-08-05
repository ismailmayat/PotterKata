using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace PotterKataTests
{
    [TestFixture]
    public class DiscountTests
    {
        [Test]
        public void One_Book_Costs_Fixed_Price()
        {
            decimal oneBookPrice = 8;
            
            var book = new Book(oneBookPrice);
            
            IEnumerable<Book> books =new List<Book>{book};
            
            var sut = new Discount();

            sut.Calculate(books).Should().Be(oneBookPrice);
        }
        
    }

    public class Discount
    {
        public decimal Calculate(IEnumerable<Book> books)
        {
            decimal total=0;

            foreach (var book in books)
            {
                total += book.OneBookPrice;
            }

            return total;
        }
    }

    public class Book
    {

        public decimal OneBookPrice { get; }
        public Book(decimal oneBookPrice)
        {
            OneBookPrice = oneBookPrice;
        }
        
    }
}