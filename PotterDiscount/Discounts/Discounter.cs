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
            
            if (noOfUniqueBooks == 1)
            {
                var discounter = _discounters.First(d => d.ForNoBooks == 1);

                return discounter.Calculate(booksToDiscount);
            }

            if (noOfUniqueBooks==2)
            {
                var discounter = _discounters.First(d => d.ForNoBooks == 2);
                return discounter.Calculate(booksToDiscount);
            }

            return 0;
        }

     
        
    }
}