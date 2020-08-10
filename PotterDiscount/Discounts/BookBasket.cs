using System.Collections.Generic;
using System.Linq;
using TechDebtAttributes;

namespace PotterDiscount.Discounts
{

    [TechDebt(10,100,Description = "Keep running count of sets while adding books to basket, then we can return sets rather than calculating")]
    public class BookBasket
    {
        private readonly IEnumerable<Book> _books;

        public BookBasket(IEnumerable<Book> books)
        {
            _books = books;
        }
        
        public IEnumerable<Book> Books => _books;
        
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