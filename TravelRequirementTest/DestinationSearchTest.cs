using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelRequirementAppTest
{
    [TestClass]
    public class DestinationSearchTest : TestHelper
    {
        //As a user
        //In order to prepare the travel requirements for my trips
        //I want to get the requirements based on my destination
        //* Click "Option(v)" to get the dropdown list of destinations(countries)
        //* Destination must be selected
        //* Click "Go" to get the result/travel requirements
        //* It should show error if not selected
        //* The requirements shows up in the travel requirement list(this is on the second page)

        [ClassInitialize]
        public static void SetupTests(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SetupTest()
        {
            TestHelper.TestPrep();
        }

        [TestCleanup]
        public void CleanUp()
        {
            TestHelper.CleanThisUp();
        }
       
        [TestMethod]
        public void DestinationInfo()
        {
            GivenThereAreNoFilledDestination();
            ThenIShouldSeeTheDropdownListofDestionation();
            ThenIShouldSelectFromDropdownListofDestination();
            WhenIClick("Go");
            ThenIShouldSeeTheListofDestinationRequirement();
        }
      
        [TestMethod]
        public void DestinationInfoValidation()
        {
            GivenThereAreNoFilledDestination();
            WhenIClick("Go");
            ThenIShouldSeeTheListofDestinationRequirement();
            AndIShouldSeeAnErrorMessage("Destination must be filled in");                  
        }

        [TestMethod]
        public void CancelingOutofDestinationRequirementList()
        {
            GivenThereAreNoFilledDestination();
            WhenIClick("Go");
            TheDestinationPageViewGoesAway();
            ThenIShouldSeeTheListofDestinationRequirement();


        }

    }
}
