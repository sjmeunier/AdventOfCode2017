using System.Collections.Generic;
using System.IO;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

namespace AdventOfCode
{
	public class Day17
	{
		public static int Problem1()
		{
			List<int> buffer = new List<int>();
			buffer.Add(0);
			int maxSteps = 2017;
			int stepSize = 370;
			int currentIndex = 0;
			for (int i = 1; i <= maxSteps; i++)
			{
				currentIndex = (currentIndex + stepSize) % buffer.Count + 1;
				buffer.Insert(currentIndex, i);
			}
			var value = buffer[(currentIndex + 1) % buffer.Count];
			return value;
		}

		public static int Problem2()
		{
			int maxSteps = 50000000;
			int stepSize = 370;
			int currentIndex = 0;
			int[] buffer = new int[maxSteps + 1];
			int bufferSize = 1;
			buffer[0] = 0;
			for (int i = 1; i <= maxSteps; i++)
			{
				if (i % 1000000 == 0)
					Console.Write(".");
				currentIndex = (currentIndex + stepSize) % bufferSize + 1;
				bufferSize += 1;
				if (currentIndex == 1)
					buffer[currentIndex] = i;
			}
			var value = buffer[1];
			return value;
		}
	}
}
