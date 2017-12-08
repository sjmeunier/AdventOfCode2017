using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace AdventOfCode
{
	public class Day7
	{
		public static string Problem1()
		{
			string[] lines = File.ReadAllLines(@"Input\Day7.txt");
			HashSet<string> children = new HashSet<string>();
			List<string> items = new List<string>();

			string rootItem = "";
			foreach (var line in lines)
			{
				var lineBaseSplit = line.Split("->");
				var itemPart = lineBaseSplit[0].Trim().Split(' ');
				items.Add(itemPart[0]);

				if (lineBaseSplit.Length > 1)
				{
					var childrenPart = lineBaseSplit[1].Trim().Split(',');
					foreach (var part in childrenPart)
					{
						if (!children.Contains(part.Trim()))
							children.Add(part.Trim());
					}
				}
			}

			foreach (var item in items)
			{
				if (!children.Contains(item))
				{
					rootItem = item;
					break;
				}
			}

			return rootItem;
		}

		private class Item
		{
			public string Name;
			public List<string> Children;
			public int Weight;
		}


		static Dictionary<string, Item> items = new Dictionary<string, Item>();

		public static int Problem2()
		{
			items = new Dictionary<string, Item>();
			string[] lines = File.ReadAllLines(@"Input\Day7.txt");
			HashSet<string> children = new HashSet<string>();

			foreach (var line in lines)
			{
				var lineBaseSplit = line.Split("->");
				var itemPart = lineBaseSplit[0].Trim().Split(' ');
				var item = new Item();
				item.Name = itemPart[0];
				item.Weight = Convert.ToInt32(itemPart[1].Substring(1, itemPart[1].Length - 2));
				item.Children = new List<string>();
				if (lineBaseSplit.Length > 1)
				{
					var childrenPart = lineBaseSplit[1].Trim().Split(',');
					foreach (var part in childrenPart)
					{
						item.Children.Add(part.Trim());
						if (!children.Contains(part.Trim()))
							children.Add(part.Trim());
					}
				}
				items.Add(item.Name, item);
			}
			Item rootItem = null;
			foreach (var item in items.Values)
			{
				if (!children.Contains(item.Name))
				{
					rootItem = item;
					break;
				}
			}

			CheckWeight(rootItem);


			return adjustedWeight;
		}

		private static int adjustedWeight = 0;
		private static bool errorFound = false;

		private static int CheckWeight(Item item)
		{
			if (errorFound)
				return 0;

			List<int> weights = new List<int>();
			int incorrectIndex = -1;
			int validWeight = 0;
			int invalidWeight = 0;

			if (!errorFound)
			{
				foreach (var child in item.Children)
				{
					weights.Add(CheckWeight(items[child]));
				}
				if (weights.Distinct().Count() > 1)
				{
					errorFound = true;
					int i = 0;
					foreach (var weight in weights)
					{
						if (weights.Count(x => x == weight) == 1)
						{
							incorrectIndex = i;
							invalidWeight = weight;
						}
						else
						{
							validWeight = weight;
						}
						i++;
					}
					
				}
			}
			if (errorFound && adjustedWeight == 0)
			{
				Item child = items[item.Children[incorrectIndex]];
				adjustedWeight = child.Weight + validWeight - invalidWeight;

			}
			int totalWeight = item.Weight;
			foreach (var weight in weights)
				totalWeight += weight;
			return totalWeight;
		}

		private static int GetCombinedChildrenWeight(Item item)
		{
			int weight = 0;
			foreach (var child in item.Children)
			{
				weight += GetCombinedChildrenWeight(items[child]);
			}

			return weight;
		}
	}
}
