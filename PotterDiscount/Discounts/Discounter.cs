using System.Collections.Generic;
using System.Linq;
using PotterDiscount;
using PotterDiscount.Discounts;

namespace PotterKataTests
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
            
            if (booksToDiscount.Count() == 1)
            {
                var discounter = _discounters.First(d => d.ForNoBooks == 1);

                return discounter.Calculate(booksToDiscount);
            }

            if (TwoDifferentBooks(booksToDiscount))
            {
                var discounter = _discounters.First(d => d.ForNoBooks == 2);
                return discounter.Calculate(booksToDiscount);
            }

            return 0;
        }

        private bool TwoDifferentBooks(IEnumerable<Book> books)
        {
            if (books.Count() == 2 && books.First().Isbn != books.Last().Isbn)
            {
                return true;
            }

            return false;
        }
    }
}