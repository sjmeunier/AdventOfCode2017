using System.IO;
using System;
using System.Linq;

namespace AdventOfCode
{
	public class Day16
	{
		private static char[] sequence;

		private static void Spin(int size)
		{
			char[] newSequence = new char[sequence.Length];
			for (int i = 0; i < sequence.Length; i++)
			{
				newSequence[i] = sequence[((sequence.Length - size) + i) % sequence.Length];
			}
			sequence = newSequence;
		}

		private static void SwapPos(int pos1, int pos2)
		{
			char tmp = sequence[pos1];
			sequence[pos1] = sequence[pos2];
			sequence[pos2] = tmp;
		}

		private static void SwapChar(char char1, char char2)
		{
			int pos1 = 0;
			int pos2 = 0;
			for (int i = 0; i < sequence.Length; i++)
			{
				if (sequence[i] == char1)
					pos1 = i;
				if (sequence[i] == char2)
					pos2 = i;
			}
			SwapPos(pos1, pos2);
		}

		public static string Problem1()
		{
			sequence = new[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p'};
			var input = File.ReadAllText(@"Input\Day16.txt");
			var instructions = input.Split(',');

			foreach (var instruction in instructions)
			{
				var code = instruction.Substring(0, 1);
				if (code == "s")
				{
					Spin(Convert.ToInt32(instruction.Substring(1, instruction.Length - 1)));
				}
				else if (code == "x")
				{
					var param = instruction.Substring(1, instruction.Length - 1).Split("/");
					SwapPos(Convert.ToInt32(param[0]), Convert.ToInt32(param[1]));
				}
				else if (code == "p")
				{
					var param = instruction.Substring(1, instruction.Length - 1).Split("/");
					SwapChar(param[0][0], param[1][0]);
				}

			}
			string result = "";
			foreach (var item in sequence)
				result += item.ToString();
			return result;
		}

		public static string Problem2()
		{
			var originalSequence = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
			sequence = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
			var input = File.ReadAllText(@"Input\Day16.txt");
			var instructions = input.Split(',');

			int modFactor = 0;
			bool notFound = true;
			while (notFound)
			{
				foreach (var instruction in instructions)
				{
					var code = instruction.Substring(0, 1);
					if (code == "s")
					{
						Spin(Convert.ToInt32(instruction.Substring(1, instruction.Length - 1)));
					}
					else if (code == "x")
					{
						var param = instruction.Substring(1, instruction.Length - 1).Split("/");
						SwapPos(Convert.ToInt32(param[0]), Convert.ToInt32(param[1]));
					}
					else if (code == "p")
					{
						var param = instruction.Substring(1, instruction.Length - 1).Split("/");
						SwapChar(param[0][0], param[1][0]);
					}

				}
				modFactor++;
				if (sequence.SequenceEqual(originalSequence))
					notFound = false;
			}

			int iterations = 1000000000 % modFactor;

			for (int i = 0; i < iterations; i++)
			{
				foreach (var instruction in instructions)
				{
					var code = instruction.Substring(0, 1);
					if (code == "s")
					{
						Spin(Convert.ToInt32(instruction.Substring(1, instruction.Length - 1)));
					}
					else if (code == "x")
					{
						var param = instruction.Substring(1, instruction.Length - 1).Split("/");
						SwapPos(Convert.ToInt32(param[0]), Convert.ToInt32(param[1]));
					}
					else if (code == "p")
					{
						var param = instruction.Substring(1, instruction.Length - 1).Split("/");
						SwapChar(param[0][0], param[1][0]);
					}

				}
			}
			string result = "";
			foreach (var item in sequence)
				result += item.ToString();
			return result;
		}
	}
}
