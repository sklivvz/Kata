using System;
using NUnit.Framework;

using Kata;

namespace Kata.Tests
{
	[TestFixture()]
	public class StringCalculatorTest
	{

		
		private StringCalculator Arrange ()
		{
			return new StringCalculator();
		}
		
		//Create a simple String calculator with a method int Add(string numbers)
		//The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
		
		//Allow the Add method to handle an unknown amount of numbers
		
		//Allow the Add method to handle new lines between numbers (instead of commas).
		
		//Support different delimiters
		//to change a delimiter, the beginning of the string will contain a separate line that looks like this:   
		//“//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the default delimiter is ‘;’ .
		
		//Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.
		//if there are multiple negatives, show all of them in the exception message
		
		[Test()]
		public void WhenZeroNumbersAreGiven_WillReturnZero ()
		{
		  	var calc = Arrange ();
			
			int sum = calc.Add(String.Empty);
				
			Assert.AreEqual(0,sum);
		}

		[Test()]
		public void WhenOneNumberIsGiven_WillReturnIt ()
		{
		  	var calc = Arrange ();
			
			int sum = calc.Add("1");
				
			Assert.AreEqual(1,sum);
		}

		[Test()]
		public void WhenTwoNumbersAreGiven_WillReturnTheSum ()
		{
		  	var calc = Arrange ();
			
			int sum = calc.Add("1,2");
				
			Assert.AreEqual(3,sum);
		}
	
		[Test()]
		public void WhenALotOfNumbersAreGiven_WillReturnTheSum ()
		{
		  	var calc = Arrange ();
			
			int sum = calc.Add("1,2,1,15,42,22,1,0,3,5");
				
			Assert.AreEqual(92,sum);
		}
		
		[Test()]
		public void WhenNewLinesSeparate_WillReturnTheSum ()
		{
		  	var calc = Arrange ();
			
			int sum = calc.Add("1\n2");
				
			Assert.AreEqual(3,sum);
		}
		
		[Test()]
		public void WhenUsingACustomSeparator_WillReturnTheSum ()
		{
		  	var calc = Arrange ();
			
			int sum = calc.Add("//;\n1;2");
				
			Assert.AreEqual(3,sum);
		}
		
				
		[Test()]
		public void WhenUsingACustomSeparator_EmptyStringWillReturnZero ()
		{
		  	var calc = Arrange ();
			
			int sum = calc.Add("//;\n");
				
			Assert.AreEqual(0,sum);
		}
		
						
		[Test()]
		public void WhenUsingACustomSeparator_VariousSeparatorsAreSupported ()
		{
		  	var calc = Arrange ();
			
			int sum = calc.Add("//$\n1$2");
				
			Assert.AreEqual(3,sum);
		}
		
		[Test()]
		public void WhenANegativeIsGiven_WillThrow ()
		{
		  	var calc = Arrange ();
			try 
			{
				calc.Add("-1,2");
				Assert.Fail("Should have thrown an exception!");
			} 
			catch (ArgumentOutOfRangeException ex) 
			{
				Assert.AreEqual("-1", ex.Message.Split('\n')[0]);
			}
				
		}	
		
		[Test()]
		public void WhenMultipleNegativesAreGiven_WillThrow ()
		{
		  	var calc = Arrange ();
			try 
			{
				calc.Add("-1,2,-3,-4");
				Assert.Fail("Should have thrown an exception!");
			} 
			catch (ArgumentOutOfRangeException ex) 
			{
				Assert.AreEqual("-1,-3,-4", ex.Message.Split('\n')[0]);
			}
				
		}
	}
}

