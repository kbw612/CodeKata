using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata;

//
// Babysitter Kata
// https://gist.github.com/jameskbride/5482722
//

namespace BabysitterTest
{
    [TestClass]
    public class BabysitterTest
    {
        private Babysitter _babysitter;
        private int _pay = 0;

        [TestInitialize]
        public void Initialize()
        {
            _babysitter = new Babysitter();
        }

        [TestMethod]
        public void CalculatePay_BabysitterWorksUntilBedtime_Returns48Dollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 17, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 29, 21, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(48, _pay);
        }

        [TestMethod]
        public void CalculatePay_BabysitterWorksUntilMidnight_Returns72Dollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 17, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 30, 0, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(72, _pay);
        }

        [TestMethod]
        public void CalculatePay_BabysitterWorksAllPossibleHours_Returns136Dollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 17, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 30, 4, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(136, _pay);
        }

        [TestMethod]
        public void CalculatePay_BabysitterStartsWorkBefore5pmAndStopsWorkAfter4am_Returns136Dollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 16, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 30, 5, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(136, _pay);
        }

        [TestMethod]
        public void CalculatePay_BabysitterStartsWorkingAtMidnightAndStopsWorkingAt4am_Returns64Dollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 30, 0, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 30, 4, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(64, _pay);
        }

        [TestMethod]
        public void CalculatePay_BabysitterStartsAndEndsWorkWithFractionalHours_Returns136Dollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 17, 30, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 30, 4, 30, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 30, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(136, _pay);
        }

        [TestMethod]
        public void CalculatePay_BedtimePassedIsBefore5PmStartTime_ReturnsZeroDollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 17, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 29, 23, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 16, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(0, _pay);
        }

        [TestMethod]
        public void CalculatePay_BedtimePassedIsAfter4AmEndTime_ReturnsZeroDollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 17, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 30, 4, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 30, 5, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(0, _pay);
        }

        [TestMethod]
        public void CalculatePay_StartTimeIsGreaterThanEndTime_ReturnsZeroDollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 23, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 29, 19, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(0, _pay);
        }

        [TestMethod]
        public void CalculatePay_BabysitterStartsWorkingAtBedtimeAndStopsWorkingAt4am_Returns88Dollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 21, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 30, 4, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(88, _pay);
        }

        [TestMethod]
        public void CalculatePay_BabysitterStartsWorkingAfterBedtimeAndStopsWorkingBeforeMidnight_Returns8Dollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 22, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 29, 23, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(8, _pay);
        }

        [TestMethod]
        public void CalculatePay_BabysitterStartsAndStopsWorkingBeforeBedtime_Returns24Dollars()
        {
            // Arrange
            _babysitter.StartTime = new DateTime(2015, 9, 29, 18, 0, 0);
            _babysitter.EndTime = new DateTime(2015, 9, 29, 20, 0, 0);
            _babysitter.BedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            _pay = _babysitter.CalculatePay();

            // Assert
            Assert.AreEqual(24, _pay);
        }
    }
}
