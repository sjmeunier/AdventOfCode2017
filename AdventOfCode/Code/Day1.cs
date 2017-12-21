using System;

namespace AdventOfCode
{
	//Inverse Captcha
	public class Day1
	{
		public static int Problem1(string numberString)
		{
			int sum = 0;
			for (int i = 0; i < numberString.Length; i++)
			{
				if (numberString[i] == numberString[(i + 1) % numberString.Length])
				{
					sum += Convert.ToInt32(numberString[i].ToString());
				}
			}
			return sum;
		}

		public static int Problem2(string numberString)
		{
			int sum = 0;
			for (int i = 0; i < numberString.Length; i++)
			{
				if (numberString[i] == numberString[(i + (numberString.Length / 2)) % numberString.Length])
				{
					sum += Convert.ToInt32(numberString[i].ToString());
				}
			}
			return sum;
		}
	}
}
