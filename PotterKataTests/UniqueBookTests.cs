using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using PotterDiscount;
using PotterDiscount.Discounts;

namespace PotterKataTests
{
    [TestFixture]
    public class UniqueTests
    {
        [Test]
        [TestCase("11111",1)]
        [TestCase("11111,22222",2)]
        [TestCase("11111,22222,33333",3)]
        [TestCase("11111,22222,33333,44444",4)]
        [TestCase("11111,22222,33333,44444,55555",5)]
        [TestCase("11111,11111,33333,44444,55555",4)]
        [TestCase("55555,55555,55555,55555,55555",1)]
        public void For_Given_No_Unique_Should_Match(string isbns, int expectedCount)
        {
            var bookIsbns = isbns.Split(',');
            
            var books = bookIsbns.Select(isbn => new Book(8, isbn)).ToList();
            
            var sut = new UniqueBooks(books);

            sut.Count().Should().Be(expectedCount);
        }

        [Test]
        public void List_With_Duplicates_Should_Be_True()
        {
            var books = ObjectMother.Builder.ThreeUniqueBooksOneDuplicate(4M);
            
            var sut = new UniqueBooks(books);

            sut.HasDuplicates().Should().BeTrue();
        }

        [Test]
        public void List_Without_Duplicates_Should_Be_False()
        {
            var books = ObjectMother.Builder.FourUniqueBooks(4M);
            
            var sut = new UniqueBooks(books);

            sut.HasDuplicates().Should().BeFalse();
        }
    }
}