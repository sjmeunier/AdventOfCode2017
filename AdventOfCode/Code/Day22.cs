
using System;
using System.IO;

namespace AdventOfCode
{
	public class Day22
	{

		private enum Direction
		{
			Up,
			Down,
			Left,
			Right
		}

		private static Direction TurnLeft(Direction direction)
		{
			if (direction == Direction.Up)
				return Direction.Left;
			if (direction == Direction.Left)
				return Direction.Down;
			if (direction == Direction.Down)
				return Direction.Right;
			return Direction.Up;
		}

		private static Direction TurnRight(Direction direction)
		{
			if (direction == Direction.Up)
				return Direction.Right;
			if (direction == Direction.Right)
				return Direction.Down;
			if (direction == Direction.Down)
				return Direction.Left;
			return Direction.Up;
		}

		public static int Problem1()
		{
			int maxSize = 10001;
			char[,] grid = new char[maxSize, maxSize];
			var input = File.ReadAllLines(@"Input\Day22.txt");

			for (int i = 0; i < maxSize; i++)
			{
				for (int j = 0; j < maxSize; j++)
				{
					grid[i, j] = '.';
				}
			}

			int currentX = maxSize / 2 + 1;
			int currentY = maxSize / 2 + 1;
			Direction direction = Direction.Up;

			for (int i = 0; i < input.Length; i++)
			{
				for (int j = 0; j < input.Length; j++)
				{
					grid[j + currentX - (input.Length / 2), i + currentY - (input.Length / 2)] = input[i][j];
				}
			}

			int infectedTurns = 0;
			
			for (int i = 0; i < 10000; i++)
			{
				if (grid[currentX, currentY] == '.')
				{
					grid[currentX, currentY] = '.';
					direction = TurnLeft(direction);

					infectedTurns++;

					switch (direction)
					{
						case Direction.Up:
							currentY--;
							break;
						case Direction.Down:
							currentY++;
							break;
						case Direction.Left:
							currentX--;
							break;
						case Direction.Right:
							currentX++;
							break;
					}
				}
				else if (grid[currentX, currentY] == '#')
				{
					grid[currentX, currentY] = '.';
					direction = TurnRight(direction);

					switch (direction)
					{
						case Direction.Up:
							currentY--;
							break;
						case Direction.Down:
							currentY++;
							break;
						case Direction.Left:
							currentX--;
							break;
						case Direction.Right:
							currentX++;
							break;
					}
				}
			}
			
			Console.WriteLine();
			for (int i = (maxSize / 2) - 8; i < (maxSize / 2) + 12; i++)
			{
				for (int j = (maxSize / 2) - 8; j < (maxSize / 2) + 12; j++)
				{
					if (i == maxSize / 2 + 1 && j == maxSize / 2 + 1)
						Console.Write('x');
					else
						Console.Write(grid[j, i]);
				}
				Console.WriteLine();
			}
			return infectedTurns;
		}

		public static int Problem2()
		{
			int maxSize = 10001;
			char[,] grid = new char[maxSize, maxSize];
			var input = File.ReadAllLines(@"Input\Day22.txt");

			for (int i = 0; i < maxSize; i++)
			{
				for (int j = 0; j < maxSize; j++)
				{
					grid[i, j] = '.';
				}
			}

			int currentX = maxSize / 2 + 1;
			int currentY = maxSize / 2 + 1;
			Direction direction = Direction.Up;

			for (int i = 0; i < input.Length; i++)
			{
				for (int j = 0; j < input.Length; j++)
				{
					grid[j + currentX - (input.Length / 2), i + currentY - (input.Length / 2)] = input[i][j];
				}
			}

			int infectedTurns = 0;

			for (int i = 0; i < 10000000; i++)
			{
				if (grid[currentX, currentY] == '.')
				{
					grid[currentX, currentY] = 'W';
					direction = TurnLeft(direction);


					switch (direction)
					{
						case Direction.Up:
							currentY--;
							break;
						case Direction.Down:
							currentY++;
							break;
						case Direction.Left:
							currentX--;
							break;
						case Direction.Right:
							currentX++;
							break;
					}
				}
				else if (grid[currentX, currentY] == 'W')
				{
					grid[currentX, currentY] = '#';

					infectedTurns++;
					switch (direction)
					{
						case Direction.Up:
							currentY--;
							break;
						case Direction.Down:
							currentY++;
							break;
						case Direction.Left:
							currentX--;
							break;
						case Direction.Right:
							currentX++;
							break;
					}
				}
				else if (grid[currentX, currentY] == '#')
				{
					grid[currentX, currentY] = 'F';
					direction = TurnRight(direction);

					switch (direction)
					{
						case Direction.Up:
							currentY--;
							break;
						case Direction.Down:
							currentY++;
							break;
						case Direction.Left:
							currentX--;
							break;
						case Direction.Right:
							currentX++;
							break;
					}
				}
				else if (grid[currentX, currentY] == 'F')
				{
					grid[currentX, currentY] = '.';
					direction = TurnRight(direction);
					direction = TurnRight(direction);

					switch (direction)
					{
						case Direction.Up:
							currentY--;
							break;
						case Direction.Down:
							currentY++;
							break;
						case Direction.Left:
							currentX--;
							break;
						case Direction.Right:
							currentX++;
							break;
					}
				}
			}

			Console.WriteLine();
			for (int i = (maxSize / 2) - 8; i < (maxSize / 2) + 12; i++)
			{
				for (int j = (maxSize / 2) - 8; j < (maxSize / 2) + 12; j++)
				{
					if (i == maxSize / 2 + 1 && j == maxSize / 2 + 1)
						Console.Write('x');
					else
						Console.Write(grid[j, i]);
				}
				Console.WriteLine();
			}
			return infectedTurns;
		}
	}
}
