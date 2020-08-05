using System.Collections.Generic;

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
            decimal total=0;

            //how to determine we have different types and 
            
            foreach (var book in books)
            {
                total += book.BookPrice;
            }

            return total;
        }
    }
}