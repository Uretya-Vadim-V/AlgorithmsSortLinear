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
        public static void Counting(int[] mas)
        {
            int max = mas.Max();
            int min = mas.Min();
            int[] count = new int[max - min + 1];
            int k = 0;
            int index = -1;
            while (++index < mas.Length)
                count[mas[index] - min]++;
            index = min;
            while (index <= max)
            {
                while (count[index - min]-- > 0)
                {
                    mas[k++] = index;
                }
                index++;
            }
        }

        //Голубиная сортировка
        public static void Pigeonhole(int[] mas)
        {
            Dictionary<int, int> dictionary = new();
            foreach (var item in mas)
            {
                if (dictionary.ContainsKey(item))
                    dictionary[item]++;
                else
                    dictionary.Add(item, item);
            }
            int max = mas.Max();
            int min = mas.Min();
            int index = 0;
            int k;
            while (min <= max)
            {
                if (dictionary.ContainsKey(min))
                {
                    k = min;
                    while (k <= dictionary[min])
                    {
                        mas[index++] = min;
                        k++;
                    }
                }
                min++;
            }
        }

        //Блочная сортировка
        public static void Bucket(int[] data)
        {
            int min = data.Min();
            int max = data.Max();
            int i = -1, k = 0, j;
            List<int>[] bucket = new List<int>[max - min + 1];
            while (++i < bucket.Length)
                bucket[i] = new List<int>();
            i = -1;
            while (++i < data.Length)
                bucket[data[i] - min].Add(data[i]);
            i = -1;
            while (++i < bucket.Length)
            {
                j = -1;
                if (bucket[i].Count > 0)
                {
                    while (++j < bucket[i].Count)
                    {
                        data[k++] = bucket[i][j];
                    }
                }
            }
        }

        //Поразрядная сортировка

        public static void Radix_LSD(int[] mas)
        {
            int count = (int)Math.Floor(Math.Log10(mas.Max()));
            int i = -1, j, index, u, v;
            List<int>[] bucket = new List<int>[10];
            while (++i < bucket.Length)
                bucket[i] = new List<int>();
            i = -1;
            while (++i <= count)
            {
                j = -1;
                while (++j < mas.Length)
                    bucket[(int)Math.Floor(mas[j] % Math.Pow(10, i + 1) / Math.Pow(10, i))].Add(mas[j]);
                index = 0; u = -1;
                while (++u < 10)
                {
                    v = -1;
                    while (++v < bucket[u].Count)
                    {
                        mas[index++] = bucket[u][v];
                    }
                    bucket[u].Clear();
                }
            }
        }
    }
}
