using System.Collections.Generic;
using PotterDiscount;
using PotterDiscount.Discounts;

namespace PotterKataTests
{
    public class TwoBookDiscount:IDiscount
    {
        private readonly int _noBooks;

        public TwoBookDiscount(int noBooks)
        {
            _noBooks = noBooks;
        }

        public int ForNoBooks => _noBooks;

        public decimal Calculate(IEnumerable<Book> books)
        {
            return 0;
        }
    }
}