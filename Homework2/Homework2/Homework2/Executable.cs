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


            Frequency freq = new Frequency();


            string filePath = "C:\\Users\\Lorenzo\\Downloads\\ProfessionalLife.tsv";
            string[][] matrix = freq.TsvToMatrix(filePath);

            UniformDistribution unif = new UniformDistribution();
            JoinDistribution join = new JoinDistribution(matrix,matrix.GetLength(0),matrix[0].Length);
            

            //freq.QuantitativeDiscreteFreq(matrix);

            //freq.QuantitativeContinuousFreq(matrix);

            //freq.QualitativeFreq(matrix);

            unif.UniformDistrib();

            join.printDistribution();

        }

    }
}