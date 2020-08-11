using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Discounts
{
    public abstract class Discount
    {
        private readonly decimal _percentage;

        protected Discount(decimal percentage)
        {
            _percentage = percentage;
        }

        protected decimal Calculate(IEnumerable<Book> books)
        {
            decimal total = books.Sum(book => book.BookPrice);

            decimal discount = (total / 100) * _percentage;

            return total - discount;    
        }
    }
}