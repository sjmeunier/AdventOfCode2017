using System.Collections.Generic;
using System.IO;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Schema;

namespace AdventOfCode
{
	public class Day13
	{
		public static int Problem1()
		{
			var input = File.ReadAllLines(@"Input\Day13.txt");

			Dictionary<int, int> values = new Dictionary<int, int>();
			foreach (var line in input)
			{
				var arr = line.Split(": ");
				values.Add(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]));
			}
			int weight = 0;
			foreach (var value in values)
			{
				var zeroPos = (value.Value - 1) * 2;
				if (value.Key % zeroPos == 0)
					weight += value.Key * value.Value;
			}

			return weight;
		}


		public static int Problem2()
		{
			var input = File.ReadAllLines(@"Input\Day13.txt");

			Dictionary<int, int> values = new Dictionary<int, int>();
			foreach (var line in input)
			{
				var arr = line.Split(": ");
				values.Add(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]));
			}
			
			bool caught = true;
			int delay = 0;
			while (caught)
			{
				int weight = 0;
				foreach (var value in values)
				{
					var zeroPos = (value.Value - 1) * 2;
					if ((value.Key + delay) % zeroPos == 0)
					{
						weight += 1;
						break;
					}
				}
				if (weight > 0)
					delay++;
				else caught = false;
			}
			return delay;
		}

	}
}
