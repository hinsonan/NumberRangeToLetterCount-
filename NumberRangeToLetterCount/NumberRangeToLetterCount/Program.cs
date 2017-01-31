using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRangeToLetterCount
{
    class Program
    {
        //this function will make an array of ints based on the min and max
        private static int[] createIntArray(int min, int max)
        {
            //size of the array needs to be max - min + 1
            int arraySize = (max - min) + 1;
            //initialize array
            int[] intArray = new int[arraySize];
            //puts all the values from min to max in the array
            for (int i = 0; i < arraySize; i++)
            {
                intArray[i] = min + i;
            }
            return intArray;
        }
        static void Main(string[] args)
        {
            //get min and max values to calculate
            Console.Write("Enter min: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Enter max: ");
            int max = int.Parse(Console.ReadLine());

            //create an array that will hold all the ints from min to max
            int[] intArray = createIntArray(min, max);

            
        }
    }
}
