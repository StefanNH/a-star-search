using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwsearch
{
    public static class FileReader
    {
        public static List<Node> ReadFile(string inFile)
        {
            int caveNumbers = 1;
            List<Node> _caves = new List<Node>();
            List<int> input = new List<int>();

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
            int[] toConvert = new List<int>(input).GetRange((n2 + 1), n * n).ToArray();

            for (int i = 1; i <= n2; i += 2)
            {
                Node node = new Node(caveNumbers, input[i], input[i + 1]);
                _caves.Add(node);
                caveNumbers++;
            }

            for (int k = 0; k < n; k++)
            {
                for (int f = 0; f < n; f++)
                {
                    if(toConvert[f * n + k] == 1)
                    {
                        _caves[k].AddAdjecency(_caves[f]);
                    }
                    
                }
            }
            return _caves;
        }
    }
}
