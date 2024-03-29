﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwsearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string argCav = args[0] + ".cav";
            string fileToWrite = args[0] + ".csn";

            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();
            List<int> path = new List<int>();

            var caves = FileReader.ReadFile(argCav);

            var start = caves[0];

            var finish = caves[caves.Count - 1];

            openList.Add(start);

            while (openList.Count != 0)
            {
                if (closedList.Contains(finish)) { break; }

                Node curr = openList[0];
                openList.Remove(curr);
                closedList.Add(curr);

                if (curr.Adjecencies.Count != 0)
                {
                    foreach (var v in curr.Adjecencies)
                    {
                        if (closedList.Contains(v)) { continue; }
                        if (!openList.Contains(v))
                        {
                            v.Parent = curr;
                            v.CalcH(finish);
                            v.CalcG(curr);
                            openList.Add(v);
                            openList = openList.OrderBy(x => x.F).ToList<Node>();
                        }
                        else if (openList.Contains(v))
                        {
                            double dist = v.CalculateDist(curr);
                            if(dist < openList[openList.IndexOf(v)].G)
                            {
                                openList[openList.IndexOf(v)].G = dist;
                                openList[openList.IndexOf(v)].Parent = curr;
                                openList = openList.OrderBy(x => x.F).ToList<Node>();
                            }
                        }
                    }
                }

            }
            if (!closedList.Contains(finish))
            {
                File.WriteAllText(fileToWrite, "0");
            }
            else
            {
                Node pathNode = closedList[closedList.IndexOf(finish)];
                while (pathNode.Parent != null)
                {
                    path.Add(pathNode.Cavern);
                    pathNode = pathNode.Parent;
                    
                }
                path.Add(start.Cavern);
                path.Reverse();
                string output = string.Join(" ", path);
                File.WriteAllText(fileToWrite, output);
            }
        }
    }
}
