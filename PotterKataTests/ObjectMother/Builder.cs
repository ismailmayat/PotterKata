using System.Collections.Generic;
using PotterDiscount;
using PotterDiscount.Discounts;

namespace PotterKataTests.ObjectMother
{
    public static class Builder
    {

        public static Discounter Discounter()
        {
           
            
            IDiscount twoBookDiscount = new BookDiscount(2,5);
            
            IDiscount threeBookDiscount = new BookDiscount(3,10);
            
            IDiscount fourBookDiscount = new BookDiscount(4,20);
            
            IDiscount fiveBookDiscount = new BookDiscount(5,25);
            
            IEnumerable<IDiscount> discounts = new List<IDiscount>{twoBookDiscount,threeBookDiscount,fourBookDiscount,fiveBookDiscount};
            
            var discounter = new Discounter(discounts,8M);

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

        public static IEnumerable<Book> ThreeUniqueBooksOneDuplicate(decimal oneBookPrice)
        {
           var threeUnique =  ThreeUniqueBooks(oneBookPrice);

           //add in chamber of secrets which means its duplicate
           var books = new List<Book> {new Book(oneBookPrice, "978-1408855669")};
           
           books.AddRange(threeUnique);

           return books;
        }

        public static IEnumerable<Book> SameBook(int numberOfBooks,decimal oneBookPrice)
        {
            var books = new List<Book>();

            for (int i = 0; i < numberOfBooks; i++)
            {
                books.Add(new Book(oneBookPrice,"12345"));
            }

            return books;
        }

        public static IEnumerable<Book> Two_Two_Two_One_One(decimal oneBookPrice)
        {
            var books = new List<Book> {new Book(oneBookPrice, "1"),
                                        new Book(oneBookPrice, "1"),
                                        new Book(oneBookPrice, "2"),
                                        new Book(oneBookPrice, "2"),
                                        new Book(oneBookPrice, "3"),
                                        new Book(oneBookPrice, "3"),
                                        new Book(oneBookPrice, "4"),
                                        new Book(oneBookPrice, "5")
                                        
            };

            return books;
        }
    }
}