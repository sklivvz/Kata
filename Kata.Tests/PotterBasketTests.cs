using NUnit.Framework;

namespace Kata.Tests
{
    /// <summary>
    /// See: http://codingdojo.org/cgi-bin/wiki.pl?KataPotter
    /// </summary>
    [TestFixture]
    public class PotterBasketTests
    {
        private PotterBasket _potterBasket;

        [SetUp]
        protected void SetUp()
        {
            _potterBasket = new PotterBasket();
        }

        [Test]
        public void HowMuchDoesThisBasketOfBooksCost()
        {
            _potterBasket.Add("Harry Potter and the Philosopher's Stone");
            _potterBasket.Add("Harry Potter and the Philosopher's Stone");
            _potterBasket.Add("Harry Potter and the Chamber of Secrets");
            _potterBasket.Add("Harry Potter and the Chamber of Secrets");
            _potterBasket.Add("Harry Potter and the Prisoner of Azkaban");
            _potterBasket.Add("Harry Potter and the Prisoner of Azkaban");
            _potterBasket.Add("Harry Potter and the Goblet of Fire");
            _potterBasket.Add("Harry Potter and the Order of the Phoenix");

            Assert.AreEqual(51.20M, _potterBasket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Chamber of Secrets",
            "Harry Potter and the Goblet of Fire", "Harry Potter and the Order of the Phoenix",
            "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyAll5YouGetAHuge25PercentDiscount(string book1, string book2, string book3, string book4,
                                                             string book5)
        {
            _potterBasket.Add(book1);
            _potterBasket.Add(book2);
            _potterBasket.Add(book3);
            _potterBasket.Add(book4);
            _potterBasket.Add(book5);

            Assert.AreEqual(8M * 5 * 0.75M, _potterBasket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Prisoner of Azkaban",
            "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Goblet of Fire",
            "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Order of the Phoenix",
            "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyThreeDifferentBooksYouGetA10PercentDiscountOnThoseThreeBooks(string book1, string book2,
                                                                                         string book3)
        {
            _potterBasket.Add(book1);
            _potterBasket.Add(book2);
            _potterBasket.Add(book3);

            Assert.AreEqual(8M * 3 * 0.9M, _potterBasket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Goblet of Fire", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyTwoCopiesOfTwoDifferentBooksYouGetA5PercentDiscountOnThoseTwoBooksTwice(string book1,
                                                                                                    string book2)
        {
            _potterBasket.Add(book1);
            _potterBasket.Add(book2);
            _potterBasket.Add(book2);
            _potterBasket.Add(book1);

            Assert.AreEqual(8M * 4 * 0.95M, _potterBasket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Goblet of Fire", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyTwoDifferentBooksYouGetA5PercentDiscountOnThoseTwoBooks(string book1, string book2)
        {
            _potterBasket.Add(book1);
            _potterBasket.Add(book2);

            Assert.AreEqual(8M * 2 * 0.95M, _potterBasket.Total);
        }


        [Test]
        [TestCase("Harry Potter and the Chamber of Secrets", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Goblet of Fire", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void IfYouBuyTwoDifferentBooksYouGetA5PercentDiscountOnThoseTwoBooksOnly(string book1, string book2)
        {
            _potterBasket.Add(book1);
            _potterBasket.Add(book2);
            _potterBasket.Add(book1);

            Assert.AreEqual(8M * 2 * 0.95M + 8M, _potterBasket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Chamber of Secrets")]
        [TestCase("Harry Potter and the Prisoner of Azkaban")]
        [TestCase("Harry Potter and the Goblet of Fire")]
        [TestCase("Harry Potter and the Order of the Phoenix")]
        public void OneCopyOfAnyOfTheFiveBooksCosts8Eur(string book)
        {
            _potterBasket.Add(book);

            Assert.AreEqual(8M, _potterBasket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Chamber of Secrets")]
        [TestCase("Harry Potter and the Prisoner of Azkaban")]
        [TestCase("Harry Potter and the Goblet of Fire")]
        [TestCase("Harry Potter and the Order of the Phoenix")]
        public void TwoCopiesOfTheSameBookCosts16Eur(string book)
        {
            _potterBasket.Add(book);
            _potterBasket.Add(book);

            Assert.AreEqual(16M, _potterBasket.Total);
        }

        [Test]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Chamber of Secrets",
            "Harry Potter and the Goblet of Fire", "Harry Potter and the Philosopher's Stone")]
        [TestCase("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Chamber of Secrets",
            "Harry Potter and the Order of the Phoenix", "Harry Potter and the Philosopher's Stone")]
        public void With4DifferentBooksYouGetA20PercentDiscount(string book1, string book2, string book3, string book4)
        {
            _potterBasket.Add(book1);
            _potterBasket.Add(book2);
            _potterBasket.Add(book3);
            _potterBasket.Add(book4);

            Assert.AreEqual(8M * 4 * 0.8M, _potterBasket.Total);
        }
    }
}