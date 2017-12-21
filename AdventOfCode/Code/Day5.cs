using System;
using System.IO;

namespace AdventOfCode
{
	public class Day5
	{
		public static int Problem1()
		{
			string[] lines = File.ReadAllLines(@"Input\Day5.txt");
			int[] numbers = new int[lines.Length];
			for (int i = 0; i < lines.Length; i++)
				numbers[i] = Convert.ToInt32(lines[i]);

			int index = 0;
			int counter = 0;
			bool inside = true;
			while (inside)
			{
				counter++;
				int val = numbers[index];
				numbers[index]++;
				index += val;
				if (index < 0 || index >= numbers.Length)
					inside = false;
			}

			return counter;
		}

		public static int Problem2()
		{
			string[] lines = File.ReadAllLines(@"Input\Day5.txt");
			int[] numbers = new int[lines.Length];
			for (int i = 0; i < lines.Length; i++)
				numbers[i] = Convert.ToInt32(lines[i]);

			int index = 0;
			int counter = 0;
			bool inside = true;
			while (inside)
			{
				counter++;
				int val = numbers[index];
				if (val >= 3)
					numbers[index]--;
				else
					numbers[index]++;
				index += val;
				if (index < 0 || index >= numbers.Length)
					inside = false;
			}

			return counter;
		}
	}
}
