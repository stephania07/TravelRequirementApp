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
    public class UITests : TestHelper
    {
        [ClassInitialize]
        public static void SetupTests(TestContext _context)
        {
            TestHelper.SetupClass(_context);
                    
        }
        [TestInitialize]
        public void SetupTests()
        {
            TestHelper.TestPrep();
        }

        [TestCleanup]
        public void CleanUp()
        {
            TestHelper.CleanThisUp();
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
        
    }
}
