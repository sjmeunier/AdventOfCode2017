﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
	//Inverse Captcha
	public class Day1
	{
		public static int InverseCatcha(string numberString)
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

		public static int InverseCatcha2(string numberString)
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
