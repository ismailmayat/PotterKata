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

        public IEnumerable<Book> Books => _books;

        public int Count()
        {
            var hashset = new HashSet<string>();

            return Books.Count(book => hashset.Add(book.Isbn));
        }

        public bool HasDuplicates()
        {
            var hashset = new HashSet<string>();
            return Books.Any(e => !hashset.Add(e.Isbn));
        }

        public bool AllSame()
        {
            return _books.Distinct().Count() == 1;
        }
    }
}