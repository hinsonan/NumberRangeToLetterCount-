using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRangeToLetterCount
{

    class Program
    {

        static void Main(string[] args)
        {
            int min;
            int max;

            Console.WriteLine("Please enter numbers between -100,000 and 100,000");

            do
            {
                //get min and max values to calculate
                Console.Write("Enter min: ");
                 min = int.Parse(Console.ReadLine());

                Console.Write("Enter max: ");
                 max = int.Parse(Console.ReadLine());

                //validates that the user inputs the correct number
            } while ((min < -100000) || (max > 100000) || min > max);

            //calls the function that will do all the work to output the result
            NRtLC(min, max);
            Console.ReadKey();

        }

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






        //convert number to word
        public static string NumberToWords(int number)
        {
           
            //when the number is 0 make its word value zero
            if (number == 0)
                return "zero";
            //when the number is neative put a negative word
            if (number < 0)
                return "negative" + NumberToWords(Math.Abs(number));

            string words = "";
            //these next block of if statments will divide a number then call the function against the divided number
            //then it gives the remainder and keeps going down the if statements and calling the function over until the number is converted to words
            // will diveide the number by 1,000,000 if the number is above a million
            //now since the user can't enter a number higher than 100,000 this first statement wont be called but if we need to tweak the number range we can
            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + "million";
                number %= 1000000;
            }
            //will dive the number by 1000 if possible
            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + "thousand";
                number %= 1000;
            }
            //will divide the number by 100 if possible
            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + "hundred";
                number %= 100;
            }
            //if the number is above zero at this point then the words are special cases so we will make an array for them
            if (number > 0)
            {
                
                //creates string array for the special cases for 0-19
                var units = new[] { "zero", "one", "two", "three", "four", "five", "six",
                    "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen",
                    "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

                //creates string array for the special cases of tens
                var tens = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty",
                    "seventy", "eighty", "ninety" };

                //when the number is below 20 it will fall into one of the special cases array
                if (number < 20)
                    words += units[number];
                else
                {
                    words += tens[number / 10];
                    if ((number % 10) > 0)
                        words += units[number % 10];
                }
            }

            return words;
        }

        private static void NRtLC(int min, int max)
        {

            //create an array that will hold all the ints from min to max
            int[] intArray = createIntArray(min, max);

            //for each number in the array display the word for that number and put that in numberWords array
            string[] numberWords = new string[(max - min) + 1];

            for (int i = 0; i < intArray.Length; i++)
            {
                numberWords[i] = NumberToWords(intArray[i]);
            }



            ulong wordToNumberCount = 0;
            for (int m = 0; m < numberWords.Length; m++)
            {

                wordToNumberCount += (ulong)numberWords[m].Length;
            }

            Console.WriteLine("Number to Letter Count: " + wordToNumberCount);




        }

    }
}
