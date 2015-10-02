﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata;

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
        public void WhenBabysitterWorksUntilBedtime()
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
        public void WhenBabysitterWorksUntilMidnight()
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
        public void WhenBabysitterWorksAllPossibleHours()
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
        public void WhenBabysitterStartsWorkBefore5pmAndStopsWorkAfter4am()
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
        public void WhenBabysitterStartsWorkingAtMidnightAndStopsWorkingAt4am()
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
        public void WhenBabysitterStartsAndEndsWorkWithFractionalHours()
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
        public void WhenBedtimePassedIsBefore5PmStartTime()
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
        public void WhenBedtimePassedIsAfter4AmEndTime()
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
        public void WhenStartTimeIsGreaterThanEndTime()
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
        public void WhenBabysitterStartsWorkingAtBedtimeAndStopsWorkingAt4am()
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
        public void WhenBabysitterStartsWorkingAfterBedtimeAndStopsWorkingBeforeMidnight()
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
        public void WhenBabysitterStartsAndStopsWorkingBeforeBedtime()
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
