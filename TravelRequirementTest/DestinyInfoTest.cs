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
            DestinyInfo destinationFacts = new DestinyInfo("Australia", "six month visa", "must be declared", "None", "Yes", " ");
            Assert.AreEqual("Australia", destinationFacts.Destination);
            Assert.AreEqual("six month visa", destinationFacts.PassportValidity);
            Assert.AreEqual("must be declared", destinationFacts.CurrencyRestriction);
            Assert.AreEqual("None", destinationFacts.Vaccination);
            Assert.AreEqual("Yes", destinationFacts.TouristVisaRequirement);

        }
    }
}
