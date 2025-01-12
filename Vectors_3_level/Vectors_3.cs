using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Vectors_3_level
{
    struct Vectors_3
    {

        public int X,Y,Z;
        public Vectors_3(int x,int y, int z) {
            X = x;
            Y = y;
            Z = z;
        }
        public Vectors_3 multiplication(int value)
        {
            Vectors_3 res = new Vectors_3(X*value,Y *value,Z *value);
            return res;
        }
        public Vectors_3 plus (Vectors_3 value)
        {

            return new Vectors_3(this.X + value.X, this.Y + value.Y, this.Z + value.Z);
        }
        public Vectors_3 minus(Vectors_3 value) {
            return new Vectors_3(this.X - value.X, this.Y - value.Y, this.Z - value.Z);
        }

        public void Show()
        {
            Console.WriteLine($"X :: {X}");
            Console.WriteLine($"Y :: {Y}");
            Console.WriteLine($"Z :: {Z}");
        }
    }
   
}
