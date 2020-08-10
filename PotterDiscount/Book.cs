using System;
using TechDebtAttributes;

namespace PotterDiscount
{
    public class Book:IEquatable<Book>
    {

        
        [TechDebt(10,50,Description = "Primitive obsession ideally need money type")]
        public decimal BookPrice { get; }
        
        [TechDebt(10,50,Description = "Primitive obsession ideally need isbn type")]
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