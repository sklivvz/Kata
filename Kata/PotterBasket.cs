using System.Collections.Generic;

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
                decimal ret = 0M;
                while (_cart.Count > 0)
                {
                    if (_cart.Count == 5)
                    {
                        TakeDifferent(5);
                        ret += 8M * 5 * 0.75M;
                    }
                    else if (_cart.Count == 4)
                    {
                        TakeDifferent(4);
                        ret += 8M * 4 * 0.8M;
                    }
                    else if (_cart.Count == 3)
                    {
                        TakeDifferent(3);
                        ret += 8M*3*0.9M;
                    }
                    else if (_cart.Count == 2)
                    {
                        TakeDifferent(2);
                        ret += 8M * 2 * 0.95M;
                    }
                    else
                    {
                        TakeDifferent(1);
                        ret += 8M;
                    }
                }
                return ret;
            }
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