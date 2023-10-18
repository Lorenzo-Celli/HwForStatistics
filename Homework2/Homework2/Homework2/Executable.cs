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
    internal class Executable
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Lorenzo\\Downloads\\ProfessionalLife.tsv";

            Frequency freq = new Frequency();
            UniformDistribution unif = new UniformDistribution();
            
            //string[][] matrix = freq.TsvToMatrix(filePath);

            //freq.QuantitativeDiscreteFreq(matrix);

            //freq.QuantitativeContinuousFreq(matrix);

            //freq.QualitativeFreq(matrix);

            unif.UniformDistrib();


        }

    }
}