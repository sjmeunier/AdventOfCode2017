
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
	public class Day23
	{

		static Dictionary<string, long> registers = new Dictionary<string, long>();

		public static long Problem1()
		{
			var input = File.ReadAllLines(@"Input\Day23.txt");
			Instruction[] instructions = new Instruction[input.Length];
			for (int i = 0; i < input.Length; i++)
			{
				var arr = input[i].Split(' ');
				instructions[i] = new Instruction()
				{
					Code = arr[0],
					Register = arr[1],
					Value = arr.Length > 2 ? arr[2] : ""
				};
			}

			long count = 0;
			int instructionPointer = 0;
			while (true)
			{
				if (instructionPointer >= instructions.Length)
				{
					break;
				}

				var instruction = instructions[instructionPointer++];

				var command = instruction.Code;

				long num = 0;
				long val = 0;

				switch (command)
				{
					case "set":
						if (Int64.TryParse(instruction.Value, out num))
							val = num;
						else
							val = GetRegister(instruction.Value);

						registers[instruction.Register] = val;
						break;
					case "sub":
						if (Int64.TryParse(instruction.Value, out num))
							val = GetRegister(instruction.Register) - num;
						else
							val = GetRegister(instruction.Register) - GetRegister(instruction.Value);

						registers[instruction.Register] = val;
						break;
					case "mul":
						if (Int64.TryParse(instruction.Value, out num))
							val = GetRegister(instruction.Register) * num;
						else
							val = GetRegister(instruction.Register) * GetRegister(instruction.Value);

						registers[instruction.Register] = val;
						count++;
						break;
					case "jnz":
						if (Int64.TryParse(instruction.Register, out num))
							val = num;
						else
							val = GetRegister(instruction.Register);

						if (val != 0)
						{
							if (Int64.TryParse(instruction.Value, out num))
								val = num;
							else
								val = GetRegister(instruction.Value);

							var jumpCount = val;

							instructionPointer--;
							instructionPointer += (int)jumpCount;
						}

						break;
				}
			}

			return count;
		}

		private static void SetRegister(string register, long value)
		{
			if (registers.ContainsKey(register))
				registers[register] = value;
			else
			{
				registers.Add(register, value);
			}
		}

		private static long GetRegister(string register)
		{
			if (registers.ContainsKey(register))
				return registers[register];
			return 0;
		}


		public static long Problem2()
		{
			int a = 1;
			int b = 0;
			int c = 0;
			int d = 0;
			int e = 0;
			int f = 0;
			int g = 0;
			int h = 0;

			b = 67 * 100 + 100000;
			c = b + 17000;
			
			do
			{
				f = 1;
				d = 2;
				e = 2;
				for (d = 2; d * d <= b; d++)
				{ 
					if ((b % d == 0))
					{
						f = 0;
						break;
					}
				}
				if (f == 0) 
					h++;
				g = b - c;
				b += 17;
			} while (g != 0);

			return h;
		}

	}
}
