using System.Collections.Generic;
using System.Linq;

namespace PotterDiscount.Discounts
{
    public class Discounter
    {
        private readonly IEnumerable<IDiscount> _discounters;

        public Discounter(IEnumerable<IDiscount> discounters)
        {
            _discounters = discounters;
        }

        public decimal Apply(IEnumerable<Book> books)
        {

            var booksToDiscount = books.ToList();

            var uniqueBooks = new UniqueBooks(booksToDiscount);

            var noOfUniqueBooks = uniqueBooks.Count();
            
            return Calculate(noOfUniqueBooks, booksToDiscount);
        }

        private decimal Calculate(int noOfUniqueBooks, List<Book> booksToDiscount)
        {
            var discounter = _discounters.First(d => d.ForNoBooks == noOfUniqueBooks);

            return discounter.Calculate(booksToDiscount);
        }
    }
}