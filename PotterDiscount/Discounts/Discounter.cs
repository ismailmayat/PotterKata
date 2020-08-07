using System.Collections.Generic;
using System.Linq;

namespace PotterDiscount.Discounts
{
    public class Discounter
    {
        private readonly IEnumerable<IDiscount> _discounters;
        private readonly decimal _fullPrice;

        public Discounter(IEnumerable<IDiscount> discounters,decimal fullPrice)
        {
            _discounters = discounters;
            _fullPrice = fullPrice;
        }

        public decimal Apply(IEnumerable<Book> books)
        {

            var booksToDiscount = books.ToList();

            var uniqueBooks = new BookBasket(booksToDiscount);

            bool hasDuplicates = uniqueBooks.HasDuplicates();
            
            var noOfUniqueBooks = uniqueBooks.Count();


            if (booksToDiscount.Distinct().Count() == 1)
            {
                return booksToDiscount.Count() *_fullPrice;
            }

            if (hasDuplicates)
            {
              //figure out how many then charge full price for those
              
              //figure out split of sets that u have
              
            }

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