using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Discounts
{
    public class BookDiscount:Discount, IDiscount
    {
        public BookDiscount(int noBooks,decimal discountPercentage):base(discountPercentage)
        {
            ForNoBooks = noBooks;
        }

        public int ForNoBooks { get; }

        public new decimal Calculate(IEnumerable<Book> books)
        {
            return base.Calculate(books);
        }
    }
}