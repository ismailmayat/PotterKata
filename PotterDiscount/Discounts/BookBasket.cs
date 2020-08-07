using System.Collections.Generic;
using System.Linq;

namespace PotterDiscount.Discounts
{
    public class BookBasket
    {
        private readonly IEnumerable<Book> _books;

        public BookBasket(IEnumerable<Book> books)
        {
            _books = books;
        }

        public int Count()
        {
            var hashset = new HashSet<string>();

            return _books.Count(book => hashset.Add(book.Isbn));
        }

        public bool HasDuplicates()
        {
            var hashset = new HashSet<string>();
            return _books.Any(e => !hashset.Add(e.Isbn));
        }
    }
}