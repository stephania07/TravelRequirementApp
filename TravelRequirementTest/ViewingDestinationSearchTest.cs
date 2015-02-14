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
        // I want to see their visa validity regulation
        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SetupTests()
        {
            //GivenThereAreNoFilledDestination(
            //    new DestinyInfo("Australia", "Six month"),
            //    new DestinyInfo("France", "three month")
            //);
            //TestHelper.TestPrep();
        }

        [TestCleanup]
        public void CleanUp()
        {
            TestHelper.CleanThisUp();
        }

        [TestMethod]
        public void ScenarioViewingDestinationSearchWwhenDestinationIsSelected()
        {
           // ThenIShouldSeeXDestination(1);
           // AndIShouldSeeListFor("Australia", "Six month");
               
        }
    }
}
