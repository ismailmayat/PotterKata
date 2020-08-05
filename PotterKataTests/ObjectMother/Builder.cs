using System.Collections.Generic;
using PotterDiscount;
using PotterDiscount.Discounts;

namespace PotterKataTests.ObjectMother
{
    public static class Builder
    {
        public static Discounter Discounter()
        {
            IDiscount oneBookDiscount = new OneBookDiscount(1);
            
            IDiscount twoBookDiscount = new TwoBookDiscount(2,5);
            
            IEnumerable<IDiscount> discounts = new List<IDiscount>{oneBookDiscount,twoBookDiscount};
            
            var discounter = new Discounter(discounts);

            return discounter;
        }

        public static IEnumerable<Book> OneUniqueBook(decimal price)
        {
            var book = new Book(price,"978-1408855652");
            
            IEnumerable<Book> books = new List<Book>{book};

            return books;
        }

        public static IEnumerable<Book> TwoUniqueBooks(decimal price)
        {
            var philosophersStone = new Book(price,"978-1408855652");
            
            var chamberOfSecrets = new Book(price,"978-1408855669");
            
            IEnumerable<Book> books = new List<Book>{philosophersStone,chamberOfSecrets};

            return books;

        }

        public static IEnumerable<Book> ThreeUniqueBooks(decimal oneBookPrice)
        {
            var twoUniqueBooks = TwoUniqueBooks(oneBookPrice);

            var books = new List<Book> {new Book(oneBookPrice, "978-1408855676")};
            
            books.AddRange(twoUniqueBooks);

            return books;
        }

    }
}