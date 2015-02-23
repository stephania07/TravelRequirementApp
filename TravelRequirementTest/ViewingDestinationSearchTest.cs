using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelRequirementApp.Model;

namespace TravelRequirementAppTest
{
    [TestClass]
    public class ViewingDestinationSearchTest : TestHelper
    {
        //As a user
        //In order to travel whenever I want
        // I want to see the travel requirements according to my destination
        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SetupTests()
        {
            GivenTheseSelectedDestinations(
                new DestinyInfo("Australia", "six month visa", "must be declared", "None", "Yes"),
                new DestinyInfo("France", "three month", "must be declared", "None", "Yes")
            );
            TestHelper.TestPrep();
        }

        [TestCleanup]
        public void CleanUp()
        {
            TestHelper.CleanThisUp();
        }

        [TestMethod]
        public void ScenarioViewingDestinationListWhenThereAreSelectedDestinations()
        {
           // ThenIShouldSeeXDestinations();
           // AndIShouldSeeListFor("Australia", "Six month");
           // AndIShouldSeeListFor("France", "Three month");
           //AndIShouldNotSeeTheDestinyInfoForm();   
        }
    }
}
