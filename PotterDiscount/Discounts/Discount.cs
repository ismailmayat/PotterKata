using System.Collections.Generic;
using System.Linq;

namespace PotterDiscount.Discounts
{
    public abstract class Discount
    {
        protected decimal Percentage;

        protected Discount(decimal percentage)
        {
            Percentage = percentage;
        }

        protected decimal Calculate(IEnumerable<Book> books)
        {
            decimal total = books.Sum(book => book.BookPrice);

            decimal disount = (total / 100) * Percentage;

            return total - disount;    
        }
    }
}