using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace AdventOfCode
{
	public class Day8
	{
		public static int Problem1()
		{
			string[] lines = File.ReadAllLines(@"Input\Day8.txt");
			Dictionary<string, int> registers = new Dictionary<string, int>();

			foreach (var line in lines)
			{
				// 0 = register 1
				// 1 = operation
				// 2 = value
				// 3 = if
				// 4 = register 2
				// 5 = comparator
				// 6 = compare value

				var lineArr = line.Split(" ");

				int comparatorValue = 0;
				if (registers.ContainsKey(lineArr[4]))
					comparatorValue = registers[lineArr[4]];

				bool doInstruction = false;
				switch (lineArr[5])
				{
					case ">":
						if (comparatorValue > Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case ">=":
						if (comparatorValue >= Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case "<":
						if (comparatorValue < Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case "<=":
						if (comparatorValue <= Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case "==":
						if (comparatorValue == Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case "!=":
						if (comparatorValue != Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
				}

				if (doInstruction)
				{
					int registerValue = 0;
					if (registers.ContainsKey(lineArr[0]))
						registerValue = registers[lineArr[0]];
					switch (lineArr[1])
					{
						case "inc":
							registerValue += Convert.ToInt32(lineArr[2]);
							break;
						case "dec":
							registerValue -= Convert.ToInt32(lineArr[2]);
							break;
					}
					if (registers.ContainsKey(lineArr[0]))
						registers[lineArr[0]] = registerValue;
					else
						registers.Add(lineArr[0], registerValue);
				}
			}

			int maxVal = 0;
			foreach (var val in registers.Values)
			{
				maxVal = Math.Max(maxVal, val);
			}
			return maxVal;
		}

		public static int Problem2()
		{
			string[] lines = File.ReadAllLines(@"Input\Day8.txt");
			Dictionary<string, int> registers = new Dictionary<string, int>();
			int maxVal = 0;

			foreach (var line in lines)
			{
				// 0 = register 1
				// 1 = operation
				// 2 = value
				// 3 = if
				// 4 = register 2
				// 5 = comparator
				// 6 = compare value

				var lineArr = line.Split(" ");

				int comparatorValue = 0;
				if (registers.ContainsKey(lineArr[4]))
					comparatorValue = registers[lineArr[4]];

				bool doInstruction = false;
				switch (lineArr[5])
				{
					case ">":
						if (comparatorValue > Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case ">=":
						if (comparatorValue >= Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case "<":
						if (comparatorValue < Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case "<=":
						if (comparatorValue <= Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case "==":
						if (comparatorValue == Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
					case "!=":
						if (comparatorValue != Convert.ToInt32(lineArr[6]))
							doInstruction = true;
						break;
				}

				if (doInstruction)
				{
					int registerValue = 0;
					if (registers.ContainsKey(lineArr[0]))
						registerValue = registers[lineArr[0]];
					switch (lineArr[1])
					{
						case "inc":
							registerValue += Convert.ToInt32(lineArr[2]);
							break;
						case "dec":
							registerValue -= Convert.ToInt32(lineArr[2]);
							break;
					}
					if (registers.ContainsKey(lineArr[0]))
						registers[lineArr[0]] = registerValue;
					else
						registers.Add(lineArr[0], registerValue);

					maxVal = Math.Max(registerValue, maxVal);
				}
			}

			return maxVal;
		}

		
	}
}
