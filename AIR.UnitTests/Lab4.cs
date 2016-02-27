using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Lab4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AIR.UnitTests
{
    [TestClass]
    public class Lab4
    {
        #region IT
        [TestMethod]
        public void Lab4_GreyWarden_CanShuffle()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };

            var result = list.Shuffle();
            var expected = new List<int> { 1, 0, 3, 2, 5, 4 };

            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        public void Lab4_GreyWarden_CanReturnEven()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };

            var result = list.Even();
            var expected = new List<int> { 0, 2, 4 };

            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        public void Lab4_GreyWarden_CanReturnOdd()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };

            var result = list.Odd();
            var expected = new List<int> { 1, 3, 5 };

            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        public void Lab4_GreyWarden_CanSumOdd()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };

            var result = list.OddSum();
            var expected = 9;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Lab4_GreyWarden_CanSumEven()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };

            var result = list.EvenSum();
            var expected = 6;

            Assert.AreEqual(expected, result);
        }
        #endregion

        #region AT
        [TestMethod]
        public void Lab4_Anton_DoSmthTest1()
        {
            var sourse = new[] { new StringBuilder("anton"), new StringBuilder("roma"), new StringBuilder("ilik") };

            var result =
                sourse.DoSmth(x => x.Replace(x[0].ToString(), x[0].ToString().ToUpper()));
            var expected = new string[] { "Anton", "Roma", "Ilik" };
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expected[i], expected.ElementAt(i));
            }
        }

        [TestMethod]
        public void Lab4_Anton_DoSmthTest2()
        {
            var sourse = new List<int>[] { new List<int>(), new List<int>(), };

            var result =
                sourse.DoSmth(x => x.Add(DateTime.Now.Second));
            Assert.IsTrue(result.All(x => x.Count == 1));
        }

        [TestMethod]
        public void Lab4_Anton_DoSmthTest3()
        {
            var expected = "somestr";
            var sourse = new[] { new StringBuilder(expected) };

            var result =
                sourse.DoSmth(null);
            Assert.AreEqual(expected, result.ElementAt(0).ToString());
        }
        #endregion
    }
}
