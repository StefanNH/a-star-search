﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwsearch
{
    public class FileReader
    {
        public static List<Node> ReadFile(string inFile)
        {
            int caveNumbers = 1;
            List<Node> _caves = new List<Node>();
            List<int> input = new List<int>();
            List<int> toConvert = new List<int>();


            using (StreamReader reader = File.OpenText(inFile))
            {
                string text = reader.ReadToEnd();
                string[] bits = text.Split(',');
                foreach (var a in bits)
                {
                    var x = int.Parse(a);
                    input.Add(x);
                }
            }

            int n = input[0];
            int n2 = n * 2;
            int[,] adjMatrix = new int[n, n];

            for (int f = n2 + 1; f < input.ToArray().Length; f++)
            {
                toConvert.Add(input[f]);
            }

            var arrToConvert = toConvert.ToArray();

            for (int k = 0; k < arrToConvert.Length; k++)
            {
                Buffer.BlockCopy(arrToConvert, 0, adjMatrix, 0, arrToConvert.Length * sizeof(int));
            }

            for (int i = 1; i <= n2; i += 2)
            {
                Node node = new Node(caveNumbers, input[i], input[i + 1]);
                _caves.Add(node);
                caveNumbers++;
            }

            for (int l = 0; l < adjMatrix.GetLength(0); l++)
            {
                for (int o = 0; o < adjMatrix.GetLength(1); o++)
                {
                    if (adjMatrix[l, o] == 1)
                    {
                        _caves[o].AddAdjecency(_caves[l]);
                    }
                }
            }

            return _caves;
        }
    }
}