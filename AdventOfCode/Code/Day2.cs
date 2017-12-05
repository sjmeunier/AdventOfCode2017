using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
	public class Day2
	{
		public static int Problem1()
		{
			string[] lines = File.ReadAllLines(@"Input\Day2-1.txt");

			int sum = 0;


			for (int i = 0; i < lines.Length; i++)
			{
				string[] line = lines[i].Split('\t');
				List<int> numbers = new List<int>();
				for (int j = 0; j < line.Length; j++)
					numbers.Add(Convert.ToInt32(line[j]));
				sum += numbers.Max() - numbers.Min();
			}
			return sum;
		}

		public static int Problem2()
		{
			string[] lines = File.ReadAllLines(@"Input\Day2-2.txt");

			int sum = 0;

			for (int i = 0; i < lines.Length; i++)
			{
				string[] line = lines[i].Split('\t');
				List<int> numbers = new List<int>();
				for (int j = 0; j < line.Length; j++)
					numbers.Add(Convert.ToInt32(line[j]));

				for(int j = 0; j < numbers.Count; j++)
				{
					for (int k = 0; k < numbers.Count; k++)
					{
						if (k != j)
						{
							if (numbers[j] % numbers[k] == 0)
							{
								sum += numbers[j] / numbers[k];
							}
						}
					}
				}
			}
			return sum;
		}
	}
}
