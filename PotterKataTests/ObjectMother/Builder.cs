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
            
            IDiscount twoBookDiscount = new BookDiscount(2,5);
            
            IDiscount threeBookDiscount = new BookDiscount(3,10);
            
            IDiscount fourBookDiscount = new BookDiscount(4,20);
            
            IDiscount fiveBookDiscount = new BookDiscount(5,25);
            
            IEnumerable<IDiscount> discounts = new List<IDiscount>{oneBookDiscount,twoBookDiscount,threeBookDiscount,fourBookDiscount,fiveBookDiscount};
            
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

        public static IEnumerable<Book> FourUniqueBooks(decimal oneBookPrice)
        {
            var threeUniqueBooks = ThreeUniqueBooks(oneBookPrice);
            
            var books = new List<Book> {new Book(oneBookPrice, "978-1408855683")};
            
            books.AddRange(threeUniqueBooks);

            return books;
        }

        public static IEnumerable<Book> FiveUniqueBooks(decimal oneBookPrice)
        {
            var fourUniqueBooks = FourUniqueBooks(oneBookPrice);
            
            var books = new List<Book> {new Book(oneBookPrice, "978-1408855690")};
            
            books.AddRange(fourUniqueBooks);

            return books;
        }
    }
}