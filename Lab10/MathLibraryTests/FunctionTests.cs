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
    public class FunctionTests
    {
        [TestMethod()]
        [DataRow(10, -10, 1, 1, 1, new double[] {})]
        [DataRow(1, 2, -1, 1, 1, new double[] {0,0})]
        [DataRow(-1, 1, 1, 1, 1, new double[] { 857.46, double.NaN, 170.86 })]
        [DataRow(-1, 1, 1, 1, 0, new double[] {double.NaN, double.NaN, double.NaN})]
        [DataRow(1, 3, 1, 1, 1, new double[] { 170.86, 2198.65, 8616.31 })]
        public void Func10Test(double xmin, double xmax, double dx, double a, double b, double[] res)
        {
            var expected = new Dictionary<double, double>();
            var j = 0;
            if (dx > 0)
            {
                for (var i = xmin; i <= xmax; i += dx)
                {
                    expected.Add(i, res[j]);
                    j++;
                }
            }

            var actual = Function.GetTable(dx, xmin, xmax, a, b);
            Assert.IsTrue(actual.SequenceEqual(expected));
        }
    }
}