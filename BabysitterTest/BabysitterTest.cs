using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKata;

namespace BabysitterTest
{
    [TestClass]
    public class BabysitterTest
    {
        [TestMethod]
        public void WhenBabysitterWorksUntilBedtime()
        {
            // Arrange
            Babysitter babysitter = new Babysitter();
            DateTime startTime = new DateTime(2015, 9, 29, 17, 0, 0);
            DateTime endTime = new DateTime(2015, 9, 29, 21, 0, 0);
            DateTime bedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            int pay = babysitter.CalculatePay(startTime, endTime, bedTime);

            // Assert
            Assert.AreEqual(48, pay);
        }

        [TestMethod]
        public void WhenBabysitterWorksUntilMidnight()
        {
            // Arrange
            Babysitter babysitter = new Babysitter();
            DateTime startTime = new DateTime(2015, 9, 29, 17, 0, 0);
            DateTime endTime = new DateTime(2015, 9, 30, 0, 0, 0);
            DateTime bedTime = new DateTime(2015, 9, 29, 21, 0, 0);

            // Act
            int pay = babysitter.CalculatePay(startTime, endTime, bedTime);

            // Assert
            Assert.AreEqual(48, 72);
        }
    }
}
