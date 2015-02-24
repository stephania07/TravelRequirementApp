using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelRequirementAppTest
{
    [TestClass]
    public class DestinationSearchTest : TestHelper
    {
        //Story: Traveler gets the travel requirements of a destination

        //As a traveler
        //I want to get the travel requirements of my destination from (DB)
        //So that I can prepare the requirements before I start my journey

        //Scenario 1: Selected destination is available in DB
        //Given There is no selected destination
        //And a traveler selects a destination
        //And the travel requirements of the selected destination is available in the DB
       
        //When the traveler Selects A Destination
        //Then the destination should be available in the dropdown list
        //And the destination should be selected
        //And the Go button should be turned enabled
        //And then click the Go button
        //And it should show error if not selected
        //And the travel requirements list should show up
        //.......//.......//

        
 
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
            GivenThereIsNoSelectedDestination();
            WhenIClickTheListOption();
            ThenIShouldSeeTheDestinationInTheDropdownList();
            ThenIShouldSelectTheDestinationFromTheDropdownList();
            AndTheGoButtonShouldBeTurnedEnabled();
            AndIShouldClicktheGoButton("Go");
            AndIShouldSeeTheTravelRequirementForm("Australia", "six month visa", "must be declared", "None", "Yes");
            AndIShouldSeeTheListofDestinationRequirement();
        }

        

        [TestMethod]
        public void DestinationInfoValidation()
        {
            GivenThereIsNoSelectedDestination();
            WhenIClickTheListOption();
            ThenIShouldSeeTheDestinationInTheDropdownList();
            AndTheGoButtonShouldBeTurnedEnabled();
            AndIfNotSelectedIShouldSeeAnErrorMessage("Destination must be selected");
        }

        [TestMethod]
        public void CancelingOutofDestinationInfoForm()
        {
            GivenThereIsNoSelectedDestination();
            WhenIClickTheListOption();
            ThenIShouldSeeTheDestinationInTheDropdownList();
            ThenIShouldSelectTheDestinationFromTheDropdownList();
            AndTheGoButtonShouldBeTurnedEnabled();
            AndIShouldClicktheGoButton("Go");
            AndIShouldNotSeeTheDestinationInfo();
            AndIShouldSeeTheListofDestinationRequirement();
        }
     }
}
