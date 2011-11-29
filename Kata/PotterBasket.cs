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
        private readonly Dictionary<string, int> _cart = new Dictionary<string, int>();

        public decimal Total
        {
            get
            {
                var books = new List<string>();
                foreach (string book in _cart.Keys)
                {
                    for (int i=0; i<_cart[book]; i++)
                        books.Add(book);
                }
                return GetBestPriceFor(books);
            }
        }

        private decimal GetBestPriceFor(List<string> books)
        {
            int distinct = books.Distinct().Count();
            if (distinct == 1)
            {
                return 8m*books.Count;
            }
            if (distinct == 2)
            {
                string first = books[0];
                string second = books.First(x => x != first);

                books.Remove(first);
                books.Remove(second);

                if (books.Count == 0)
                    return 8M*2*0.95M;

                return 8M*2*0.95M + GetBestPriceFor(books);
            }
            if (distinct == 3)
            {
                string first = books[0];
                string second = books.First(x => x != first);
                string third = books.First(x => x != first && x!= second);

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

            var altBooks1 = new List<string>(books);

            foreach (string book in books.Distinct())
            {
                altBooks1.Remove(book);
            }
            decimal bestPrice = 8M*5*0.75M;
            if (altBooks1.Count>0)
                bestPrice += GetBestPriceFor(altBooks1);

            foreach (string bookToKeep in books.Distinct())
            {
                var altBooks2 = new List<string>(books.ToArray());
                foreach (string bookToRemove in books.Distinct())
                {
                    if (bookToRemove!=bookToKeep)
                        altBooks2.Remove(bookToRemove);
                }
                var testPrice = GetBestPriceFor(altBooks2) + 8M*4*0.8M;
                if (testPrice < bestPrice)
                    bestPrice = testPrice;
            }

            return bestPrice;


        }

        private void TakeDifferent(int howMany)
        {
            var books = BooksInCart;
            for (int i = 0; i < howMany; i++)
            {
                Remove(books[i]);
            }
        }


        private string[] BooksInCart
        {
            get
            {
                var keys = new string[_cart.Count];
                _cart.Keys.CopyTo(keys, 0);
                return keys;
            }
        }

        private void Remove(string book)
        {
            _cart[book]--;
            if (_cart[book] == 0)
                _cart.Remove(book);
        }

        public void Add(string book)
        {
            if (_cart.ContainsKey(book))
                _cart[book]++;
            else
                _cart[book] = 1;
        }
    }
}