using System.Collections.Generic;

namespace PotterDiscount.Discounts
{
    public interface IDiscount
    {
        int ForNoBooks { get;}
        
        bool ForDuplicates { get; }
        
        decimal Calculate(IEnumerable<Book> books);
    }
}