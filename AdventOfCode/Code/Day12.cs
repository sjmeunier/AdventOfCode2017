using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace AdventOfCode
{
	public class Day12
	{
		public static int Problem1()
		{
			string[] lines = File.ReadAllLines(@"Input\Day12.txt");
			List<HashSet<int>> grouped = new List<HashSet<int>>();

			for (int i = 0; i < lines.Length; i++)
			{
				var lineParts = lines[i].Split(" <-> ");
				var linked = lineParts[1].Split(", ");
				HashSet<int> group = new HashSet<int>();
				group.Add(Convert.ToInt32(lineParts[0]));
				foreach (var item in linked)
					group.Add(Convert.ToInt32(item));
				grouped.Add(group);

			}

			HashSet<int> zero = new HashSet<int>();
			zero.Add(0);
			
			for (int i = 0; i < grouped.Count; i++)
			{
				foreach (var group in grouped)
				{
					if (group.Overlaps(zero))
						zero.UnionWith(group);
				}
			}
			
			int length = zero.Count;
			return length;
		}

		public static int Problem2()
		{
			string[] lines = File.ReadAllLines(@"Input\Day12.txt");
			Dictionary<int, HashSet<int>> ungrouped = new Dictionary<int, HashSet<int>>();

			for (int i = 0; i < lines.Length; i++)
			{
				var lineParts = lines[i].Split(" <-> ");
				var linked = lineParts[1].Split(", ");
				HashSet<int> group = new HashSet<int>();
				group.Add(Convert.ToInt32(lineParts[0]));
				foreach (var item in linked)
					group.Add(Convert.ToInt32(item));
				ungrouped.Add(Convert.ToInt32(lineParts[0]), group);

			}

			List<HashSet<int>> grouped = new List<HashSet<int>>();
			while (ungrouped.Count > 0)
			{
				HashSet<int> group = new HashSet<int>();
				int key = ungrouped.Keys.First();
				group.Add(key);
				ungrouped.Remove(key);
				List<int> processedKeys = new List<int>();

				//int max = ungrouped.Count
				for (int i = 0; i < ungrouped.Count; i++)
				{
					foreach (var ungroup in ungrouped)
					{
						if (ungroup.Value.Overlaps(group))
						{
							group.UnionWith(ungroup.Value);
							processedKeys.Add(ungroup.Key);
						}
					}

				}
				grouped.Add(group);
				foreach (var k in processedKeys)
					ungrouped.Remove(k);
			}
			int length = grouped.Count;
			return length;
		}
	}
}
