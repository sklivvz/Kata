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
                    var first = PopFirstElement();
                    var second = FindDifferent(first);

                    if (second != string.Empty)
                    {
                        Remove(second);

                        var third = FindDifferent(first, second);
                        if (third != string.Empty)
                        {
                            Remove(third);
                            ret += 8M*3*0.9M;
                        }
                        else
                        {
                            ret += 8M*2*0.95M;
                        }
                    }
                    else
                    {
                        ret += 8M;
                    }
                }
                return ret;
            }
        }

        private string FindDifferent(string book1, string book2)
        {
            string next = string.Empty;

            foreach (string key in _cart.Keys)
            {
                if (key == book1) continue;
                if (key == book2) continue;
                next = key;
                break;
            }
            return next;
        }

        private string FindDifferent(string book)
        {
            string next = string.Empty;

            foreach (string key in _cart.Keys)
            {
                if (key == book) continue;
                next = key;
                break;
            }
            return next;
        }

        private string[] BooksInCart()
        {
            var keys = new string[_cart.Count];
            _cart.Keys.CopyTo(keys, 0);
            return keys;
        }

        private string PopFirstElement()
        {
            string firstElement = BooksInCart()[0];

            Remove(firstElement);

            return firstElement;
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