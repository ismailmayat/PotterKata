using System.Collections.Generic;
using System.Linq;

namespace PotterDiscount.Discounts
{
    public class BookDiscount:Discount, IDiscount
    {
        private readonly int _noBooks;

        public BookDiscount(int noBooks,decimal discountPercentage):base(discountPercentage)
        {
            _noBooks = noBooks;
        }

        public int ForNoBooks => _noBooks;

        public new decimal Calculate(IEnumerable<Book> books)
        {
            return base.Calculate(books);
        }
    }
}