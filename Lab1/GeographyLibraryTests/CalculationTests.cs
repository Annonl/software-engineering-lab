using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeographyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeographyLibrary.AzimuthModel;

namespace GeographyLibrary.Tests
{
    [TestClass]
    public class CalculationTests
    {
        #region Красная фаза 1 

        /// <summary>
        /// Проверка передачи недопустимых параметров в тест.
        /// </summary>
        [TestMethod]
        [DataRow(200, 0,0,0)]
        [DataRow(-200, 0,0,0)]
        [DataRow(0, 200,0,0)]
        [DataRow(0, 0,200,0)]
        [DataRow(0, 0,0,200)]
        [ExpectedException(typeof(ArgumentException))]
        public void GetDistanceExceptionTest(double x1, double y1, double x2, double y2)
        {
            Calculation.GetDistance(new Coordinate(){Latitude = x1, Longitude = y1}, new Coordinate() { Latitude = x2, Longitude = y2 });
        }

        /// <summary>
        /// Проверка передачи недопустимых параметров в тест.
        /// </summary>
        [TestMethod]
        [DataRow(100, 0, 0, 0)]
        [DataRow(-100, 0, 0, 0)]
        [DataRow(0, 200, 0, 0)]
        [DataRow(0, 0, 200, 0)]
        [DataRow(0, 0, 0, 200)]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAzimuthExceptionTest(double x1, double y1, double x2, double y2)
        {
            Calculation.GetAzimuth(new Coordinate() { Latitude = 100, Longitude = 200 }, new Coordinate() { Latitude = -100, Longitude = -200 });
        }

        #endregion

        #region Красная фаза 2
        //
        // /// <summary>
        // /// Проверка вычисления угла азимута.
        // /// </summary>
        // [TestMethod]
        // [DataRow(60, 30, 30, 10, 213.0768)]
        // [DataRow(-60, 30, 30, -10, 325.9754)]
        // [DataRow(43, -8, 12, 23, 129.8013)]
        // [DataRow(0, 0, -10, -160, 242.7268)]
        // [DataRow(10, 160, -10, -160, 115.5056)]
        // [DataRow(51.5, 0, -22.97, -43.18, 219.3505)]
        // public void GetAzimuthTest(double x1, double y1, double x2, double y2, double result)
        // {
        //     var firstCoordinate = new Coordinate() {Latitude = x1, Longitude = y1};
        //     var secondCoordinate = new Coordinate() {Latitude = x2, Longitude = y2};
        //
        //     Assert.AreEqual(result, Calculation.GetAzimuth(firstCoordinate, secondCoordinate));
        // }

        #endregion

        #region Красная фаза 3

        /// <summary>
        /// Проверка вычисления угла азимута. 
        /// </summary>
        [TestMethod]
        [DataRow(60, 30, 30, 10, 213.0768)]
        [DataRow(-60, 30, 30, -10, 325.9754)]
        [DataRow(43, -8, 12, 23, 129.8013)]
        [DataRow(0, 0, -10, -160, 242.7268)]
        [DataRow(10, 160, -10, -160, 115.5056)]
        [DataRow(51.5, 0, -22.97, -43.18, 219.3505)]
        [DataRow(80, 0, -80, 0, 180)]
        public void GetAzimuthTest(double x1, double y1, double x2, double y2, double result)
        {
            var firstCoordinate = new Coordinate() {Latitude = x1, Longitude = y1};
            var secondCoordinate = new Coordinate() {Latitude = x2, Longitude = y2};

            var res = Calculation.GetAzimuth(firstCoordinate, secondCoordinate);

            if (res.AzimuthResult != AzimuthResult.Value)
            {
                Assert.Fail();
            }

            Assert.AreEqual(result, res.Value);
        }

        /// <summary>
        /// Проверка для точек, лежащих на одной прямой, проходящей через центр Земли.
        /// </summary>
        [TestMethod]
        [DataRow(80, 120, -80, -60)]
        [DataRow(0, 80, 0, -100)]
        [DataRow(60, 1, -60, 179)]
        [DataRow(23, 53, -23, -127)]
        [DataRow(8, 0, -8, -180)]
        public void PointsThroughCenterTest(double x1, double y1, double x2, double y2)
        {
            var firstCoordinate = new Coordinate() { Latitude = x1, Longitude = y1 };
            var secondCoordinate = new Coordinate() { Latitude = x2, Longitude = y2 };

            var result = Calculation.GetAzimuth(firstCoordinate, secondCoordinate).AzimuthResult;
            
            Assert.AreEqual(AzimuthResult.Any, result);
        }

        /// <summary>
        /// Проверка при совпадающих точках.
        /// </summary>
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(20, -8)]
        [DataRow(45, 12)]
        [DataRow(80, -158)]
        [DataRow(-60, 170)]
        public void PointsEqualTest(double x, double y)
        {
            var firstCoordinate = new Coordinate() { Latitude = x, Longitude = y };
            var secondCoordinate = new Coordinate() { Latitude = x, Longitude = y };

            var result = Calculation.GetAzimuth(firstCoordinate, secondCoordinate).AzimuthResult;

            Assert.AreEqual(AzimuthResult.None, result);
        }

