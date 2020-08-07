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
    }
}