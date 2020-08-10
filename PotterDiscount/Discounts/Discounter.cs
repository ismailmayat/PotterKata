using System;
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
            _discounters = discounters ?? throw new ArgumentNullException(nameof(discounters));
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
                    total += Calculate(set[item].Count, set[item]);
                    setCount += set[item].Count;
                }
                
                if (IncompleteSet(booksToDiscount, setCount))
                {
                    total += (booksToDiscount.Count - setCount) * _fullPrice;
                }

                return total;

            }

            var noOfUniqueBooks = bookBasket.Books.Count();
            
            return Calculate(noOfUniqueBooks, booksToDiscount);
        }

        private static bool IncompleteSet(List<Book> booksToDiscount, int setCount)
        {
            return booksToDiscount.Count > setCount;
        }

        private decimal Calculate(int noOfUniqueBooks,IEnumerable<Book> booksToDiscount)
        {
            //does a look up to get us the correct discount calculator
            var discounter = _discounters.First(d => d.ForNoBooks == noOfUniqueBooks );

            return discounter.Calculate(booksToDiscount);
        }
    }
}