        /// <summary>
        /// Для точек на одном полюсе.
        /// </summary>
        [TestMethod]
        [DataRow(90, 0)]
        [DataRow(-90, 0)]
        public void TwoPointsOnOnePoleTest(double x, double y)
        {
            var firstCoordinate = new Coordinate() { Latitude = x, Longitude = y };
            var secondCoordinate = new Coordinate() { Latitude = x, Longitude = y };

            var result = Calculation.GetAzimuth(firstCoordinate, secondCoordinate).AzimuthResult;

            Assert.AreEqual(AzimuthResult.None, result);
        }

        /// <summary>
        /// Для точек на противоположных полюсах.
        /// </summary>=
        [TestMethod]
        [DataRow(90, 12, -90, 23)]
        [DataRow(-90, 12, 90, 23)]
        public void TwoPointsOnDifferentPoleTest(double x1, double y1, double x2, double y2)
        {
            var firstCoordinate = new Coordinate() { Latitude = x1, Longitude = y1 };
            var secondCoordinate = new Coordinate() { Latitude = x2, Longitude = y2 };

            var result = Calculation.GetAzimuth(firstCoordinate, secondCoordinate).AzimuthResult;

            Assert.AreEqual(AzimuthResult.Any, result);
        }

        /// <summary>
        /// Для точек на экваторе.
        /// </summary>
        [TestMethod]
        [DataRow(123, -123, 90)]
        [DataRow(45, -12, 270)]
        [DataRow(-123, 123, 270)]
        [DataRow(1, 180, 90)]
        [DataRow(-1, 180, 270)]
        public void TwoPointsOnEquatorTest(double y1, double y2, double result)
        {
            var firstCoordinate = new Coordinate() { Latitude = 0, Longitude = y1 };
            var secondCoordinate = new Coordinate() { Latitude = 0, Longitude = y2 };

            var res = Calculation.GetAzimuth(firstCoordinate, secondCoordinate);

            if (res.AzimuthResult != AzimuthResult.Value)
            {
                Assert.Fail();
            }

            Assert.AreEqual(result, res.Value);
        }

        /// <summary>
        /// Проверка для точек на одном меридиане.
        /// </summary>
        [TestMethod]
        [DataRow(12, 8, 180)]
        [DataRow(12, -67, 180)]
        [DataRow(-12, 8, 0)]
        [DataRow(-12, 88, 0)]
        [DataRow(-62, 0, 0)]
        public void TwoPointsOnMeridianTest(double x1, double x2, double result)
        {
            var firstCoordinate = new Coordinate() { Latitude = x1, Longitude = 0 };
            var secondCoordinate = new Coordinate() { Latitude = x2, Longitude = 0 };

            var res = Calculation.GetAzimuth(firstCoordinate, secondCoordinate);

            if (res.AzimuthResult != AzimuthResult.Value)
            {
                Assert.Fail();
            }

            Assert.AreEqual(result, res.Value);
        }

        #endregion

        #region Красная фаза 4

        /// <summary>
        /// Проверка получения расстояния.
        /// </summary>
        [TestMethod]
        [DataRow(60, 30, 30, 10, 3654.896)]
        [DataRow(-60, 30, 30, -10, 10654.086)]
        [DataRow(43, -8, 12, 23, 4556.286)]
        [DataRow(0, 0, -10, -160, 17538.940)]
        [DataRow(10, 160, -10, -160, 4952.350)]
        [DataRow(51.5, 0, -22.97, -43.18, 9289)]
        [DataRow(80, 0, -80, 0, 17791.213)]
        public void GetDistanceTest(double x1, double y1, double x2, double y2, double result)
        {
            var firstCoordinate = new Coordinate() { Latitude = x1, Longitude = y1 };
            var secondCoordinate = new Coordinate() { Latitude = x2, Longitude = y2 };

            var res = Calculation.GetDistance(firstCoordinate, secondCoordinate);

            Assert.IsTrue(Math.Abs(result - res) < 0.1);
        }

        /// <summary>
        /// Проверка расстояния меньше Pi * R.
        /// </summary>
        [TestMethod]
        [DataRow(60, 30, 30, 10)]
        [DataRow(-60, 30, 30, -10)]
        [DataRow(43, -8, 12, 23)]
        [DataRow(0, 0, -10, -160)]
        [DataRow(10, 160, -10, -160)]
        [DataRow(51.5, 0, -22.97, -43.18)]
        [DataRow(80, 0, -80, 0)]
        [DataRow(0, 180, 0, -170)]
        public void LessDistanceTest(double x1, double y1, double x2, double y2)
        {
            var firstCoordinate = new Coordinate() { Latitude = x1, Longitude = y1 };
            var secondCoordinate = new Coordinate() { Latitude = x2, Longitude = y2 };

            var result = Calculation.GetDistance(firstCoordinate, secondCoordinate);

            Assert.IsTrue(result < Math.PI * Calculation.R);
        }

        #endregion

    }
}   