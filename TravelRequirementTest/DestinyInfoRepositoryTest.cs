using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelRequirementApp.Repository;
using TravelRequirementApp.Model;



namespace TravelRequirementAppTest
{   
    /// <summary>
    /// Summary description for DestinyInfoRepositoryTest
    /// </summary>
    [TestClass]
    public class DestinyInfoRepositoryTest
    {
        private static DestinyInfoRepository repo;

        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            //Pass the name of the connection string TAG not the
            //name of the database you want to use
            repo = new DestinyInfoRepository("Name=TestDB");
            repo.Clear();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            repo.Clear();
            repo.Dispose();
        }
        [TestCleanup]
        public void ClearDatabase()
        {
            repo.Clear();
        }

        [TestMethod]
        public void TestAddToDatabase()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new DestinyInfo("Australia", "Must be valid at the time of entry", "None", "None", "Yes", " " ));
            repo.Add(new DestinyInfo("Ghana", "valid at entry time", "must be declared", "Yes", "Yes", " "));
            repo.Add(new DestinyInfo("Italy", "three month validity", "must be declared", "None", "Yes", " "));
            Assert.AreEqual(3, repo.GetCount());
        }

        [TestMethod]
        public void TestAllMethod()
        {
            repo.Add(new DestinyInfo("Australia", "Must be valid at the time of entry", "None", "None", "Yes", " "));
            repo.Add(new DestinyInfo("Bahrain", "six month", "must be declared", "None", "Yes", " "));
            Assert.AreEqual(2, repo.GetCount());
        }
        [TestMethod]
        public void TestGetCount()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new DestinyInfo("Eritrea", "six month validity","must be declared", "None", "Yes", " "));
            repo.Add(new DestinyInfo("France", "three month", "must be declared", "None", "Yes", " "));
            Assert.AreEqual(2, repo.GetCount());
        }
        [TestMethod]
        public void TestClear()
        {
            repo.Add(new DestinyInfo("Germany", "Must be valid for three months", "10,000Euros", "Not required", "Not required", " "));
            repo.Clear();
            Assert.AreEqual(0, repo.GetCount());
        }

        //[TestMethod]
        //public void TestDelete()
        //{
        //    Assert.AreEqual(1, repo.GetCount());
        //    repo.Delete(new DestinyInfo("Germany", "Must be valid for three months", "10,000Euros", "Not required", "Not required", "Note"));
        //    Assert.AreEqual(0, repo.GetCount());

        //}
        //To be revised
        //[TestMethod]
        //public void TestDeleteSelectedList() 
        //{
        //    List<DestinyInfo> destination = repo.All();
        //    var destiny = destination[0];
        //    int destinyId = destiny.DestinyId;
        //    repo.Add(new DestinyInfo("Germany", "Must be valid for three months", "10,000Euros", "Not required", "Not required", "Note"));

        //    int selectedDestinyId = repo.GetById(destinId)[0].DestinyId;

        //    Assert.AreEqual(1, repo.GetCount());
        //    repo.Delete(selectedDestinyId);
        //    Assert.AreEqual(0, repo.GetCount());

        //}

        [ExpectedException(typeof(ArgumentException))]
        public void DestinationAreUnique()
        {
            repo.Clear();
            repo.Add(new DestinyInfo("France", "three month", "must be declared", "None", "Yes", " "));
            repo.Add(new DestinyInfo("France", "three month", "must be declared", "None", "Yes", " "));

        }
    }
}
