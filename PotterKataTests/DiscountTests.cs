using FluentAssertions;
using NUnit.Framework;
using PotterDiscount.Discounts;

namespace PotterKataTests
{
    [TestFixture]
    public class DiscountTests
    {
        private const decimal OneBookPrice = 8;

        private Discounter sut = ObjectMother.Builder.Discounter();
        
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
        
            sut.Apply(books).Should().Be((decimal)15.20);
        }

        [Test]
        public void Three_Unique_Books_Gives_Ten_Per_Cent_Discount()
        {
            var books = ObjectMother.Builder.ThreeUniqueBooks(OneBookPrice);
        
            sut.Apply(books).Should().Be((decimal)21.60);
        }

        [Test]
        public void Four_Unique_Books_Gives_Twenty_Per_Cent_Discount()
        {
            var books = ObjectMother.Builder.FourUniqueBooks(OneBookPrice);

            sut.Apply(books).Should().Be((decimal) 25.60);
        }

        [Test]
        public void Five_Unique_Books_Gives_Twenty_Five_Per_Cent_Discount()
        {
            var books = ObjectMother.Builder.FiveUniqueBooks(OneBookPrice);

            sut.Apply(books).Should().Be((decimal) 30.00);
        }
    }
}