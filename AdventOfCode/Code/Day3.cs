using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Schema;

namespace AdventOfCode
{
	public class Day3
	{
		public static int Problem1(int num)
		{
			int maxWidth = 1;
			int square = maxWidth * maxWidth;
			while (num > square)
			{
				maxWidth += 2;
				square = maxWidth * maxWidth;
			}

			int acrossMoves = maxWidth / 2;
			int spaces = 0;
			int lastMid = square - (maxWidth / 2);

			bool notFound = true;
			while (notFound)
			{
				if (num > lastMid - (maxWidth / 2) && num < lastMid + (maxWidth / 2))
				{
					spaces = Math.Abs(lastMid - num);
					notFound = false;
				}
				else
				{
					lastMid -= maxWidth - 1;
				}
			}

			int totalMoves = acrossMoves + spaces;
			return totalMoves;
		}

		public static int Problem2(int max)
		{
			int[,] matrix = new int[101, 101];
			int x = 50;
			int y = 50;

			matrix[x, y] = 1;
			int val = 1;
			Console.Write(val);
			int radius = 3;
			int topRight = radius * radius - ((radius - 1) * 3);
			int topLeft = radius * radius - ((radius - 1) * 2);
			int bottomLeft = radius * radius - ((radius - 1) * 1);
			int bottomRight = radius * radius;
			int blockNum = 1;
			Console.WriteLine();
			Console.Write($"r:{radius}[{topRight},{topLeft},{bottomLeft},{bottomRight}] :-- ");
			x++;
			while (val < max)
			{
				blockNum++;
				if (blockNum > 2)
				{
					if (blockNum <= topRight)
					{
						y--;
					}
					else if (blockNum <= topLeft)
					{
						x--;
					}
					else if (blockNum <= bottomLeft)
					{
						y++;
					}
					else if (blockNum <= bottomRight)
					{
						x++;
					}
					else
					{
						radius = radius + 2;
						topRight = radius * radius - ((radius - 1) * 3);
						topLeft = radius * radius - ((radius - 1) * 2);
						bottomLeft = radius * radius - ((radius - 1) * 1);
						bottomRight = radius * radius;
						x++;
						Console.WriteLine();
						Console.Write($"r:{radius}[{topRight},{topLeft},{bottomLeft},{bottomRight}] :-- ");
					}
				}
				val = matrix[x - 1, y - 1] + matrix[x - 1, y] + matrix[x - 1, y + 1] + matrix[x, y - 1] +
				               matrix[x, y + 1] + matrix[x + 1, y - 1] + matrix[x + 1, y] + matrix[x + 1, y + 1];
				matrix[x, y] = val;
				Console.Write(", ");
				Console.Write($"{blockNum}-{val}");
				Console.Write($"[{x},{y}]");
			}
			Console.WriteLine();
			return val;
		}
	}
}
