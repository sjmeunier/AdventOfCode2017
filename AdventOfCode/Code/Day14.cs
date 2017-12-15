using System.Collections.Generic;
using System.IO;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

namespace AdventOfCode
{
	public class Day14
	{
		public static string CalcKnotHash(string hash)
		{
			char[] inputCharArr = new char[hash.Length];
			for (int i = 0; i < hash.Length; i++)
				inputCharArr[i] = hash[i];

			byte[] inputList = new byte[inputCharArr.Length + 5];
			for (int i = 0; i < inputCharArr.Length; i++)
				inputList[i] = (byte)inputCharArr[i];
			inputList[inputCharArr.Length + 0] = 17;
			inputList[inputCharArr.Length + 1] = 31;
			inputList[inputCharArr.Length + 2] = 73;
			inputList[inputCharArr.Length + 3] = 47;
			inputList[inputCharArr.Length + 4] = 23;
			byte[] list = new byte[256];
			for (int i = 0; i < 256; i++)
				list[i] = (byte)i;

			int position = 0;
			int skipSize = 0;
			for (int a = 0; a < 64; a++)
			{
				foreach (int item in inputList)
				{
					var sublist = new byte[item];
					for (int i = 0; i < item; i++)
					{
						sublist[i] = list[(position + i) % list.Length];
					}
					sublist = sublist.Reverse().ToArray<byte>();
					for (int i = 0; i < item; i++)
					{
						list[(position + i) % list.Length] = sublist[i];
					}
					position += item + skipSize;
					position = position % list.Length;
					skipSize++;
				}
			}

			byte[] sparseHash = new byte[16];

			for (int block = 0; block < 16; block++)
			{
				sparseHash[block] = (byte)(list[(block * 16) + 0] ^ list[(block * 16) + 1] ^ list[(block * 16) + 2] ^ list[(block * 16) + 3]
									^ list[(block * 16) + 4] ^ list[(block * 16) + 5] ^ list[(block * 16) + 6] ^ list[(block * 16) + 7]
									^ list[(block * 16) + 8] ^ list[(block * 16) + 9] ^ list[(block * 16) + 10] ^ list[(block * 16) + 11]
									^ list[(block * 16) + 12] ^ list[(block * 16) + 13] ^ list[(block * 16) + 14] ^ list[(block * 16) + 15]);

			}

			string hexString = ByteArrayToString(sparseHash);
			return hexString;

		}
		public static string ByteArrayToString(byte[] ba)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
				hex.AppendFormat("{0:x2}", b);
			return hex.ToString();
		}

		static int[,] grid = new int[128, 128];
		public static int Problem2()
		{
			//-3 = undefined
			//-2 = empty
			//-1 = filled

			var input = File.ReadAllText(@"Input\Day14.txt");
			grid = new int[128, 128];
			for (int i = 0; i < 128; i++)
			{
				for (int j = 0; j < 128; j++)
				{
					grid[i, j] = -3;
				}
			}
			for (int i = 0; i < 128; i++)
			{
				var hash = CalcKnotHash(input + "-" + i.ToString().Trim());
				int j = 0;
				foreach (var digit in hash)
				{
					switch (digit)
					{
						case '0':
							grid[i, j] = -2;
							grid[i, j + 1] = -2;
							grid[i, j + 2] = -2;
							grid[i, j + 3] = -2;
							break;
						case '1':
							grid[i, j] = -2;
							grid[i, j + 1] = -2;
							grid[i, j + 2] = -2;
							grid[i, j + 3] = -1;
							break;
						case '2':
							grid[i, j] = -2;
							grid[i, j + 1] = -2;
							grid[i, j + 2] = -1;
							grid[i, j + 3] = -2;
							break;
						case '3':
							grid[i, j] = -2;
							grid[i, j + 1] = -2;
							grid[i, j + 2] = -1;
							grid[i, j + 3] = -1;
							break;
						case '4':
							grid[i, j] = -2;
							grid[i, j + 1] = -1;
							grid[i, j + 2] = -2;
							grid[i, j + 3] = -2;
							break;
						case '5':
							grid[i, j] = -2;
							grid[i, j + 1] = -1;
							grid[i, j + 2] = -2;
							grid[i, j + 3] = -1;
							break;
						case '6':
							grid[i, j] = -2;
							grid[i, j + 1] = -1;
							grid[i, j + 2] = -1;
							grid[i, j + 3] = -2;
							break;
						case '7':
							grid[i, j] = -2;
							grid[i, j + 1] = -1;
							grid[i, j + 2] = -1;
							grid[i, j + 3] = -1;
							break;
						case '8':
							grid[i, j] = -1;
							grid[i, j + 1] = -2;
							grid[i, j + 2] = -2;
							grid[i, j + 3] = -2;
							break;
						case '9':
							grid[i, j] = -1;
							grid[i, j + 1] = -2;
							grid[i, j + 2] = -2;
							grid[i, j + 3] = -1;
							break;
						case 'a':
							grid[i, j] = -1;
							grid[i, j + 1] = -2;
							grid[i, j + 2] = -1;
							grid[i, j + 3] = -2;
							break;
						case 'b':
							grid[i, j] = -1;
							grid[i, j + 1] = -2;
							grid[i, j + 2] = -1;
							grid[i, j + 3] = -1;
							break;
						case 'c':
							grid[i, j] = -1;
							grid[i, j + 1] = -1;
							grid[i, j + 2] = -2;
							grid[i, j + 3] = -2;
							break;
						case 'd':
							grid[i, j] = -1;
							grid[i, j + 1] = -1;
							grid[i, j + 2] = -2;
							grid[i, j + 3] = -1;
							break;
						case 'e':
							grid[i, j] = -1;
							grid[i, j + 1] = -1;
							grid[i, j + 2] = -1;
							grid[i, j + 3] = -2;
							break;
						case 'f':
							grid[i, j] = -1;
							grid[i, j + 1] = -1;
							grid[i, j + 2] = -1;
							grid[i, j + 3] = -1;
							break;
					}
					j += 4;
				}
			}

			int currentMaxRegion = 0;
			for (int i = 0; i < 128; i++)
			{
				for (int j = 0; j < 128; j++)
				{
					if (grid[i, j] == -1)
					{
						int neighbourRegion = 0;
						if (i > 0 && grid[i - 1, j] > 0)
							neighbourRegion = grid[i - 1, j];
						if (j > 0 && grid[i, j - 1] > 0)
							neighbourRegion = grid[i, j - 1];
						if (i < 127 && grid[i + 1, j] > 0)
							neighbourRegion = grid[i + 1, j];
						if (j < 127 && grid[i, j + 1] > 0)
							neighbourRegion = grid[i, j + 1];

						if (neighbourRegion <= 0)
						{
							currentMaxRegion++;
							
							SetRegion(i, j, currentMaxRegion);
						}
					}
				}
			}
			return currentMaxRegion;
		}

