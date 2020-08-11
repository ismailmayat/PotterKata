using System.Collections.Generic;

namespace PotterKata.Discounts
{
    public interface IDiscount
    {
        int ForNoBooks { get;}
        decimal Calculate(IEnumerable<Book> books);
    }
}