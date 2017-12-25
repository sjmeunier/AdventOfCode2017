using System.Linq;

namespace AdventOfCode
{
	public class Day25
	{

		public static int Problem1()
		{
			int maxSteps = 12173597;
			byte[] tape = new byte[5000000];
			int currentPos = tape.Length / 2;

			char state = 'A';

			for(var i = 0; i < maxSteps; i++)
			{
				switch (state)
				{
					case 'A':
						if (tape[currentPos] == 0)
						{
							tape[currentPos] = 1;
							currentPos++;
							state = 'B';
						}
						else
						{
							tape[currentPos] = 0;
							currentPos--;
							state = 'C';
						}
						break;
					case 'B':
						if (tape[currentPos] == 0)
						{
							tape[currentPos] = 1;
							currentPos--;
							state = 'A';
						}
						else
						{
							tape[currentPos] = 1;
							currentPos++;
							state = 'D';
						}
						break;
					case 'C':
						if (tape[currentPos] == 0)
						{
							tape[currentPos] = 1;
							currentPos++;
							state = 'A';
						}
						else
						{
							tape[currentPos] = 0;
							currentPos--;
							state = 'E';
						}
						break;
					case 'D':
						if (tape[currentPos] == 0)
						{
							tape[currentPos] = 1;
							currentPos++;
							state = 'A';
						}
						else
						{
							tape[currentPos] = 0;
							currentPos++;
							state = 'B';
						}
						break;
					case 'E':
						if (tape[currentPos] == 0)
						{
							tape[currentPos] = 1;
							currentPos--;
							state = 'F';
						}
						else
						{
							tape[currentPos] = 1;
							currentPos--;
							state = 'C';
						}
						break;
					case 'F':
						if (tape[currentPos] == 0)
						{
							tape[currentPos] = 1;
							currentPos++;
							state = 'D';
						}
						else
						{
							tape[currentPos] = 1;
							currentPos++;
							state = 'A';
						}
						break;

				}
			}

			int sum = 0;
			foreach (var item in tape.Where(x => x == 1))
			{
				sum++;
			}
			return sum;
		}

		public static int Problem2()
		{
			return 0;
		}
	}
}
