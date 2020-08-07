using System.Collections.Generic;
using System.Linq;

namespace PotterDiscount.Discounts
{
    public class Discounter
    {
        private readonly IEnumerable<IDiscount> _discounters;
        private readonly decimal _fullPrice;
        
        /// <summary>
        /// how many books in the set
        /// </summary>
        private readonly int _setCount;

        public Discounter(IEnumerable<IDiscount> discounters,decimal fullPrice,int setCount)
        {
            _discounters = discounters;
            _fullPrice = fullPrice;
            _setCount = setCount;
        }

        public decimal Apply(BookBasket bookBasket)
        {
            var booksToDiscount = bookBasket.Books.ToList();

            if (bookBasket.AllSame())
            {
                //todo move this into own class
                return booksToDiscount.Count() *_fullPrice;
            }
            
            bool hasDuplicates = bookBasket.HasDuplicates();
           
            if (hasDuplicates)
            {
                var bookSetBuilder = new BookSetBuilder(_setCount);

                var set = bookSetBuilder.Build(booksToDiscount);

                decimal total = 0M;

                int setCount = 0;

                foreach (var item in set.Keys)
                {
                    total += Calculate(set[item].Count, false, set[item]);
                    setCount += set[item].Count;
                }

                //we have some single books not part of set
                if (booksToDiscount.Count() > setCount)
                {
                    total += (booksToDiscount.Count - setCount) * _fullPrice;
                }

                return total;
                //over the 2 sets get the totals then compare with actual and do subtraction that gives u the same ones if any
            }

            var noOfUniqueBooks = bookBasket.Books.Count();
            
            return Calculate(noOfUniqueBooks, hasDuplicates,booksToDiscount);
        }

        private decimal Calculate(int noOfUniqueBooks,bool hasDuplicates, IEnumerable<Book> booksToDiscount)
        {
            //does a look up to get us the correct discount calculator
            var discounter = _discounters.First(d => d.ForNoBooks == noOfUniqueBooks && d.ForDuplicates == hasDuplicates);

            return discounter.Calculate(booksToDiscount);
        }
    }
}