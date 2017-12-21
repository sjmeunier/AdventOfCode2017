using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace AdventOfCode
{
	public class Day11
	{
		public static int Problem1()
		{
			var input = File.ReadAllText(@"Input\Day11.txt").Replace("\n", "").Replace("\r", "");
			var directions = input.Split(',').ToList();
			int x = 0;
			int y = 0;
			int z = 0;

			foreach (var direction in directions)
			{
				switch (direction)
				{
					case "n":
						y += 1;
						z -= 1;
						break;
					case "s":
						y -= 1;
						z += 1;
						break;
					case "ne":
						x += 1;
						z -= 1;
						break;
					case "sw":
						x -= 1;
						z += 1;
						break;
					case "nw":
						x -= 1;
						y += 1;
						break;
					case "se":
						x += 1;
						y -= 1;
						break;
				}
			}

			var shortestDist = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;

			return shortestDist;
		}


		public static int Problem2()
		{
			var input = File.ReadAllText(@"Input\Day11.txt").Replace("\n", "").Replace("\r", "");
			var directions = input.Split(',').ToList();
			int x = 0;
			int y = 0;
			int z = 0;
			List<int> maxInt = new List<int>();
			var maxDist = 0;

			foreach (var direction in directions)
			{
				switch (direction)
				{
					case "n":
						y += 1;
						z -= 1;
						break;
					case "s":
						y -= 1;
						z += 1;
						break;
					case "ne":
						x += 1;
						z -= 1;
						break;
					case "sw":
						x -= 1;
						z += 1;
						break;
					case "nw":
						x -= 1;
						y += 1;
						break;
					case "se":
						x += 1;
						y -= 1;
						break;
				}

				var dist = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
				maxInt.Add(dist);
			}
			maxDist = maxInt.Max();

			return maxDist;
		}

	}
}
