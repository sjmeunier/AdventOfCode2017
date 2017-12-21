using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace AdventOfCode
{
	public class Day20
	{
		public class Particle
		{
			public int id;
			public long pX;
			public long pY;
			public long pZ;
			public long vX;
			public long vY;
			public long vZ;
			public long aX;
			public long aY;
			public long aZ;
		}

		public static int Problem1()
		{
			var input = File.ReadAllLines(@"Input\Day20.txt");
			List<Particle> particles = new List<Particle>();
			foreach (var line in input)
			{
				var arr = line.Split(", ");
				Particle particle = new Particle();

				var p = arr[0].Substring(3, arr[0].Length - 4).Split(",");
				particle.pX = Convert.ToInt64(p[0]);
				particle.pY = Convert.ToInt64(p[1]);
				particle.pZ = Convert.ToInt64(p[2]);

				var v = arr[1].Substring(3, arr[1].Length - 4).Split(",");
				particle.vX = Convert.ToInt64(v[0]);
				particle.vY = Convert.ToInt64(v[1]);
				particle.vZ = Convert.ToInt64(v[2]);

				var a = arr[2].Substring(3, arr[2].Length - 4).Split(",");
				particle.aX = Convert.ToInt64(a[0]);
				particle.aY = Convert.ToInt64(a[1]);
				particle.aZ = Convert.ToInt64(a[2]);
				particles.Add(particle);
			}

			int closest = 0;
			long closestDistance = Int64.MaxValue;

			for (int i = 0; i < particles.Count; i++)
			{
				var distance = Math.Abs(particles[i].aX) + Math.Abs(particles[i].aY) + Math.Abs(particles[i].aZ);
				if (distance < closestDistance)
				{
					closest = i;
					closestDistance = distance;
				}
			}
			return closest;
		}

		public static int Problem2()
		{
			var input = File.ReadAllLines(@"Input\Day20.txt");
			List<Particle> particles = new List<Particle>();
			int id = 0;
			foreach (var line in input)
			{
				var arr = line.Split(", ");
				Particle particle = new Particle();
				particle.id = id;
				var p = arr[0].Substring(3, arr[0].Length - 4).Split(",");
				particle.pX = Convert.ToInt64(p[0]);
				particle.pY = Convert.ToInt64(p[1]);
				particle.pZ = Convert.ToInt64(p[2]);

				var v = arr[1].Substring(3, arr[1].Length - 4).Split(",");
				particle.vX = Convert.ToInt64(v[0]);
				particle.vY = Convert.ToInt64(v[1]);
				particle.vZ = Convert.ToInt64(v[2]);

				var a = arr[2].Substring(3, arr[2].Length - 4).Split(",");
				particle.aX = Convert.ToInt64(a[0]);
				particle.aY = Convert.ToInt64(a[1]);
				particle.aZ = Convert.ToInt64(a[2]);
				particles.Add(particle);
				id++;
			}

			for (int k = 0; k < 1000; k++)
			{
				if (k % 100 == 0)
					Console.Write(".");

				HashSet<int> collisions = new HashSet<int>();
				for (int i = 0; i < particles.Count; i++)
				{
					if (particles.Any(x =>
						x.id != particles[i].id && x.pX == particles[i].pX && x.pY == particles[i].pY && x.pZ == particles[i].pZ))
					{
						collisions.Add(particles[i].id);
					}
				}

				foreach (var collision in collisions)
				{
					particles.Remove(particles.First(x => x.id == collision));
				}


				for (int i = 0; i < particles.Count; i++)
				{
					particles[i].vX += particles[i].aX;
					particles[i].vY += particles[i].aY;
					particles[i].vZ += particles[i].aZ;

					particles[i].pX += particles[i].vX;
					particles[i].pY += particles[i].vY;
					particles[i].pZ += particles[i].vZ;
				}
			}

			int count = particles.Count;
			return count;

		}
	}
}
