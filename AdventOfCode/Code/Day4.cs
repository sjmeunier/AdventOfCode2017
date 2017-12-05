using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace AdventOfCode
{
	public class Day4
	{
		public static int Problem1()
		{
			string[] lines = File.ReadAllLines(@"Input\Day4-1.txt");
			int totalValid = 0;
			foreach (string line in lines)
			{
				string[] arr = line.Split(' ');
				if (arr.Distinct().Count() == arr.Count())
					totalValid += 1;
			}
			return totalValid;
		}

		public static int Problem2()
		{
			string[] lines = File.ReadAllLines(@"Input\Day4-2.txt");
			int totalValid = 0;
			foreach (string line in lines)
			{
				bool isValid = true;
				string[] arr = line.Split(' ');
				for (int i = 0; i < arr.Length; i++)
				{
					for (int j = 0; j < arr.Length; j++)
					{
						if (i == j)
							continue;
						if (arr[j].Length != arr[i].Length)
							continue;

						int invalidCount = 0;

						string temp = arr[j];
						for (int k = 0; k < arr[i].Length; k++)
						{
							if (temp.Contains(arr[i][k].ToString()))
							{
								temp = temp.Remove(temp.IndexOf(arr[i][k]), 1);
								invalidCount++;
							}
						}
						if (invalidCount == arr[i].Length)
							isValid = false;

					}
				}
				if (isValid)
					totalValid++;

			}
			return totalValid;
		}
	}
}
