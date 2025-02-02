using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace vector_home
{
    public class MyVector
    {
        public double x { get; set; }
        public double y { get; set; }

        MyVector() { }
        public MyVector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double Length()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        public void print()
        {
            Console.WriteLine($"X: {this.x}\nY: {this.y}");
        }

        public static MyVector operator +(MyVector a, MyVector b)
        {
            return new MyVector(a.x + b.x, a.y + b.y);
        }
        public static MyVector operator -(MyVector a, MyVector b)
        {
            return new MyVector(a.x - b.x, a.y - b.y);
        }
        public static MyVector operator *(MyVector a, int num)
        {
            return new MyVector(a.y * num, a.x * num);
        }
        public static double operator *(MyVector a, MyVector b)
        {
            return (a.x * a.y + b.x * b.y);
        }
        public static bool operator ==(MyVector a, MyVector b)
        {
            if (a.x == b.x && a.y == b.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(MyVector a, MyVector b)
        {
            if (a.x == b.x && a.y == b.y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static explicit operator double(MyVector a)
        {
            return a.Length();
        }
        public static implicit operator MyVector(double d)
        {
            return new MyVector { x = d, y = 0 };
        }

        public static MyVector operator ++(MyVector a)
        {
            return new MyVector(++a.x, ++a.y);
        }
        public static MyVector operator --(MyVector a)
        {
            return new MyVector(--a.x, --a.y);
        }
        public static MyVector operator -(MyVector a)
        {
            return new MyVector(-a.x, -a.y);
        }

        public static bool operator true(MyVector a)
        {
            return a.x != 0 || a.y != 0;
        }
        public static bool operator false(MyVector a)
        {
            return a.x == 0 && a.y == 0;

        }
        public double this[int index]
        {
            get
            {
                if (index == 0)
                    return x;
                else if (index == 1)
                    return y;
                else
                    Console.WriteLine("Index must be 1 or 0");
                return -1;
            }
            set
            {
                if (index == 0)
                    x = value;
                else if (index == 1)
                    y = value;
                else
                    Console.WriteLine("Index must be 1 or 0");
                
            }
        }
    }
    
}

    

    


