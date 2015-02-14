//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TestStack.White.UIItems.WindowItems;
//using TestStack.White;
//using TestStack.White.Factory;
//using System.IO;
//using TestStack.White.UIItems;
//using TestStack.BDDfy;

//namespace TravelRequirementAppTest
//{
//    [TestClass]
//    public class StoryTests
//    {
//        //private static TestContext test_context;
//        private static Window window;
//        private static Application application;
//        private static Button submit;
//        private static TextBox text_box;
//        private static Label label;

//        [ClassInitialize]
//        public static void Setup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _context)
//        {
            
//            var applicationDir = _context.DeploymentDirectory;
//            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TravelRequirementTest\\bin\\Debug\\TravelRequirementApp");
//            application = Application.Launch(applicationPath);
//            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
//            text_box = window.Get<TextBox>("EnterDestination");
//            label = window.Get<Label>("DestinationsLabel");
//            submit = window.Get<Button>("SubmitButton");
//        }
//        //As a User
//        void WhenTheGoButtonIsClicked()
//        {
//            System.Threading.Thread.Sleep(500); // so I can see
//            submit.Click();
//            System.Threading.Thread.Sleep(500);//So I can see
//        }

//        void GivenTheMainWindowisOpen()
//        {
//            Assert.IsTrue(window.IsFocussed);
//        }

//        void ThenTheTextBoxShouldContainGo()
//        {
//            Assert.AreEqual("Go", text_box.Text);
//        }
//        [TestMethod]
//        public void ExecuteStoryTest()
//        {
//            this.BDDfy();
//        }    

//        [ClassCleanup]
//        public static void TearDown()
//        {
//            window.Close();
//            application.Close();
//        }
//    }
//}
