using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    /// <summary>
    /// Once upon a time there was a series of 5 books about a very English hero called Harry. 
    /// (At least when this Kata was invented, there were only 5. Since then they have multiplied) 
    /// Children all over the world thought he was fantastic, and, of course, so did the publisher. 
    /// So in a gesture of immense generosity to mankind, (and to increase sales) 
    /// they set up the following pricing model to take advantage of Harry's magical powers.
    /// </summary>
    public class PotterBasket
    {
        private readonly List<string> _books = new List<string>();

        public decimal Total
        {
            get
            {
                return GetBestPriceFor(_books);
            }
        }

        private decimal GetBestPriceFor(List<string> books)
        {
            int distinct = books.Distinct().Count();
            if (distinct == 1)
            {
                return 8m * books.Count;
            }
            if (distinct == 2)
            {
                string first = books[0];
                string second = books.First(x => x != first);

                books.Remove(first);
                books.Remove(second);

                if (books.Count == 0)
                    return 8M * 2 * 0.95M;

                return 8M * 2 * 0.95M + GetBestPriceFor(books);
            }
            if (distinct == 3)
            {
                string first = books[0];
                string second = books.First(x => x != first);
                string third = books.First(x => x != first && x != second);

                books.Remove(first);
                books.Remove(second);
                books.Remove(third);

                if (books.Count == 0)
                    return 8M * 3 * 0.9M;

                return 8M * 3 * 0.9M + GetBestPriceFor(books);
            }
            if (distinct == 4)
            {
                string first = books[0];
                string second = books.First(x => x != first);
                string third = books.First(x => x != first && x != second);
                string fourth = books.First(x => x != first && x != second && x != third);

                books.Remove(first);
                books.Remove(second);
                books.Remove(third);
                books.Remove(fourth);

                if (books.Count == 0)
                    return 8M * 4 * 0.8M;

                return 8M * 4 * 0.8M + GetBestPriceFor(books);
            }

            var booksLeftWhenTakingFive = new List<string>(books);
            foreach (string book in books.Distinct())
            {
                booksLeftWhenTakingFive.Remove(book);
            }

            
            if (booksLeftWhenTakingFive.Count > 0)
            {
                var booksLeftWhenTakingFiveCopy = new List<string>(booksLeftWhenTakingFive);
                return books
                    .Distinct()
                    .Select(bookToKeep => new List<string>(booksLeftWhenTakingFiveCopy) { bookToKeep })
                    .Select(altBooks3 => GetBestPriceFor(altBooks3) + 8M*4*0.8M)
                    .Concat(new[] { 8M * 5 * 0.75M + GetBestPriceFor(booksLeftWhenTakingFive) }).Min();
            }

            return 8M * 5 * 0.75M;
        }


        public void Add(string book)
        {
            _books.Add(book);
        }
    }
}