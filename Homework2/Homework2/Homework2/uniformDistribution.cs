using System;
using System.Collections.Generic;

class UniformDistribution
{
	public void UniformDistrib()
	{
		int N = 100000; // Number of random variates
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

        for (int i = 0; i < k; i++)
        {
            double lowerBound = i / (double)k;
            double upperBound = (i + 1) / (double)k;
            int count = intervalCounts[i];
            Console.WriteLine($"[{lowerBound:F2} - {upperBound:F2}): {count}");
        }
    }
}
