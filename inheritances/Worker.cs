using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritances
{
    abstract class Worker
    {
        public abstract void Print();
    }

    class President : Worker
    {
        public override void Print() => Console.WriteLine("I am the President.");
    }

    class Security : Worker
    {
        public override void Print() => Console.WriteLine("I ensure safety.");
    }

    class Manager : Worker
    {
        public override void Print() => Console.WriteLine("I manage the team.");
    }

    class Engineer : Worker
    {
        public override void Print() => Console.WriteLine("I design and build things.");
    }
}
