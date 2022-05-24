using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSortLinear1
{
    public class Sort
    {
        //Сортировка подсчетом
        public static void Counting(int[] array)
        {
            int max = array.Max();
            int min = array.Min();
            int[] count = new int[max - min + 1];
            int k = 0;
            int index = -1;
            while (++index < array.Length)
                count[array[index] - min]++;
            index = min;
            while (index <= max)
            {
                while (count[index - min]-- > 0)
                {
                    array[k++] = index;
                }
                index++;
            }
        }

        //Голубиная сортировка
        public static void Pigeonhole(int[] array)
        {
            Dictionary<int, int> dictionary = new();
            foreach (var item in array)
            {
                if (dictionary.ContainsKey(item))
                    dictionary[item]++;
                else
                    dictionary.Add(item, item);
            }
            int max = array.Max();
            int min = array.Min();
            int index = 0;
            int k;
            while (min <= max)
            {
                if (dictionary.ContainsKey(min))
                {
                    k = min;
                    while (k <= dictionary[min])
                    {
                        array[index++] = min;
                        k++;
                    }
                }
                min++;
            }
        }

        //Блочная сортировка
        public static void Bucket(int[] array)
        {
            int min = array.Min();
            int max = array.Max();
            int i = -1, k = 0, j;
            List<int>[] bucket = new List<int>[max - min + 1];
            while (++i < bucket.Length)
                bucket[i] = new List<int>();
            i = -1;
            while (++i < array.Length)
                bucket[array[i] - min].Add(array[i]);
            i = -1;
            while (++i < bucket.Length)
            {
                j = -1;
                if (bucket[i].Count > 0)
                {
                    while (++j < bucket[i].Count)
                    {
                        array[k++] = bucket[i][j];
                    }
                }
            }
        }

        //Поразрядная сортировка

        public static void Radix_LSD(int[] array)
        {
            int count = (int)Math.Floor(Math.Log10(array.Max()));
            int i = -1, j, index, u, v;
            List<int>[] bucket = new List<int>[10];
            while (++i < bucket.Length)
                bucket[i] = new List<int>();
            i = -1;
            while (++i <= count)
            {
                j = -1;
                while (++j < array.Length)
                    bucket[(int)Math.Floor(array[j] % Math.Pow(10, i + 1) / Math.Pow(10, i))].Add(array[j]);
                index = 0; u = -1;
                while (++u < 10)
                {
                    v = -1;
                    while (++v < bucket[u].Count)
                    {
                        array[index++] = bucket[u][v];
                    }
                    bucket[u].Clear();
                }
            }
        }
    }
}
