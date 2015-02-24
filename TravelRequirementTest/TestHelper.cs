using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TravelRequirementApp.Repository;
using TravelRequirementApp;
using TravelRequirementApp.Model;
using TestStack.White.UIItems.Finders;



namespace TravelRequirementAppTest
{
    [TestClass]
    public class TestHelper
    {
       // private static TestContext test_context;
        protected static Window window;
        private static Application application;
        private static TextBox titlebox;
        private static Label destinationlabel;
        private static ComboBox countrieslist;
        private static Button submit;
        private static DestinyInfoRepository repo = new DestinyInfoRepository();
        private static DestinationContext context;
        private static String applicationPath;

       
        public static void SetupClass(TestContext _context)
        {
            var applicationDir = _context.DeploymentDirectory;
            applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TravelRequirementTest\\bin\\Debug\\TravelRequirementApp");
        }

        public static void TestPrep()
        {
            application = Application.Launch(applicationPath);
            window = application.GetWindow("Travel_Requirement", InitializeOption.NoCache);
            titlebox = window.Get<TextBox>("TitleBox");
            destinationlabel = window.Get<Label>("DestinationsLabel");
            countrieslist = window.Get<ComboBox>("CountriesList");
            submit = window.Get<Button>("SubmitButton");
            context = repo.Context();
        }
        //As a User
        void WhenTheGoButtonIsClicked()
        {
            System.Threading.Thread.Sleep(5000);//so I can see
            submit.Click();
            System.Threading.Thread.Sleep(5000); //so I can see
        } 
        void GivenTheMainWindowisOpen()
        {
            Assert.IsTrue(window.IsFocussed);
        }

        public void GivenThereIsNoSelectedDestination()
        {
            Assert.AreEqual(0, repo.GetCount());
        }

        public void WhenIClickTheListOption()
        {
            Button button = window.Get<Button>(SearchCriteria.ByText("Australia")); //<Button> acts as criteria as well as the return type
            button.Click();
            
        }

        public void ThenIShouldSeeTheDestinationInTheDropdownList()
        {
           Button button = window.Get<Button>(SearchCriteria.ByAutomationId("CountriesList"));
           Assert.IsTrue(button.Visible);      
        }

        public void ThenIShouldSelectTheDestinationFromTheDropdownList()
        {
            Button button = window.Get<Button>(SearchCriteria.ByText("German"));
            Assert.IsTrue(button.Visible);   
        }

        public void AndTheGoButtonShouldBeTurnedEnabled()
        {
            Button button = window.Get<Button>("SubmitButton");
            Assert.IsTrue(button.Enabled);
        }

        public void AndIShouldClicktheGoButton(string p)
        {
            throw new NotImplementedException();
        }
        public void AndIShouldSeeTheTravelRequirementForm(string p1, string p2, string p3, string p4, string p5)
        {  //To be reviewed
            var e = repo.GetByDestination(p5);
            Assert.IsNotNull(window);
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("Country").AndIndex(0);
            TextBox textbox = (TextBox)window.Get(searchCriteria);
            var result = textbox.Text.IndexOf(p1);
            Assert.AreEqual(p1, result.ToString());
        }

        public void AndIShouldSeeTheListofDestinationRequirement()
        {
            throw new NotImplementedException();
        }

        public void AndIfNotSelectedIShouldSeeAnErrorMessage(string p)
        {
            throw new NotImplementedException();
        }

        public void AndIShouldNotSeeTheDestinationInfo()
        {
            throw new NotImplementedException();
        }

        public void GivenTheseSelectedDestinations(params DestinyInfo [] destinations)
        {
            foreach (DestinyInfo destiny in destinations)
            {
                //Add destiny to destination here
                repo.Add(destiny);
            }
            Assert.AreEqual(destinations.Length, repo.GetCount());
        }

        //[TestMethod]
        //public void DestinationSearchUserStory()
        //{
        //    this.BDDfy();
        //} 

        public static void CleanThisUp()
        {
            application.Close();
            window.Close();
            repo.Clear();
        }
        
      }
 }
