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

            // Act
            int pay = babysitter.CalculatePay(startTime, endTime);

            // Assert
            Assert.AreEqual(48, pay);
        }
    }
}
