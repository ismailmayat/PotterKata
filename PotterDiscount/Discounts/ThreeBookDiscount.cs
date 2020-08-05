using System.Collections.Generic;

namespace PotterDiscount.Discounts
{
    public class ThreeBookDiscount:Discount,IDiscount
    {
        public ThreeBookDiscount(decimal percentage) : base(percentage)
        {
        }

        public int ForNoBooks => 3;

        public new decimal Calculate(IEnumerable<Book> books)
        {
            return base.Calculate(books);
        }
    }
}