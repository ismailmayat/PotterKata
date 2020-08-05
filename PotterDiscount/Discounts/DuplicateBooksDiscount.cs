using System.Collections.Generic;

namespace PotterDiscount.Discounts
{
    public class DuplicateBooksDiscount:Discount, IDiscount
    {
        public DuplicateBooksDiscount(decimal percentage, int noBooks) : base(percentage)
        {
            ForNoBooks = noBooks;
        }

        public int ForNoBooks { get; }

        public bool ForDuplicates => true;

        public decimal Calculate(IEnumerable<Book> books)
        {
            
            throw new System.NotImplementedException();
        }
    }
}