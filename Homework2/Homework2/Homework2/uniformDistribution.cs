using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		int N = 1000; // Number of random variates
		int k = 10;   // Number of intervals

		Random random = new Random();
		List<double> randomVariates = new List<double>();

		// Generate N uniform random variates in [0, 1)
		for (int i = 0; i < N; i++)
		{
			double variate = random.NextDouble(); // Random number between 0 and 1
			randomVariates.Add(variate);
		}

		// Determine the distribution into class intervals
		int[] intervalCounts = new int[k];

		foreach (var variate in randomVariates)
		{
			int intervalIndex = (int)(variate * k);
			intervalCounts[intervalIndex]++;
		}

		// Display the distribution
		for (int i = 0; i < k; i++)
		{
			double intervalStart = i / (double)k;
			double intervalEnd = (i + 1) / (double)k;
			int count = intervalCounts[i];

			Console.WriteLine($"Interval [{intervalStart:F2}, {intervalEnd:F2}): Count = {count}");
		}
	}
}
