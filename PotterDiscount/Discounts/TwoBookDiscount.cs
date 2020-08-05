using System.Collections.Generic;
using System.Linq;

namespace PotterDiscount.Discounts
{
    public class TwoBookDiscount:Discount, IDiscount
    {
        private readonly int _noBooks;

        public TwoBookDiscount(int noBooks,decimal discountPercentage):base(discountPercentage)
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