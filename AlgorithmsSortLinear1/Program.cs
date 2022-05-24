using System;

namespace AlgorithmsSortLinear1
{
    public class Program
    {
        static Random random = new();
        public static void Fill(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 100);
            }
        }
        public static void GetString(int[] array)
        {
            foreach (int i in array)
                Console.Write("{0} ", i.ToString());
            Console.WriteLine();
        }
        public static bool Comparer(int[] array, int[] arraySort)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] != arraySort[i])
                    return false;
            return true;
        }
        public static int[] CopySort(int[] array)
        {
            int[] copy = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                copy[i] = array[i];
            Array.Sort(copy);
            return copy;
        }
        static void Main(string[] args)
        {
            int[] array = new int[20];
            Console.WriteLine("\nСортировка подсчетом");
            {
                Fill(array);
                GetString(array);
                Sort.Counting(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nГолубиная сортировка");
            {
                Fill(array);
                GetString(array);
                Sort.Pigeonhole(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nБлочная сортировка");
            {
                Fill(array);
                GetString(array);
                Sort.Bucket(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nПоразрядная сортировка LSD");
            {
                Fill(array);
                GetString(array);
                Sort.Radix_LSD(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
        }
    }
}
