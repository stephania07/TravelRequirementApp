using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;


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
            //TextBox list_box = window.Get<TextBox>("DestinationList");
            Label label = window.Get<Label>("DestinationsLabel");
            Button submit = window.Get<Button>("SubmitButton");
            Image worldmap = window.Get<Image>("WorldMap");
            TextBox titlebox = window.Get<TextBox>("TitleBox");
           
            //Assert.IsTrue(list_box.Enabled);
            //Assert.AreEqual(list_box.Text, "");
            Assert.IsTrue(submit.Enabled);
            Assert.AreEqual(label.Text, "Destination");
            Assert.IsTrue(worldmap.Visible);
            Assert.IsTrue(titlebox.IsReadOnly);
            
        }
        
    }
}
