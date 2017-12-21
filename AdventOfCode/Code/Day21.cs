using System.Collections.Generic;
using System.IO;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Schema;

namespace AdventOfCode
{
	public class Day21
	{

		private static string[] FlipHorizontal(string[] source)
		{
			string[] result = new string[source.Length];
			for (int i = 0; i < source.Length; i++)
			{
				result[i] = new String(source[i].ToCharArray().Reverse().ToArray()); 
			}
			return result;
		}

		private static string[] FlipVertical(string[] source)
		{
			string[] result = new string[source.Length];
			for (int i = 0; i < source.Length; i++)
			{
				result[source.Length - i - 1] = source[i];
			}
			return result;
		}

		private static string[] RotateRight(string[] source)
		{
			string[] result = new string[source.Length];
			for (int i = 0; i < source.Length; i++)
			{
				var arr = new char[source.Length];
				for (int j = 0; j < source.Length; j++)
				{
					arr[j] = source[source.Length - j - 1][i];
				}
				result[i] = new string(arr);
			}
			return result;
		}

		public static int Problem1()
		{
			Dictionary<string, string> patterns = new Dictionary<string, string>();

			var input = File.ReadAllLines(@"Input\Day21.txt");
			foreach (var line in input)
			{
				var arr = line.Split(" => ");

				var replacement = arr[1];

				var source = arr[0].Split("/");

				var match = string.Join("", source);
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipHorizontal(source));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipVertical(source));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipHorizontal(FlipVertical(source)));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);

				source = RotateRight(source);
				match = string.Join("", source);
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipHorizontal(source));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipVertical(source));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipHorizontal(FlipVertical(source)));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);

				source = RotateRight(source);
				match = string.Join("", source);
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipHorizontal(source));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipVertical(source));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipHorizontal(FlipVertical(source)));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);

				source = RotateRight(source);
				match = string.Join("", source);
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipHorizontal(source));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipVertical(source));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
				match = string.Join("", FlipHorizontal(FlipVertical(source)));
				if (!patterns.ContainsKey(match))
					patterns.Add(match, replacement);
			}

			string[] grid = new string[3] { ".#.", "..#", "###"};

			foreach (var line in grid)
				Console.WriteLine(line);
			Console.WriteLine();


			for (int i = 0; i < 18; i++)
			{
				int size = 2;
				if (grid.Length % 3 == 0)
					size = 3;
				if (grid.Length % 2 == 0)
					size = 2;


				int gridsInRow = grid.Length / size;
				string[] resultGrid = new string[gridsInRow + grid.Length];
				for(var x = 0; x < resultGrid.Length; x++)
					resultGrid[x] = new string('-', resultGrid.Length);

				for (var j = 0; j < gridsInRow; j++)
				{
					for (var k = 0; k < gridsInRow; k++)
					{
						string[] subgrid = new string[size];
						for (var m = 0; m < size; m++)
						{
							subgrid[m] = grid[(k * size) + m].Substring(j * size, size);
						}
						var match = patterns[string.Join("", subgrid)];
						var newGrid = match.Split("/");

						for (var m = 0; m < newGrid.Length; m++)
						{
							var str = resultGrid[k * (size + 1) + m].ToCharArray();
							for (var n = 0; n < newGrid.Length; n++)
							{
								str[(j * (size + 1)) + n] = newGrid[m][n];
							}
							resultGrid[k * (size + 1) + m] = new string(str);
						}
					}
				}

				grid = (string[])resultGrid.Clone();

				foreach(var line in grid)
					Console.WriteLine(line);
				Console.WriteLine();
			}

			int count = 0;
			foreach (var line in grid)
			{
				foreach (var cell in line)
				{
					if (cell == '#')
						count++;
				}
			}
			return count;
		}

		public static int Problem2()
		{

			return 0;

		}
	}
}
