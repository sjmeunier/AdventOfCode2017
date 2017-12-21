using System.IO;

namespace AdventOfCode
{
	public class Day9
	{
		public static int Problem1()
		{
			string input = File.ReadAllText(@"Input\Day9.txt");

			bool isJunk = false;
			bool isNegate = false;
			int total = 0;
			int level = 0;

			foreach (var character in input)
			{
				if (isNegate)
				{
					isNegate = false;
					continue;
				}
				if (character == '!')
				{
					isNegate = true;
				}
				if (isJunk)
				{
					if (character == '>')
						isJunk = false;
				}
				else
				{
					if (character == '<')
					{
						isJunk = true;
					}
					else if (character == '{')
					{
						level++;
					}
					else if (character == '}')
					{
						total += level;
						level--;
					}
				}
			}
			return total;
		}

		public static int Problem2()
		{
			string input = File.ReadAllText(@"Input\Day9.txt");

			bool isJunk = false;
			bool isNegate = false;
			int total = 0;
			int level = 0;
			int totalJunk = 0;
			foreach (var character in input)
			{
				if (isNegate)
				{
					isNegate = false;
					continue;
				}
				if (character == '!')
				{
					isNegate = true;
				}
				if (isJunk)
				{
					if (character == '>')
					{
						isJunk = false;
					}
					else
					{
						if (character != '!')
							totalJunk++;
					}
				}
				else
				{
					if (character == '<')
					{
						isJunk = true;
					}
					else if (character == '{')
					{
						level++;
					}
					else if (character == '}')
					{
						total += level;
						level--;
					}
				}
			}
			return totalJunk;
		}

	}
}
