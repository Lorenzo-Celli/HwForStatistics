using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    internal class Frequency
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Lorenzo\\Downloads\\ProfessionalLife.tsv";

            string[][] matrix = TsvToMatrix(filePath);

            QuantitativeDiscreteFreq(matrix);

            QuantitativeContinuousFreq(matrix);

            QualitativeFreq(matrix);

        }

        static string[][] TsvToMatrix(string filePath)
        {

                    //read TSV rows
                    string[] lines = File.ReadAllLines(filePath);

                    //compute number of colums
                    int maxColumns = 0;
                    foreach (string line in lines)
                    {
                        string[] columns = line.Split('\t');
                        if (columns.Length > maxColumns)
                        {
                            maxColumns = columns.Length;
                        }
                    }

                    string[][] matrix = new string[lines.Length][];
                    for (int i = 0; i < lines.Length; i++)
                    {
                        matrix[i] = new string[maxColumns];
                    }

                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] columns = lines[i].Split('\t');
                        for (int j = 0; j < columns.Length; j++)
                        {
                            matrix[i][j] = columns[j];
                        }
                    }

                    return matrix;

         
        }

        static void QuantitativeDiscreteFreq(string[][] dataSet)
        {
            //absolute frequency
            Dictionary<string, int> absoluteFreq = new Dictionary<string, int>();
            int numRows = dataSet.GetLength(0);
            int numCols = dataSet[0].Length;


            for (int i = 0; i < numCols; i++)
            {
                if (dataSet[0][i] == "Ambitious (0-5)")
                {
                    for (int j=1; j < numRows; j++)
                    {
                        try
                        {
                            absoluteFreq.Add(dataSet[j][i],1);
                        }
                        catch (ArgumentException)
                        {
                            absoluteFreq[dataSet[j][i]] += 1;
                        }
                    }

                    if (absoluteFreq != null) break;
                }
            }

            //print output
            Console.WriteLine("ABSOLUTE FREQUENCY:");
            foreach (var kvp in absoluteFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");

            //relative frequency
            Console.WriteLine("RELATIVE FREQUENCY:");
            Dictionary<string, double> relativeFreq = new Dictionary<string, double>();
            foreach (KeyValuePair<string, int> entry in absoluteFreq)
            {
                relativeFreq.Add(entry.Key, (double)entry.Value/(numRows-1));
            }

            //print output
            foreach (var kvp in relativeFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");

            //percentage frequency
            Console.WriteLine("PERCENTAGE FREQUENCY:");
            Dictionary<string, double> percFreq = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> entry in relativeFreq)
            {
                percFreq.Add(entry.Key, (entry.Value*100));
            }

            //print output
            foreach (var kvp in percFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");

        }

        static void QuantitativeContinuousFreq(string[][] dataSet)
        {
            //absolute frequency
            SortedSet<int> tmp = new SortedSet<int>();
            Dictionary<string, int> absoluteFreq = new Dictionary<string, int>();
            int numRows = dataSet.GetLength(0);
            int numCols = dataSet[0].Length;
            int blankRows = 0;

            for (int i = 0; i < numCols; i++)
            {
                if (dataSet[0][i] == "weight")
                {
                    
                    for (int j = 1; j < numRows; j++)
                    {
                        try
                        {
                            tmp.Add(int.Parse(dataSet[j][i]));
                        }
                        catch (FormatException)
                        {
                            blankRows++;
                        }
                    }
                    if (tmp != null) break;
                }


            }
            absoluteFreq = CountOccurrencesInIntervals(tmp, 5);
            absoluteFreq.Add("blank Rows", blankRows);

            Console.WriteLine("ABSOLUTE FREQUENCY:");
            foreach (var kvp in absoluteFreq)
            {
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            }

            //relative frequency
            Console.WriteLine("RELATIVE FREQUENCY:");
            Dictionary<string, double> relativeFreq = new Dictionary<string, double>();
            foreach (KeyValuePair<string, int> entry in absoluteFreq)
            {
                relativeFreq.Add(entry.Key, (double)entry.Value / (numRows - 1));
            }
            Console.WriteLine("\n");

            //print output
            foreach (var kvp in relativeFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");

            //percentage frequency
            Console.WriteLine("PERCENTAGE FREQUENCY:");
            Dictionary<string, double> percFreq = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> entry in relativeFreq)
            {
                percFreq.Add(entry.Key, (entry.Value * 100));
            }

            //print output
            foreach (var kvp in percFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

        }
        static Dictionary<string, int> CountOccurrencesInIntervals(SortedSet<int> set, int numberOfIntervals)
        {
            if (set.Count == 0)
                return new Dictionary<string, int>();

            int minValue = set.Min();
            int maxValue = set.Max();

            int intervalSize = (maxValue - minValue) / numberOfIntervals;

            Dictionary<string, int> intervalDictionary = new Dictionary<string, int>();

            for (int i = 0; i < numberOfIntervals; i++)
            {
                int lowerBound = minValue + i * intervalSize;
                int upperBound = minValue + (i + 1) * intervalSize;

                string intervalKey = $"{lowerBound} - {upperBound}";
                int occurrences = set.GetViewBetween(lowerBound, upperBound).Count;

                intervalDictionary.Add(intervalKey, occurrences);
            }

            // Include the values that are greater than the last interval's upper bound
            string lastIntervalKey = $"{minValue + (numberOfIntervals - 1) * intervalSize} - {maxValue}";
            int occurrencesInLastInterval = set.GetViewBetween(minValue + (numberOfIntervals - 1) * intervalSize, maxValue).Count;
            intervalDictionary[lastIntervalKey] = occurrencesInLastInterval;

            return intervalDictionary;
        }

        static void QualitativeFreq(string[][] dataSet)
        {

            Dictionary<string, int> absoluteFreq = new Dictionary<string, int>();
            int numRows = dataSet.GetLength(0);
            int numCols = dataSet[0].Length;


            for (int i = 0; i < numCols; i++)
            {
                if (dataSet[0][i] == "Programming Languages")
                {
                    for (int j = 1; j < numRows; j++)
                    {
                        string[] words = dataSet[j][i].Split(',');

                        foreach (string word in words)
                        {
                            string cleanedWord = word.Trim();
                            if (!absoluteFreq.ContainsKey(cleanedWord))
                            {
                                absoluteFreq[cleanedWord] = 1;
                            }
                            else
                            {
                                absoluteFreq[cleanedWord]++;
                            }
                        }
                    }

                    if (absoluteFreq != null) break;
                }
            }

            Console.WriteLine("ABSOLUTE FREQUENCY:");
            foreach (var kvp in absoluteFreq)
            {
                Console.WriteLine("Key = {0} , Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");

            //relative frequency
            Console.WriteLine("RELATIVE FREQUENCY:");
            Dictionary<string, double> relativeFreq = new Dictionary<string, double>();
            foreach (KeyValuePair<string, int> entry in absoluteFreq)
            {
                relativeFreq.Add(entry.Key, (double)entry.Value / (numRows - 1));
            }

            //print output
            foreach (var kvp in relativeFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");

            //percentage frequency
            Dictionary<string, double> percFreq = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> entry in relativeFreq)
            {
                percFreq.Add(entry.Key, (entry.Value * 100));
            }

            //print output
            Console.WriteLine("PERCENTAGE FREQUENCY:");
            foreach (var kvp in percFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");

        }

    }
}
