using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;


namespace TravelRequirementAppTest
{
    [TestClass]
    public class UITests
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;

        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TravelRequirementTest\\bin\\Debug\\TravelRequirementApp");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
        }
        
        [TestMethod]
        public void TestZeroState()
        {
            TextBox text_box = window.Get<TextBox>("EnterDestination");
            Label label = window.Get<Label>("DestinationsLabel");
            Button submit = window.Get<Button>("SubmitButton");

            Assert.IsTrue(text_box.Enabled);
            Assert.AreEqual(text_box.Text, "");
            Assert.IsTrue(submit.Enabled);
            Assert.AreEqual(label.Text, "Destination");

        }
        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        
        }
    }
}
