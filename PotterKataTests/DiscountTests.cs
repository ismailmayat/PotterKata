using FluentAssertions;
using NUnit.Framework;

namespace PotterKataTests
{
    [TestFixture]
    public class DiscountTests
    {
        private const decimal OneBookPrice = 8;

        [Test]
        public void One_Book_Costs_Fixed_Price()
        {

            var books = ObjectMother.Builder.OneUniqueBook(OneBookPrice);

            var sut = ObjectMother.Builder.Discounter();
            
            sut.Apply(books).Should().Be(OneBookPrice);
            
        }
        
        [Test]
        public void Two_Different_Books_Gives_Five_Per_Cent_Discount()
        {

            var books = ObjectMother.Builder.TwoUniqueBooks(OneBookPrice);
            
            var sut = ObjectMother.Builder.Discounter();
        
            sut.Apply(books).Should().Be((decimal)15.20);
        }

    }
}