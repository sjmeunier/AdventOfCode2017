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
	public class Day19
	{
		public enum DirectionEnum
		{
			Up,
			Down,
			Left,
			Right
		}

		private static bool IsValidHorizontal(char value)
		{
			if (value >= 'A' && value <= 'Z')
				return true;
			if (value == '-')
				return true;
			return false;
		}

		private static bool IsValidVertical(char value)
		{
			if (value >= 'A' && value <= 'Z')
				return true;
			if (value == '|')
				return true;
			return false;
		}

		public static string Problem1()
		{
			var grid = File.ReadAllLines(@"Input\Day19.txt");

			var result = "";
			var currentX = 0;
			var currentY = 0;

			for (currentX = 0; currentX < grid[0].Length; currentX++)
			{
				if (grid[0][currentX] == '|')
					break;
			}
			currentY++;
			var direction = DirectionEnum.Down;

			bool ended = false;
			while (!ended)
			{
				if (grid[currentY][currentX] == ' ')
				{
					ended = true;
				} else if (grid[currentY][currentX] >= 'A' && grid[currentY][currentX] <= 'Z')
				{
					result += grid[currentY][currentX].ToString();
				} else if (grid[currentY][currentX] == '+')
				{
					if (direction == DirectionEnum.Down || direction == DirectionEnum.Up)
					{
						if (currentX < grid[currentY].Length - 2 && IsValidHorizontal(grid[currentY][currentX + 1]))
						{
							direction = DirectionEnum.Right;
						}
						else if (currentX > 1 && IsValidHorizontal(grid[currentY][currentX - 1]))
						{
							direction = DirectionEnum.Left;
						}
					}
					else if (direction == DirectionEnum.Left || direction == DirectionEnum.Right)
					{
						if (currentY < grid.Length - 2 && IsValidVertical(grid[currentY + 1][currentX]))
						{
							direction = DirectionEnum.Down;
						}
						else if (currentY > 1 && IsValidVertical(grid[currentY - 1][currentX]))
						{
							direction = DirectionEnum.Up;
						}
					}

				}

				if (direction == DirectionEnum.Down)
					currentY++;
				else if (direction == DirectionEnum.Up)
					currentY--;
				else if (direction == DirectionEnum.Left)
					currentX--;
				else if (direction == DirectionEnum.Right)
					currentX++;

				if (currentX < 0 || currentY < 0 || currentY > grid.Length - 1 || currentX > grid[currentY].Length - 1)
					ended = true;
			}

			return result;
		}




		public static int Problem2()
		{
			var grid = File.ReadAllLines(@"Input\Day19.txt");

			var result = "";
			var currentX = 0;
			var currentY = 0;
			var stepCount = 0;

			for (currentX = 0; currentX < grid[0].Length; currentX++)
			{
				if (grid[0][currentX] == '|')
					break;
			}

			currentY++;
			var direction = DirectionEnum.Down;

			bool ended = false;
			while (!ended)
			{
				stepCount++;
				if (grid[currentY][currentX] == ' ')
				{
					ended = true;
				}
				else if (grid[currentY][currentX] >= 'A' && grid[currentY][currentX] <= 'Z')
				{
					result += grid[currentY][currentX].ToString();
				}
				else if (grid[currentY][currentX] == '+')
				{
					if (direction == DirectionEnum.Down || direction == DirectionEnum.Up)
					{
						if (currentX < grid[currentY].Length - 2 && IsValidHorizontal(grid[currentY][currentX + 1]))
						{
							direction = DirectionEnum.Right;
						}
						else if (currentX > 1 && IsValidHorizontal(grid[currentY][currentX - 1]))
						{
							direction = DirectionEnum.Left;
						}
					}
					else if (direction == DirectionEnum.Left || direction == DirectionEnum.Right)
					{
						if (currentY < grid.Length - 2 && IsValidVertical(grid[currentY + 1][currentX]))
						{
							direction = DirectionEnum.Down;
						}
						else if (currentY > 1 && IsValidVertical(grid[currentY - 1][currentX]))
						{
							direction = DirectionEnum.Up;
						}
					}

				}

				if (direction == DirectionEnum.Down)
					currentY++;
				else if (direction == DirectionEnum.Up)
					currentY--;
				else if (direction == DirectionEnum.Left)
					currentX--;
				else if (direction == DirectionEnum.Right)
					currentX++;

				if (currentX < 0 || currentY < 0 || currentY > grid.Length - 1 || currentX > grid[currentY].Length - 1)
					ended = true;
			}

			return stepCount;

		}
	}
}
