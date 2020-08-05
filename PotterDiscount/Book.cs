namespace PotterDiscount
{
    public class Book
    {

        //todo bookprice and isbn showing primitive obsession should use specific types like Money or Isbn which encapsulates rules
        
        public decimal BookPrice { get; }
        
        public string Isbn { get; }
        
        public Book(decimal bookPrice, string isbn)
        {
            BookPrice = bookPrice;
            Isbn = isbn;
        }
        
    }
}