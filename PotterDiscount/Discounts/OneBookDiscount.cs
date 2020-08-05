using System.Collections.Generic;
using System.Linq;

namespace PotterDiscount.Discounts
{
    public class OneBookDiscount:IDiscount
    {
        public OneBookDiscount(int forNoOfBooks)
        {
            ForNoBooks = forNoOfBooks;
        }

        public int ForNoBooks { get; }

        public decimal Calculate(IEnumerable<Book> books)
        {
            return books.Sum(book => book.BookPrice);
        }
    }
}