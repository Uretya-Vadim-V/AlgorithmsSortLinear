using AlgorithmsSortLinear1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class Counting
    {
        [TestMethod]
        public void CountingRandom()
        {
            int[] array = new int[1000000];
            Program.Fill(array);
            Sort.Counting(array);
            Assert.AreEqual(Program.Comparer(array, Program.CopySort(array)), true);
        }
        [TestMethod]
        public void CountingAll()
        {
            int[] array = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Program.Fill(array);
            Sort.Counting(array);
            Assert.AreEqual(Program.Comparer(array, Program.CopySort(array)), true);
        }
        [TestMethod]
        public void CountingStartSort()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            Program.Fill(array);
            Sort.Counting(array);
            Assert.AreEqual(Program.Comparer(array, Program.CopySort(array)), true);
        }
        [TestMethod]
        public void CountingReverse()
        {
            int[] array = { 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            Program.Fill(array);
            Sort.Counting(array);
            Assert.AreEqual(Program.Comparer(array, Program.CopySort(array)), true);
        }
        [TestMethod]
        public void CountingStartSortEndReverse()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 17, 16, 15, 14, 13, 12, 11, 10 };
            Program.Fill(array);
            Sort.Counting(array);
            Assert.AreEqual(Program.Comparer(array, Program.CopySort(array)), true);
        }
    }
}