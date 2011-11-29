using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace Kata.Tests
{
    /// <summary>
    /// See: http://codingdojo.org/cgi-bin/wiki.pl?KataPotter
    /// </summary>
    [TestFixture]
    public class PotterBasketTests
    {
        [Test]
        [TestCase("Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Chamber of Secrets")]
        [TestCase("Harry Potter and the Prisoner of Azkaban")]
        [TestCase("Harry Potter and the Goblet of Fire")]
        [TestCase("Harry Potter and the Order of the Phoenix")]
        public void OneCopyOfAnyOfTheFiveBooksCosts8Eur(string book)
        {
            var basket = SetupBasket();

            basket.Add(book);

            Assert.AreEqual(8M, basket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Goblet of Fire", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyTwoDifferentBooksYouGetA5PercentDiscountOnThoseTwoBooks(string book1, string book2)
        {
            var basket = SetupBasket();

            basket.Add(book1);
            basket.Add(book2);

            Assert.AreEqual(8M * 2 * 0.95M, basket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Chamber of Secrets")]
        [TestCase("Harry Potter and the Prisoner of Azkaban")]
        [TestCase("Harry Potter and the Goblet of Fire")]
        [TestCase("Harry Potter and the Order of the Phoenix")]
        public void TwoCopiesOfTheSameBookCosts16Eur(string book)
        {
            var basket = SetupBasket();

            basket.Add(book);
            basket.Add(book);

            Assert.AreEqual(16M, basket.Total);
        }


        [Test]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Goblet of Fire", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyTwoDifferentBooksYouGetA5PercentDiscountOnThoseTwoBooksOnly(string book1, string book2)
        {
            var basket = SetupBasket();

            basket.Add(book1);
            basket.Add(book2);
            basket.Add(book1);

            Assert.AreEqual(8M * 2 * 0.95M + 8M, basket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Goblet of Fire", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyTwoCopiesOfTwoDifferentBooksYouGetA5PercentDiscountOnThoseTwoBooksTwice(string book1, string book2)
        {
            var basket = SetupBasket();

            basket.Add(book1);
            basket.Add(book2);
            basket.Add(book2);
            basket.Add(book1);

            Assert.AreEqual(8M * 4 * 0.95M, basket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Goblet of Fire", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyThreeDifferentBooksYouGetA10PercentDiscountOnThoseThreeBooks(string book1, string book2, string book3)
        {
            var basket = SetupBasket();

            basket.Add(book1);
            basket.Add(book2);
            basket.Add(book3);

            Assert.AreEqual(8M * 3 * 0.9M, basket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Chamber of Secrets", "Harry Potter and the Goblet of Fire", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Chamber of Secrets", "Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void With4DifferentBooksYouGetA20PercentDiscount(string book1, string book2, string book3, string book4)
        {
            var basket = SetupBasket();

            basket.Add(book1);
            basket.Add(book2);
            basket.Add(book3);
            basket.Add(book4);

            Assert.AreEqual(8M * 4 * 0.8M, basket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Chamber of Secrets", "Harry Potter and the Goblet of Fire", "Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyAll5YouGetAHuge25PercentDiscount(string book1, string book2, string book3, string book4, string book5)
        {
            var basket = SetupBasket();

            basket.Add(book1);
            basket.Add(book2);
            basket.Add(book3);
            basket.Add(book4);
            basket.Add(book5);

            Assert.AreEqual(8M * 5 * 0.75M, basket.Total);
        }

        private PotterBasket SetupBasket()
        {
            var basket = new PotterBasket();
            return basket;
        }
    }


}