		private static void SetRegion(int i, int j, int region)
		{
			grid[i, j] = region;
			if (i > 0 && grid[i - 1, j] == -1)
				SetRegion(i - 1, j, region);
			if (j > 0 && grid[i, j - 1] == -1)
				SetRegion(i, j - 1, region);
			if (i < 127 && grid[i + 1, j] == -1)
				SetRegion(i + 1, j, region);
			if (j < 127 && grid[i, j + 1] == -1)
				SetRegion(i, j + 1, region);
		}

		public static int Problem1()
		{
			var input = File.ReadAllText(@"Input\Day14.txt");

			List<List<bool>> grid = new List<List<bool>>();
			for (int i = 0; i < 128; i++)
			{
				var hash = CalcKnotHash(input + "-" + i.ToString().Trim());
				var row = new List<bool>();
				foreach (var digit in hash)
				{
					switch (digit)
					{
						case '0':
							row.Add(false);
							row.Add(false);
							row.Add(false);
							row.Add(false);
							break;
						case '1':
							row.Add(false);
							row.Add(false);
							row.Add(false);
							row.Add(true);
							break;
						case '2':
							row.Add(false);
							row.Add(false);
							row.Add(true);
							row.Add(false);
							break;
						case '3':
							row.Add(false);
							row.Add(false);
							row.Add(true);
							row.Add(true);
							break;
						case '4':
							row.Add(false);
							row.Add(true);
							row.Add(false);
							row.Add(false);
							break;
						case '5':
							row.Add(false);
							row.Add(true);
							row.Add(false);
							row.Add(true);
							break;
						case '6':
							row.Add(false);
							row.Add(true);
							row.Add(true);
							row.Add(false);
							break;
						case '7':
							row.Add(false);
							row.Add(true);
							row.Add(true);
							row.Add(true);
							break;
						case '8':
							row.Add(true);
							row.Add(false);
							row.Add(false);
							row.Add(false);
							break;
						case '9':
							row.Add(true);
							row.Add(false);
							row.Add(false);
							row.Add(true);
							break;
						case 'a':
							row.Add(true);
							row.Add(false);
							row.Add(true);
							row.Add(false);
							break;
						case 'b':
							row.Add(true);
							row.Add(false);
							row.Add(true);
							row.Add(true);
							break;
						case 'c':
							row.Add(true);
							row.Add(true);
							row.Add(false);
							row.Add(false);
							break;
						case 'd':
							row.Add(true);
							row.Add(true);
							row.Add(false);
							row.Add(true);
							break;
						case 'e':
							row.Add(true);
							row.Add(true);
							row.Add(true);
							row.Add(false);
							break;
						case 'f':
							row.Add(true);
							row.Add(true);
							row.Add(true);
							row.Add(true);
							break;
					}
				}

				grid.Add(row);
			}

			int total = 0;
			foreach (var row in grid)
			{
				foreach (var entry in row)
				{
					if (entry == true)
						total++;
				}
			}
			return total;
		}

	}
}
