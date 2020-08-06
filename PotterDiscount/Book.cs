using System;

namespace PotterDiscount
{
    public class Book:IEquatable<Book>
    {

        //todo bookprice and isbn showing primitive obsession should use specific types like Money or Isbn which encapsulates rules
        
        public decimal BookPrice { get; }
        
        public string Isbn { get; }
        
        public Book(decimal bookPrice, string isbn)
        {
            BookPrice = bookPrice;
            Isbn = isbn;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Isbn == other.Isbn;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book) obj);
        }

        public override int GetHashCode()
        {
            return (Isbn != null ? Isbn.GetHashCode() : 0);
        }
    }
}