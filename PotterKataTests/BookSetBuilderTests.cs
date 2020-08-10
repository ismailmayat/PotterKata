using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using PotterDiscount;

namespace PotterKataTests
{
    [TestFixture]
    public class BookSetBuilderTests
    {
        [Test]
        public void When_Two_Sets_In_List_We_Get_Two_Sets()
        {
            var bookBasket = ObjectMother.Builder.Two_Two_Two_One_One(8M);
            
            var builder = new BookSetBuilder(5);

            var sut = builder.Build(bookBasket.Books.ToList());

            sut.Count.Should().Be(2);
        }

        [Test]
        public void When_One_Set_In_List_Bigger_Than_Five_Set()
        {
            var bigListOneSet = ObjectMother.Builder.ThreeUniqueBooksOneDuplicate(8M);
            
            var builder =new BookSetBuilder(5);

            var sut = builder.Build(bigListOneSet.Books.ToList());

            sut.Count().Should().Be(1);
        }

        [Test]
        public void One_Thousands_Books_Five_Of_Each_Should_Give_Two_HundredSets()
        {
            var books = ObjectMother.Builder.OneThousandBooks(8M);
            
            var builder = new BookSetBuilder(5);

            var sut = builder.Build(books.ToList());

            sut.Count().Should().Be(200);

        }
    }
}