using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bamms6practa
{
    public class Figure
    {
        public Figure() { }
        public Figure(string name, int width, int height)
        {
            this.name = name; this.width = width; this.height = height;
        }
        public string name;
        public int width;
        public int height;
    }
}