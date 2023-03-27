using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary.Tests
{
    [TestClass()]
    public class ArrayTests
    {
        [DataRow(1, new char[] {}, 0)]
        [DataRow(2, new char[] {'a'}, 0)]
        [DataRow(3, new char[] {'a', 'b'}, 0)]
        [DataRow(4, new char[] {'a', 'a', 'b'}, 1)]
        [TestMethod()]
        public void DuplicateTest(int id, char[] c, int exp)
        {
            Assert.AreEqual(exp, Array.Duplicate(c.Length, c).Length);
        }

        [DataRow(1, new char[] {'a', 'b' }, 0)]
        [DataRow(2, new char[] { }, 0)]
        [DataRow(3, new char[] { 'a', 'b', 'c' }, 0)]
        [DataRow(4, new char[] { 'a' }, 0)]
        [DataRow(5, new char[] { 'a', 'a', 'b' }, 1)]
        [DataRow(6, new char[] { 'a', 'b', 'c', 'd' }, 0)]
        [TestMethod()]
        public void DuplicateTestWhiteBox(int id, char[] c, int exp)
        {

        }
    }
}