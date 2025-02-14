using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class ArrayProcessor
    {
        
    private int[] array;

        public ArrayProcessor(int[] arr)
        {
            array = arr;
        }


        public int Less(int valueToCompare)
        {
            return array.Count(x => x < valueToCompare);
        }

        public int Greater(int valueToCompare)
        {
            return array.Count(x => x > valueToCompare);
        }


        public void ShowEven()
        {
            Console.WriteLine("Even numbers: " + string.Join(", ", array.Where(x => x % 2 == 0)));
        }

        public void ShowOdd()
        {
            Console.WriteLine("Odd numbers: " + string.Join(", ", array.Where(x => x % 2 != 0)));
        }


        public int CountDistinct()
        {
            return array.Distinct().Count();
        }

        public int EqualToValue(int valueToCompare)
        {
            return array.Count(x => x == valueToCompare);
        }
    }
}
