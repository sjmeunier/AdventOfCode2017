using System.IO;
using System;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
	public class Day10
	{
		public static int Problem1()
		{
			string input = File.ReadAllText(@"Input\Day10.txt");
			string[] inputArr  = input.Split(',');
			int[] inputList = new int[inputArr.Length];
			for (int i = 0; i < inputArr.Length; i++)
				inputList[i] = Convert.ToInt32(inputArr[i]);
			int[] list = new int[256];
			for (int i = 0; i < 256; i++)
				list[i] = i;

			int position = 0;
			int skipSize = 0;


			foreach (int item in inputList)
			{
				var sublist = new int[item];
				for (int i = 0; i < item; i++)
				{
					sublist[i] = list[(position + i) % list.Length];
				}
				sublist = sublist.Reverse().ToArray<int>();
				for (int i = 0; i < item; i++)
				{
					list[(position + i) % list.Length] = sublist[i];
				}
				position += item + skipSize;
				position = position % list.Length;
				skipSize++;
			}


			return list[0] * list[1];
		}

		public static string Problem2()
		{
			string input = File.ReadAllText(@"Input\Day10.txt");

			//string[] inputArr = input.Split(',');
			char[] inputCharArr = new char[input.Length];
			for (int i = 0; i < input.Length; i++)
				inputCharArr[i] = input[i];

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
	}
}
