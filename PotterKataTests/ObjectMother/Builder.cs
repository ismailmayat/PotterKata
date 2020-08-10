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
            
            var discounter = new Discounter(discounts,8M,5);

            return discounter;
        }

        public static BookBasket OneUniqueBook(decimal price)
        {
            var book = new Book(price,"978-1408855652");
            
            IEnumerable<Book> books = new List<Book>{book};

            return  new BookBasket(books);
        }

        public static BookBasket TwoUniqueBooks(decimal price)
        {
            var philosophersStone = new Book(price,"978-1408855652");
            
            var chamberOfSecrets = new Book(price,"978-1408855669");
            
            IEnumerable<Book> books = new List<Book>{philosophersStone,chamberOfSecrets};

            return new BookBasket(books);

        }

        public static BookBasket ThreeUniqueBooks(decimal oneBookPrice)
        {
            var twoUniqueBooks = TwoUniqueBooks(oneBookPrice).Books;

            var books = new List<Book> {new Book(oneBookPrice, "978-1408855676")};
            
            books.AddRange(twoUniqueBooks);

            return new BookBasket(books);
        }

        public static BookBasket FourUniqueBooks(decimal oneBookPrice)
        {
            var threeUniqueBooks = ThreeUniqueBooks(oneBookPrice).Books;
            
            var books = new List<Book> {new Book(oneBookPrice, "978-1408855683")};
            
            books.AddRange(threeUniqueBooks);

            return new BookBasket(books);
        }

        public static BookBasket FiveUniqueBooks(decimal oneBookPrice)
        {
            var fourUniqueBooks = FourUniqueBooks(oneBookPrice).Books;
            
            var books = new List<Book> {new Book(oneBookPrice, "978-1408855690")};
            
            books.AddRange(fourUniqueBooks);

            return new BookBasket(books);
        }

        public static BookBasket ThreeUniqueBooksOneDuplicate(decimal oneBookPrice)
        {
           var threeUnique =  ThreeUniqueBooks(oneBookPrice).Books;

           //add in chamber of secrets which means its duplicate
           var books = new List<Book> {new Book(oneBookPrice, "978-1408855669")};
           
           books.AddRange(threeUnique);

           return new BookBasket(books);
        }

        public static BookBasket SameBook(int numberOfBooks,decimal oneBookPrice)
        {
            var books = new List<Book>();

            for (int i = 0; i < numberOfBooks; i++)
            {
                books.Add(new Book(oneBookPrice,"12345"));
            }

            return new BookBasket(books);
        }

        public static BookBasket Two_Two_Two_One_One(decimal oneBookPrice)
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

            return new BookBasket(books);
        }

        public static IEnumerable<Book> OneThousandBooks(decimal oneBookPrice)
        {
            List<Book> books = new List<Book>();
            
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    books.Add(new Book(oneBookPrice,i.ToString()+j.ToString()));
                }
            }

            return books;
        }
    }
}