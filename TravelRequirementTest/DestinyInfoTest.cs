using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelRequirementApp.Model;

namespace TravelRequirementAppTest
{
    [TestClass]
    public class DestinyInfoTest
    {
        [TestMethod]
        public void CreatingADestinationStoresItsProperties()
        {
            DestinyInfo country = new DestinyInfo("Australia", "six month visa");
            Assert.AreEqual("Australia", country.Name );
            Assert.AreEqual("six month visa", country.passportvalidity );
        }
    }
}
