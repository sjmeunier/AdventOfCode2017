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
	public class Day6
	{
		public static int Problem1()
		{
			string[] line = File.ReadAllText(@"Input\Day6.txt").Split('\t');

			int[] banks = new int[line.Length];
			for (int i = 0; i < line.Length; i++)
				banks[i] = Convert.ToInt32(line[i]);

			List<int[]> history = new List<int[]>();

			foreach (int val in banks)
			{
				Console.Write($"{val} ");
			}
			Console.WriteLine();

			int counter = 0;
			
			bool notLooping = true;
			while (notLooping)
			{
				history.Add((int[])banks.Clone());

				counter++;
				int maxIndex = 0;
				int maxVal = 0;
				for (int i = 0; i < banks.Length; i++)
				{
					if (banks[i] > maxVal)
					{
						maxVal = banks[i];
						maxIndex = i;
					}
				}
				banks[maxIndex] = 0;
				int redisVal = maxVal;
				int currentBank = maxIndex + 1;
				currentBank = currentBank % banks.Length;
				while (redisVal > 0)
				{
					banks[currentBank]++;
					redisVal--;

					currentBank++;
					currentBank = currentBank % banks.Length;
				}

				foreach (int[] historicBank in history)
				{
					if (historicBank.SequenceEqual(banks))
					{
						notLooping = false;
					}
				}

				foreach (int val in banks)
				{
					Console.Write($"{val} ");
				}
				Console.WriteLine();

			}

			return counter;
		}

		public static int Problem2()
		{
			string[] line = File.ReadAllText(@"Input\Day6.txt").Split('\t');
			int[] historicMatch = new int[line.Length];

			int[] banks = new int[line.Length];
			for (int i = 0; i < line.Length; i++)
				banks[i] = Convert.ToInt32(line[i]);

			List<int[]> history = new List<int[]>();

			foreach (int val in banks)
			{
				Console.Write($"{val} ");
			}
			Console.WriteLine();

			int counter = 0;

			bool notLooping = true;
			int loopCounter = 0;
			bool inLoop = false;

			while (notLooping)
			{
				history.Add((int[])banks.Clone());

				counter++;
				int maxIndex = 0;
				int maxVal = 0;
				for (int i = 0; i < banks.Length; i++)
				{
					if (banks[i] > maxVal)
					{
						maxVal = banks[i];
						maxIndex = i;
					}
				}
				banks[maxIndex] = 0;
				int redisVal = maxVal;
				int currentBank = maxIndex + 1;
				currentBank = currentBank % banks.Length;
				while (redisVal > 0)
				{
					banks[currentBank]++;
					redisVal--;

					currentBank++;
					currentBank = currentBank % banks.Length;
				}
				if (inLoop)
				{
					loopCounter++;
					if (historicMatch.SequenceEqual(banks))
						notLooping = false;
				}
				else
				{
					foreach (int[] historicBank in history)
					{
						if (historicBank.SequenceEqual(banks))
						{
							inLoop = true;
							historicMatch = historicBank;
						}
					}
				}

				foreach (int val in banks)
				{
					Console.Write($"{val} ");
				}
				Console.WriteLine();

			}

			return loopCounter;
		}
	}
}
