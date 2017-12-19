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
	public class Day18
	{

		static Dictionary<string, long> registers = new Dictionary<string, long>();

		public static long Problem1()
		{
			var input = File.ReadAllLines(@"Input\Day18.txt");
			Instruction[] instructions = new Instruction[input.Length];
			for(int i = 0; i< input.Length; i++)
			{
				var arr = input[i].Split(' ');
				instructions[i] = new Instruction()
				{
					Code = arr[0],
					Register = arr[1],
					Value = arr.Length > 2 ? arr[2] : ""
				};
			}

			long lastSoundPlayed = 0;
			long firstReceive = 0;

			for (int i = 0; i < instructions.Length; i++)
			{
				long val = 0;
				long num;
				switch (instructions[i].Code)
				{
					case "snd":
						lastSoundPlayed = GetRegister(instructions[i].Register);
						break;
					case "add":
						if (Int64.TryParse(instructions[i].Value, out num))
							val = GetRegister(instructions[i].Register) + num;
						else
							val = GetRegister(instructions[i].Register) + GetRegister(instructions[i].Value);

						SetRegister(instructions[i].Register, val);
						break;
					case "set":
						if (Int64.TryParse(instructions[i].Value, out num))
							val = num;
						else
							val = GetRegister(instructions[i].Value);

						SetRegister(instructions[i].Register, val);
						break;
					case "mul":
						
						if (Int64.TryParse(instructions[i].Value, out num)) 
							val = GetRegister(instructions[i].Register) * num;
						else
							val = GetRegister(instructions[i].Register) * GetRegister(instructions[i].Value);

						SetRegister(instructions[i].Register, val);
						break;
					case "mod":
						if (Int64.TryParse(instructions[i].Value, out num))
							val = GetRegister(instructions[i].Register) % num;
						else
							val = GetRegister(instructions[i].Register) % GetRegister(instructions[i].Value);

						SetRegister(instructions[i].Register, val);
						break;
					case "rcv":
						if (GetRegister(instructions[i].Register) != 0 && firstReceive == 0)
						{
							firstReceive = lastSoundPlayed;
							i = instructions.Length;
						}
						break;
					case "jgz":
						if (GetRegister(instructions[i].Register) > 0)
							if (Convert.ToInt32(instructions[i].Value) < 0)
								i += Convert.ToInt32(instructions[i].Value) - 1;
							else
								i += Convert.ToInt32(instructions[i].Value);
						break;
				}
			}
			
			return firstReceive;
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
			var input = File.ReadAllLines(@"Input\Day18.txt");
			List<Instruction> instructions = new List<Instruction>();
			for (int i = 0; i < input.Length; i++)
			{
				var arr = input[i].Split(' ');
				instructions.Add(new Instruction()
				{
					Code = arr[0],
					Register = arr[1],
					Value = arr.Length > 2 ? arr[2] : ""
				});
			}

			var p0 = new DuetProgram(instructions);
			var p1 = new DuetProgram(instructions);

			p1.Registers['p'] = 1;

			var p1SendCount = 0;

			while (true)
			{
				p0.Execute();
				p1.InputQueue = p0.OutputQueue;
				p0.OutputQueue = new List<long>();
				p1.Execute();
				p0.InputQueue = p1.OutputQueue;
				p1SendCount += p1.OutputQueue.Count;
				p1.OutputQueue = new List<long>();

				if (p0.InputQueue.Count == 0 && p1.InputQueue.Count == 0)
				{
					return p1SendCount;
				}
			}

			return 0;
		}
	}

	public class Instruction
	{
		public string Code;
		public string Register;
		public string Value;
	}

	public class DuetProgram
	{
		public List<long> OutputQueue { get; set; }
		public List<long> InputQueue { get; set; }
		public List<Instruction> Instructions { get; set; }
		public int InstructionPointer { get; set; }
		public Dictionary<char, long> Registers { get; set; }

		public DuetProgram(List<Instruction> instructions)
		{
			Instructions = instructions;
			OutputQueue = new List<long>();
			InputQueue = new List<long>();
			InstructionPointer = 0;
			Registers = new Dictionary<char, long>();

			for (var i = 'a'; i <= 'z'; i++)
			{
				Registers.Add(i, 0);
			}
		}

		private long GetRegister(char value)
		{
			if (Registers.ContainsKey(value))
			{
				return Registers[value];
			}
			return 0;
		}

		public void Execute()
		{
			while (true)
			{
				if (InstructionPointer >= Instructions.Count)
				{
					return;
				}

				var instruction = Instructions[InstructionPointer++];

				var command = instruction.Code;

				long num = 0;
				long val = 0;

				switch (command)
				{
					case "snd":
						OutputQueue.Add(GetRegister(instruction.Register[0]));
						break;
					case "set":
						if (Int64.TryParse(instruction.Value, out num))
							val = num;
						else
							val = GetRegister(instruction.Value[0]);

						Registers[instruction.Register[0]] = val;
						break;
					case "add":
						if (Int64.TryParse(instruction.Value, out num))
							val = GetRegister(instruction.Register[0]) + num;
						else
							val = GetRegister(instruction.Register[0]) + GetRegister(instruction.Value[0]);

						Registers[instruction.Register[0]] = val;
						break;
					case "mul":
						if (Int64.TryParse(instruction.Value, out num))
							val = GetRegister(instruction.Register[0]) * num;
						else
							val = GetRegister(instruction.Register[0]) * GetRegister(instruction.Value[0]);

						Registers[instruction.Register[0]] = val;
						break;
					case "mod":
						if (Int64.TryParse(instruction.Value, out num))
							val = GetRegister(instruction.Register[0]) % num;
						else
							val = GetRegister(instruction.Register[0]) % GetRegister(instruction.Value[0]);

						Registers[instruction.Register[0]] = val;

						break;
					case "rcv":
						if (InputQueue.Count > 0)
						{
							Registers[instruction.Register[0]] = InputQueue.First();
							InputQueue.RemoveAt(0);
						}
						else
						{
							InstructionPointer--;
							return;
						}

						break;
					case "jgz":
						if (Int64.TryParse(instruction.Register, out num))
							val = num;
						else
							val = GetRegister(instruction.Register[0]);

						if (val > 0)
						{
							if (Int64.TryParse(instruction.Value, out num))
								val = num;
							else
								val = GetRegister(instruction.Value[0]);

							var jumpCount = val;

							InstructionPointer--;
							InstructionPointer += (int) jumpCount;
						}

						break;
				}
			}
		}
	}
}
