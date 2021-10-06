using System;
using System.Linq;

namespace MergeSortApp
{
    internal static class Program
    {
        private static void Main()
        {
            var array = new int[21];
            
            var random = new Random();
            for (var i = 0; i < array.Length - 1; i++)
            {
                array[i] = random.Next(1, 22);
                Console.Write($"{array[i]}, ");
            }
            array[^1] = random.Next(0, 21);
            Console.WriteLine(array[^1]);

            array = MergeSort(array);
            
            for (var i = 0; i < array.Length - 1; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine(array[^1]);
        }

        static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            var middle = array.Length / 2;
            var leftArray = MergeSort(array[0..middle]);
            var rightArray = MergeSort(array[middle..^0]);
            
            return Merge(leftArray, rightArray);
        }

        static int[] Merge(int[] leftArray, int[] rightArray)
        {
            if (leftArray.Length == 0)
            {
                return rightArray;
            }

            if (rightArray.Length == 0)
            {
                return leftArray;
            }
            
            // slicing arrays so that the smallest value is to the left and the rest is to the right
            var array = new int[leftArray.Length + rightArray.Length];
            if (leftArray[0] < rightArray[0])
            {
                leftArray[0..1].CopyTo(array, 0);
                Merge(leftArray[1..^0], rightArray).CopyTo(array, 1);
            }
            else
            {
                rightArray[0..1].CopyTo(array, 0);
                Merge(leftArray, rightArray[1..^0]).CopyTo(array, 1);
            }

            return array;
        }
    }
}