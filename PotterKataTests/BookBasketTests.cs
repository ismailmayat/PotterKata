using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using PotterDiscount;
using PotterDiscount.Discounts;

namespace PotterKataTests
{
    [TestFixture]
    public class BookBasketTests
    {
        
        [Test]
        public void List_With_Duplicates_Should_Be_True()
        {
            var sut = ObjectMother.Builder.ThreeUniqueBooksOneDuplicate(4M);
            
            sut.HasDuplicates().Should().BeTrue();
        }

        [Test]
        public void List_Without_Duplicates_Should_Be_False()
        {
            var sut = ObjectMother.Builder.FourUniqueBooks(4M);
            
            sut.HasDuplicates().Should().BeFalse();
        }
    }
}