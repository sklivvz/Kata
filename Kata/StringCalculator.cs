using System;
using System.Text.RegularExpressions;

namespace Kata
{
	public class StringCalculator
	{
		public int Add (string values)
		{
			string separator = "[,\n]";
			if (values.StartsWith("//"))
			{
				var lines = values.Split('\n');
				values = lines[1];
				separator = @"\"+lines[0].Substring(2);
			}
			if (values == string.Empty) return 0;
			
			int sum = 0;
			string errors = "";
			foreach(string token in Regex.Split(values,separator))
			{
				var val = int.Parse(token);
				if (val<0)
				{
					errors+=errors.Length==0?token:","+token;
				}
				sum += val;
			}
			if (errors != "")
			{
				throw new ArgumentOutOfRangeException("values",errors);
			}
			return sum;
		}
	}
}

