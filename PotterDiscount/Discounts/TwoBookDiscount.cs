using System.Collections.Generic;
using System.Linq;

namespace PotterDiscount.Discounts
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
            decimal total = books.Sum(book => book.BookPrice);

            decimal disount = (total / 100) * 5;

            return total - disount;
        }
    }
}