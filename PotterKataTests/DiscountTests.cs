﻿using FluentAssertions;
using NUnit.Framework;
using PotterDiscount.Discounts;

namespace PotterKataTests
{
    [TestFixture]
    public class DiscountTests
    {
        private const decimal OneBookPrice = 8.00M;

        private readonly Discounter sut = ObjectMother.Builder.Discounter();
        
        [Test]
        public void One_Book_Costs_Fixed_Price()
        {

            var books = ObjectMother.Builder.OneUniqueBook(OneBookPrice);
  
            sut.Apply(books).Should().Be(OneBookPrice);
            
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
        public void Three_Unique_Books_Gives_Ten_Per_Cent_Discount_Forth_Is_Full_Price()
        {
            decimal expectedTotal = 29.60M;
            
        }
    }
    
}