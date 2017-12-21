
namespace AdventOfCode
{
	public class Day15
	{
		public static long findNextNumber(long number, long factor)
		{
			long num = number * factor;
			long remainder = num % 2147483647;

			return remainder;
		}

		public static int Problem1(long aStart, long bStart)
		{
			long numA = aStart;
			long numB = bStart;
			int totalMatches = 0;
			for (int i = 0; i < 40000000; i++)
			{
				numA = findNextNumber(numA, 16807);
				numB = findNextNumber(numB, 48271);

				short byteA = (short)(numA & 0xffff);
				short byteB = (short)(numB & 0xffff);
				if (byteA == byteB)
					totalMatches++;
			}
			return totalMatches;
		}

		public static long findNextNumber2(long number, long factor, long matchFactor)
		{
			long remainder = 1;
			while (remainder % matchFactor > 0)
			{
				if (remainder == 1)
					remainder = number;
				long num = remainder * factor;
				remainder = num % 2147483647;
			}

			return remainder;
		}

		public static int Problem2(long aStart, long bStart)
		{
			long numA = aStart;
			long numB = bStart;
			int totalMatches = 0;
			for (int i = 0; i < 5000000; i++)
			{
				numA = findNextNumber2(numA, 16807, 4);
				numB = findNextNumber2(numB, 48271, 8);

				short byteA = (short)(numA & 0xffff);
				short byteB = (short)(numB & 0xffff);
				if (byteA == byteB)
					totalMatches++;
			}
			return totalMatches;
		}

	}
}
