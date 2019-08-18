using System;
using Cycle_Race;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleRaceUnitTesting
{
    [TestClass]
    public class cycle_unittesting
    {
        [TestMethod]
        public void Payout_Is_Zero()
        {
            // Arrange
            var bet = new Bet();

            // Act
            var actual = bet.Payout("No One");

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Error_Popup_No_Cash()
        {
            // Arrange
            var guy = new BetPlacer();

            // Act
            var actual = guy.PlaceBet(100, "Error");

            // Assert
            Assert.AreEqual(false, actual);
        }
    }
}
