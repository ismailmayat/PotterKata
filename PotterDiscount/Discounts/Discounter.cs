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

            bool hasDuplicates = uniqueBooks.HasDuplicates();
            
            var noOfUniqueBooks = uniqueBooks.Count();
            
            return Calculate(noOfUniqueBooks, hasDuplicates,booksToDiscount);
        }

        private decimal Calculate(int noOfUniqueBooks,bool hasDuplicates, List<Book> booksToDiscount)
        {
            //does a look up to get us the correct discount calculator
            var discounter = _discounters.First(d => d.ForNoBooks == noOfUniqueBooks && d.ForDuplicates == hasDuplicates);

            return discounter.Calculate(booksToDiscount);
        }
    }
}