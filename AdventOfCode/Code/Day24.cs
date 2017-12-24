
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
	public class Day24
	{
		private class Component
		{
			public int Id;
			public int Port1;
			public int Port2;
		}

		private static List<Component> components;
		private static List<int[]> bridges;
		public static int Problem1()
		{
			bridges = new List<int[]>();
			components = new List<Component>();

			var input = File.ReadAllLines(@"Input\Day24.txt");

			for(int i = 0; i < input.Length; i++)
			{
				var arr = input[i].Split("/");
				components.Add(new Component() { Id = i, Port1 = Convert.ToInt32(arr[0]), Port2 = Convert.ToInt32(arr[1]) });
			}
/*
			foreach(var component in components.Where(x => x.Port1 == 0 || x.Port2 == 0))
			{
				List<int> bridge = new List<int>();
				bridge.Add(component.Id);
				if (component.Port1 == 0)
					GetNextBridge(component.Port2, bridge);
				else
					GetNextBridge(component.Port1, bridge);
			}
			*/
			int max = 0;
			foreach(var bridge in bridges)
			{
				int bridgeSize = 0;
				//Console.WriteLine();
				foreach (var id in bridge) {
					var component = components.Single(x => x.Id == id);
					bridgeSize += component.Port1 + component.Port2;
				//	Console.Write(component.Port1 + "/" + component.Port2 + "--");
				}
				///Console.WriteLine(bridgeSize);
				max = Math.Max(max, bridgeSize);
			}
			return max;
		}

		private static List<int> CloneList(List<int> list)
		{
			List<int> newList = new List<int>();
			foreach (var item in list)
				newList.Add(item);
			return newList;
		}

		private static void GetNextBridge(int port, List<int> bridge)
		{
			if (components.Any(x => (x.Port1 == port || x.Port2 == port) && !bridge.Contains(x.Id)))
			{
				foreach (var component in components.Where(x => (x.Port1 == port || x.Port2 == port) && !bridge.Contains(x.Id)))
				{
					var newBridge = CloneList(bridge);
					newBridge.Add(component.Id);
					if (component.Port1 == port)
					{
						GetNextBridge(component.Port2, newBridge);
					}
					else if (component.Port2 == port)
						GetNextBridge(component.Port1, newBridge);
				}
			}
			else
			{
				bridges.Add(bridge.ToArray());
			}
		}

		public static int Problem2()
		{
			bridges = new List<int[]>();
			components = new List<Component>();

			var input = File.ReadAllLines(@"Input\Day24.txt");

			for (int i = 0; i < input.Length; i++)
			{
				var arr = input[i].Split("/");
				components.Add(new Component() { Id = i, Port1 = Convert.ToInt32(arr[0]), Port2 = Convert.ToInt32(arr[1]) });
			}

			foreach (var component in components.Where(x => x.Port1 == 0 || x.Port2 == 0))
			{
				List<int> bridge = new List<int>();
				bridge.Add(component.Id);
				if (component.Port1 == 0)
					GetNextBridge(component.Port2, bridge);
				else
					GetNextBridge(component.Port1, bridge);
			}

			int longest = 0;
			int longestStrength = 0;
			foreach (var bridge in bridges)
			{
				if (bridge.Length >= longest)
				{
					longest = bridge.Length;
					var bridgeStrength = 0;
					foreach (var id in bridge)
					{
						var component = components.Single(x => x.Id == id);
						bridgeStrength += component.Port1 + component.Port2;
					}
					longestStrength = Math.Max(longestStrength, bridgeStrength);
				}
			}
			return longestStrength;
		}
	}
}
