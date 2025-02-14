using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritances
{
    internal class Money
    {
        public int WholePart { get; set; }
        public int Cents { get; set; }

        public Money(int wholePart, int cents)
        {
            WholePart = wholePart;
            Cents = cents;
        }

        public void Display()
        {
            Console.WriteLine($"Amount: {WholePart}.{Cents}");
        }
    }

    class Product : Money
    {
        public string Name { get; set; }

        public Product(string name, int wholePart, int cents) : base(wholePart, cents)
        {
            Name = name;
        }

        public void ReducePrice(int wholePart, int cents)
        {
            WholePart -= wholePart;
            Cents -= cents;
            if (Cents < 0)
            {
                WholePart--;
                Cents += 100;
            }
        }
    }
}
