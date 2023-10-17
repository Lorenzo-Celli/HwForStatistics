﻿using System;
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
                }
            }

            foreach (var kvp in absoluteFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");

            //relative frequency
            Dictionary<string, double> relativeFreq = new Dictionary<string, double>();
            foreach (KeyValuePair<string, int> entry in absoluteFreq)
            {
                relativeFreq.Add(entry.Key, (double)entry.Value/(numRows-1));
            }

            foreach (var kvp in relativeFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\n");

            //percentage frequency
            Dictionary<string, double> percFreq = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> entry in relativeFreq)
            {
                percFreq.Add(entry.Key, (entry.Value*100));
            }

            foreach (var kvp in percFreq)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

        }

    }
}
