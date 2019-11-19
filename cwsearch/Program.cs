using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwsearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //a star lists
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            //graph representation
            var caves = FileReader.ReadFile("input3.cav");

            var start = caves[0];

            var finish = caves[caves.Count - 1];

            foreach (var n in caves)
            {
                n.CalcH(finish);
            }
            openList.Add(start);

            //Astar begins
            while (openList.Count != 0)
            {
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
                            v.CalcG(curr);
                            openList.Add(v);
                            openList = openList.OrderBy(x => x.F).ToList<Node>();
                        }
                        else if (openList.Contains(v))
                        {

                        }
                    }
                }

            }
            if (!closedList.Contains(finish))
            {
                Console.Write("No path");
            }
            else
            {
                Node pathNode = closedList[closedList.IndexOf(finish)];
                while (pathNode.Parent != null)
                {
                    Console.Write(pathNode.Cavern + " ");
                    pathNode = pathNode.Parent;
                }
                Console.Write(start.Cavern);
            }
            Console.ReadLine();
        }
    }
}
