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
            if (books.Count() == 1)
            {
                return books.First().BookPrice;
            }

            return 0;
        }
    }
}