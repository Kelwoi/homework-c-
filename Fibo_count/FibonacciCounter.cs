using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibo_count
{
    internal class FibonacciCounter
    {
        private int n1 = 0;
        private int n2 = 1;
        private int evenCount = 0;

        private readonly object locker = new();

        public void CalculateNext(string threadName)
        {
            lock (locker)
            {
                int next = n1 + n2;

                if (next % 2 == 0)
                    evenCount++;

                n1 = n2;
                n2 = next;

                Console.WriteLine($"[{threadName}] n1: {n1}, n2: {n2}, evenCount: {evenCount}");
            }
        }

    }
}
