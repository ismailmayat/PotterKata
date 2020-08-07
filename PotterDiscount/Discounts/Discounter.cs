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
                var set= BuildSetHolder(booksToDiscount.Count());
               
                int setCount = set.Count;
                
                BuildSet(booksToDiscount, setCount, set);

                decimal total=0M;

                foreach (var item in set.Keys)
                {
                    total += Calculate(set[item].Count, false, set[item]);
                }

                return total;
                //over the 2 sets get the totals then compare with actual and do subtraction that gives u the same ones if any
            }

            var noOfUniqueBooks = bookBasket.Books.Count();
            
            return Calculate(noOfUniqueBooks, hasDuplicates,booksToDiscount);
        }

        private static void BuildSet(List<Book> booksToDiscount, int setCount, Dictionary<int, List<Book>> set)
        {
            //create the unique sets

            //todo u need to then remove stuff from the original list
            foreach (var book in booksToDiscount)
            {
                for (int i = 0; i < setCount; i++)
                {
                    if (!set[i].Contains(book))
                    {
                        set[i].Add(book);
                        break;
                    }
                }
            }
        }

        private Dictionary<int, List<Book>> BuildSetHolder(int booksToDiscount)
        {
            int setCount = 0;
            if (booksToDiscount % 5 == 0)
            {
                setCount = (booksToDiscount / 5);
            }
            else
            {
                setCount = (booksToDiscount / 5) + 1;
            }

            var multiSet = new Dictionary<int, List<Book>>();

            for (int i = 0; i < setCount; i++)
            {
                multiSet.Add(i, new List<Book>(_setCount));
            }

            return multiSet;
        }

        private decimal Calculate(int noOfUniqueBooks,bool hasDuplicates, IEnumerable<Book> booksToDiscount)
        {
            //does a look up to get us the correct discount calculator
            var discounter = _discounters.First(d => d.ForNoBooks == noOfUniqueBooks && d.ForDuplicates == hasDuplicates);

            return discounter.Calculate(booksToDiscount);
        }
    }
}