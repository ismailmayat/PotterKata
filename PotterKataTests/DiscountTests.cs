﻿using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using PotterDiscount.Discounts;

namespace PotterKataTests
{
    [TestFixture]
    public class DiscountTests
    {
        private const decimal OneBookPrice = 8.00M;

        private readonly Discounter sut = ObjectMother.Builder.Discounter();

        // [Test]
        // public void tmp()
        // {
        //     var list = ObjectMother.Builder.Two_Two_Two_One_One(8).ToList();
        //     
        //     var duplicates = list.GroupBy(x => x.Isbn) 
        //         .Where(g => g.Count() > 1)
        //         .SelectMany(g => g);
        //
        //     var uniques = list.GroupBy(x => x.Isbn) 
        //         .Where(g => g.Count() == 1)
        //         .SelectMany(g => g);
        //
        //     uniques.Count().Should().Be(2);
        //
        //     duplicates.Count().Should().Be(6);
        // }

        [Test]
        public void One_Book_Costs_Fixed_Price()
        {

            var books = ObjectMother.Builder.OneUniqueBook(OneBookPrice);
  
            sut.Apply(books).Should().Be(OneBookPrice);
            
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Same_Books_Should_Be_Multiple_Of_Fixed_Price(int noOfBooks)
        {
            var sameBooks = ObjectMother.Builder.SameBook(noOfBooks,OneBookPrice);

            sut.Apply(sameBooks).Should().Be(noOfBooks * OneBookPrice);
        }

        [Test]
        public void Two_Different_Books_Gives_Five_Per_Cent_Discount()
        {

            var books = ObjectMother.Builder.TwoUniqueBooks(OneBookPrice);
        
            sut.Apply(books).Should().Be(15.20M);
        }

        [Test]
        public void Three_Unique_Books_Gives_Ten_Per_Cent_Discount()
        {
            var books = ObjectMother.Builder.ThreeUniqueBooks(OneBookPrice);
        
            sut.Apply(books).Should().Be(21.60M);
        }

        [Test]
        public void Four_Unique_Books_Gives_Twenty_Per_Cent_Discount()
        {
            var books = ObjectMother.Builder.FourUniqueBooks(OneBookPrice);

            sut.Apply(books).Should().Be( 25.60M);
        }

        [Test]
        public void Five_Unique_Books_Gives_Twenty_Five_Per_Cent_Discount()
        {
            var books = ObjectMother.Builder.FiveUniqueBooks(OneBookPrice);

            sut.Apply(books).Should().Be(30.00M);
        }

        [Test]
        public void Three_Unique_Books_Gives_Ten_Per_Cent_Discount_Fourth_Is_Full_Price()
        {
            decimal expectedTotal = 29.60M;

            var books = ObjectMother.Builder.ThreeUniqueBooksOneDuplicate(OneBookPrice);

            sut.Apply(books).Should().Be(expectedTotal);

        }

        [Test]
        public void Books_Two_Two_Two_One_One_Should_Discount_Correctly()
        {
            decimal expectedTotal = 51.60M;

            var books = ObjectMother.Builder.Two_Two_Two_One_One(OneBookPrice);

            sut.Apply(books).Should().Be(expectedTotal);
        }
    }
    
}