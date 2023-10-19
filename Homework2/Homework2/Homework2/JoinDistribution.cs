// Distributions.cs
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace Homework2
{
    public partial class JoinDistribution
    {
        string[][] matrix;
        int numCols;
        int numRows;

        public JoinDistribution(string[][] matrix,int numCols,int numRows)
        {
            this.matrix = matrix;
            this.numCols = numCols;
            this.numRows = numRows;
        }

        public void printDistribution()
        {
            Dictionary<string, int> evalDist = this.evalDistribution();

            foreach (var kvp in evalDist)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");
        }

        // works for multivaried and univaried
        private Dictionary<string, int> evalDistribution()
        {
            Dictionary<string,int> jointDistribution = new Dictionary<string, int>();
            string[] variables = { "Ambitious (0-5)", "Programming Languages" }; //can insert variables multiple than 2  

            int[] varColumns = new int[variables.Length];
            for (int i = 0; i < variables.Length; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (matrix[0][j] == variables[i])
                    {
                        varColumns[i] = j;
                        break;
                    }
                }
            }

            string[][] valuesMatrix = new string[varColumns.Length][];
            string jointValue;

            for (int i = 1; i < numRows; i++)
            {
                valuesMatrix[0] = matrix[i][varColumns[0]].ToLower().Trim('"').Trim(' ').Trim(',').Split(',');
                for (int k = 1; k < varColumns.Length; k++)
                {
                    valuesMatrix[k] = matrix[i][varColumns[k]].ToLower().Trim('"').Trim(' ').Trim(',').Split(',');
                }

                var combinations = CartesianProduct(valuesMatrix);
                foreach (var combination in combinations)
                {
                    jointValue = String.Join(", ", combination);

                    if (!jointDistribution.ContainsKey(jointValue)) jointDistribution[jointValue] = 1;
                    else jointDistribution[jointValue]++;
                }

            }

            return jointDistribution.OrderByDescending(f => f.Value).ToDictionary(f => f.Key, f => f.Value);
        }
        private static IEnumerable<string[]> CartesianProduct(string[][] items)
        {
            string[] currentItem = new string[items.Length];
            return Go(items, currentItem, 0);
        }

        private static IEnumerable<string[]> Go(string[][] items, string[] currentItem, int index)
        {
            if (index == items.Length)
            {
                yield return (string[])currentItem.Clone();
            }
            else
            {
                foreach (string item in items[index])
                {
                    currentItem[index] = item.ToString();
                    foreach (string[] j in Go(items, currentItem, index + 1))
                    {
                        yield return (string[])j.Clone();
                    }
                }
            }
        }
    }
}