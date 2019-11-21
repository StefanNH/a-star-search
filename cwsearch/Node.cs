using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwsearch
{
    public class Node
    {
        private int _cavern;
        private int _x;
        private int _y;
        private double _g;
        private double _h;
        private double _f;
        private Node _parent;

        private List<Node> _adjecencies = new List<Node>();

        public Node(int cavern, int x, int y)
        {
            Cavern = cavern;
            X = x;
            Y = y;
        }

        public int Cavern { get => _cavern; set => _cavern = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public double G { get => _g; set => _g = value; }
        public double H { get => _h; set => _h = value; }
        public double F { get => _f = this._h + this._g ; set => _f = value; }
        public Node Parent { get => _parent; set => _parent = value; }
        public List<Node> Adjecencies { get => _adjecencies; }

        public void AddAdjecency(Node n)
        {
            this.Adjecencies.Add(n);
        }

        public void CalcG(Node prev)
        {
            this.G = prev.G + (Math.Sqrt(((this.X - prev.X) * (this.X - prev.X)) + ((this.Y - prev.Y) * (this.Y - prev.Y))));
        }

        public double CalculateDist(Node prev)
        {
            return prev.G + (Math.Sqrt(((this.X - prev.X) * (this.X - prev.X)) + ((this.Y - prev.Y) * (this.Y - prev.Y))));
        }

        public void CalcH(Node final)
        {
            this.H = Math.Sqrt(((this.X - final.X) * (this.X - final.X)) + ((this.Y - final.Y) * (this.Y - final.Y)));
        }
        public String PrintStuff()
        {
            return "Cavern " + Cavern + " X " + X + " Y " + Y;
        }
    }
}

