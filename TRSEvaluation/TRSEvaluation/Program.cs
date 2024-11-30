using System;
using System.Collections.Generic;
using System.Linq;

namespace TRSEvaluation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetMinValue method
            Console.WriteLine(GetMinimumValue(new int[] { -6, 45, 32, 64, -145, 0, 18, 64 }));
            Console.WriteLine(GetMinimumValue(new int[] { 74, -9, 97, 41, -41, 24, 48, 9, -48, -60, -19}));
            Console.WriteLine(GetMinimumValue(new int[] { -1, -17, 30, 52, -34,-64 }));

            //Multiply Method
            Console.WriteLine(Multiply(3));
            Console.WriteLine(Multiply(-1));
            Console.WriteLine(Multiply(2));
            Console.WriteLine(Multiply(0));
            Console.WriteLine(Multiply(61));

            //Average and round method
            Console.WriteLine(AverageAndRound(new int[] { 14, -2, 5, 8, 32, 98, 68 }));
            Console.WriteLine(AverageAndRound(new int[] { 28, -52, 4, 12, 31, 1, -2 }));
            Console.WriteLine(AverageAndRound(new int[] { 15, 18, -42, 6, 12, -1 }));
            Console.WriteLine(AverageAndRound(new int[] { 4, 12, 28, -52, 16, -3 }));

            //Count groups method
            CountGroupings(new string[] { "Chocolate ", "Vanilla", "Cherry", "Vanilla", "Cherry"}).ForEach(x => Console.WriteLine($"Value: {x.Key} occurred {x.Value} times"));
            CountGroupings(new string[] { "Cherry ", "Vanilla", "Cherry", "Vanilla", "Cherry" }).ForEach(x => Console.WriteLine($"Value: {x.Key} occurred {x.Value} times"));
            CountGroupings(new string[] { "Chocolate ", "Chocolate", "Orange", "Vanilla", "Orange" }).ForEach(x => Console.WriteLine($"Value: {x.Key} occurred {x.Value} times"));
            CountGroupings(new string[] { "Chocolate ", "Vanilla", "Chocolate", "Vanilla", "Vanilla" }).ForEach(x => Console.WriteLine($"Value: {x.Key} occurred {x.Value} times"));

            //Index Of method
            Console.WriteLine(GetIndexOf(new string[] { "Cat", "Dog", "Bird" }, "Dog"));
            Console.WriteLine(GetIndexOf(new string[] { "Fish", "Hamster", "Snake" }, "Fish"));
            Console.WriteLine(GetIndexOf(new string[] { "Mouse", "Dog", "Bird" }, "Cat"));
            Console.WriteLine(GetIndexOf(new string[] { "Cat", "Hamster", "Cat" }, "Cat"));

            //Get fiscal year methods
            Console.WriteLine(GetFiscalYear(new DateTime(2024, 7, 1)));
            Console.WriteLine(GetFiscalYear(new DateTime(2023, 5, 21)));
            Console.WriteLine(GetFiscalYear(new DateTime(2025, 6, 20)));
            Console.WriteLine(GetFiscalYear(new DateTime(2024, 11, 1)));
            Console.WriteLine(GetFiscalYear(new DateTime(2022, 12, 31)));
        }

        /// <summary>
        /// Should return the lowest value of an array of integers. 
        /// </summary>
        /// <example>an array of [34, 15, 8, 2] returns 2</example>
        /// <param name="values">an array of <c>int[]</c></param>
        /// <returns><c>Int32</c> The lowest value of the array</returns>
        static int GetMinimumValue(int[] values)
        {
            //create copy of listed values
            List<int[]> sortedValues = new List<int[]> {values};
            //sort values
            sortedValues.Sort();
            sortedValues.Reverse();
            //return first value
            Console.WriteLine(sortedValues[0]);
        }

        /// <summary>
        /// Should return the product of that number and 8 if even. If odd, return the product of that number and 9;
        /// </summary>
        /// <example>32 => (32 * 8)</example>
        /// <example>21 => (21 * 9)</example>
        /// <param name="value"></param>
        /// <returns><c>Int32</c> The product of the number and it's corresponding multiplier</returns>
        static int Multiply(int value)
        {
            //check to see if given number is even or odd
            if (value % 2 = 0) 
            //if even, multiply by 8
            {
                Console.WriteLine(value * 8);
            //if odd, multiply by 9
            } else {
                Console.WriteLine(value * 9);
            }
            
        }

        /// <summary>
        /// Should return the average of the array and round down to the nearest whole number
        /// </summary>
        /// <example>[5, 1, 2] => 2</example>
        /// <example>[4, 3, 0, 5] => 3<example>
        /// <param name="values"></param>
        /// <returns><c>Int32</c>The rounded average of the given array</returns>
        static int AverageAndRound(int[] values)
        {
            //declare variables
            var totalValue = 0M;
            var divisor = values.Length;
            //add total sum of values
            for (int i = 0; i < values.Length; i++) {
                totalValue += i;
            }
            //divide by number of values
            var average = totalValue / divisor;
            //round down to whole number
            //return value of average
            Console.WriteLine(Math.Floor(average));
        }

        /// <summary>
        /// Should return a <c>List<string, int>/c> of each unique value and the number of times it occurs
        /// </summary>
        /// <example>["Chocolate", "Chocolate", "Orange", "Vanilla"] => [ Chocolate: 2, Orange: 1, Vanilla: 1 ]</example>
        /// <param name="values">The list to be evaluated</param>
        /// <returns><c>List<string, int></c></returns>
        static List<KeyValuePair<string, int>> CountGroupings(string[] values)
        {
            //create copy of item list
            List<string[]> groupsCopy = new List<string[]> {values};
            //create group count array
            List<KeyValuePair<string, int>> groupCount = new List<KeyValuePair<string, int>> {"", 0};
            //iterate through each value
            foreach (var value in groupsCopy) {
            //set group name to first value, and group number to 0
                var groupName = values[0];
                var groupNumber = 0;
            //if item matches group name, increment group number
            for (int i = 0; i < values.Length; i++) {
                if (values[i] == groupName) {
                    groupNumber++;
            //remove value from list
                    groupsCopy.Remove(value);
                };
            //exit loop and add key value pair
            groupCount.Add(new KeyValuePair<string, int>(groupName, groupNumber));
            }
            }
            //log group count
            Console.WriteLine(groupCount);
        }

        /// <summary>
        /// Should return the index of the fist occurrence of the item within the array. Should return -1 if item does not exist.
        /// </summary>
        /// <example>["Cat", "Dog", "Fish"] (Cat) => 0</example>
        /// <example>["Cat", "Dog", "Fish"] (Dog) => 1</example>
        /// <example>["Cat", "Dog", "Fish"] (Fish) => 2</example>
        /// <example>["Cat", "Dog", "Fish"] (Bird) => -1</example>
        /// <param name="values">The array to be searched</param>
        /// <param name="lookupValue">The value to look up</param>
        /// <returns>The index of the item</returns>
        static int GetIndexOf(string[] values, string lookupValue)
        {
            //iterate through list of values
            for (var i = 0; i < values.Length; i++) {
            //if iteration value matches look up value
                if (values[i] == lookupValue) {
            //log index of iteration value
                    Console.WriteLine(Array.IndexOf(values, i));
                }
            }
        }

        /// <summary>
        /// A company's fiscal year is offset by 6 months from the calendar year and runs from July 1st to June 30th. So even though it is July 1st, 2024, the fiscal year is 2025.
        /// Write a method that will calculate the fiscal year from the given date.
        /// </summary>
        /// <example>June 30th, 2024 => FY2024</example>
        /// <example>July 1st, 2026 => FY2027</example>
        /// <example>January 1st, 2025 => FY2025</example>
        /// <param name="value">The datetime to be evaluated</param>
        /// <returns>The fiscal year as integer/returns>
        static int GetFiscalYear(DateTime value)
        {
            //convert value to numeric date time
            DateTime givenDate = Convert.ToDateTime(value);
            //if month is june or earlier
            if (givenDate.Month < 7) {
            //log fiscal year is given year
                Console.WriteLine("FY${givenDate.Year}");
            //otherwise, log fiscal year is one more than given year
            } else {
                Console.WriteLine("FY${givenDate.Year + 1}");
            }
        }
    }
}
