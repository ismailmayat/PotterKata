using System.Collections.Generic;

namespace PotterDiscount
{
    public class BookSetBuilder
    {
        private readonly int _setCount;

        public BookSetBuilder(int setCount)
        {
            _setCount = setCount;
        }

        public Dictionary<int, List<Book>> Build(List<Book> books)
        {
            var set = BuildSetBuilder(books.Count);
                
            BuildSet(books, set.Count, set);

            return set;
        }

        private void BuildSet(List<Book> booksToDiscount, int setCount, Dictionary<int, List<Book>> set)
        {
            //create the unique sets

            //todo u need to then remove stuff from the original list
            foreach (var book in booksToDiscount)
            {
                for (int i = 0; i < setCount; i++)
                {
                    if (!set[i].Contains(book))
                    {
                        set[i].Add(book);
                        break;
                    }
                }
            }
        }

        private Dictionary<int, List<Book>> BuildSetBuilder(int booksToDiscount)
        {
            int setCount = 0;
            if (booksToDiscount % 5 == 0)
            {
                setCount = (booksToDiscount / 5);
            }
            else
            {
                setCount = (booksToDiscount / 5) + 1;
            }

            var multiSet = new Dictionary<int, List<Book>>();

            for (int i = 0; i < setCount; i++)
            {
                multiSet.Add(i, new List<Book>(_setCount));
            }

            return multiSet;
        }
    }
}