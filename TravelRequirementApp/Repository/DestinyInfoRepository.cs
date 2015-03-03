using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelRequirementApp.Model;
using TravelRequirementApp;

namespace TravelRequirementApp.Repository
{
    public class DestinyInfoRepository : IDestinyInfoRepository
    {
        private DestinationContext _dbContext;
    
       public List<string> countries = new List<string> { "Germany", "England", "Australia", "Italy", "Sweden" };
        public Dictionary<string, string> Germany = new Dictionary<string, string>();
        private void PopulateGermany()
        {
            Germany.Add("Passport Validity", "Must be valid for three months");
            Germany.Add("Vaccination", "Not Required");
            Germany.Add("Currency Restriction", "10,000Euros");
            Germany.Add("Travel Visa Requirement", "Not required");
            Germany.Add("Destination", "Germany");
            Germany.Add("Note", " ");  

        }
        public Dictionary<string, string> England = new Dictionary<string, string>();
        private void PopulateEngland()
        {
            England.Add("Passport Validity", "Must be valid for duration of your stay");
            England.Add("Vaccination", "Not Required");
            England.Add("Currency Restriction", "None");
            England.Add("Travel Visa Requirement", "Not required");
            England.Add("Destination", "England");
            England.Add("Note", " ");  

        }
        public Dictionary<string, string> Australia = new Dictionary<string, string>();
        private void PopulateAustralia()
        {
            Australia.Add("Passport Validity", "Must be valid at the time of entry");
            Australia.Add("Vaccination", "None");
            Australia.Add("Currency Restriction", "None");
            Australia.Add("Travel Visa Requirement", "Yes");
            Australia.Add("Destination", "Australia");
            Australia.Add("Note", " ");  

        }
        public Dictionary<string, string> Italy = new Dictionary<string, string>();
        private void PopulateItaly()
        {
            Italy.Add("Passport Validity", "three months validity");
            Italy.Add("Vaccination", "Not Required");
            Italy.Add("Currency Restriction", "10,000Euros or equivalent");
            Italy.Add("Travel Visa Requirement", "Not required");
            Italy.Add("Destination", "Italy");
            Italy.Add("Note", " ");  

        }

        public Dictionary<string, string> Sweden = new Dictionary<string, string>();
        private void PopulateSweden()
        {
            Sweden.Add("Passport Validity", "six months visa");
            Sweden.Add("Vaccination", "Not Required");
            Sweden.Add("Currency Restriction", "None");
            Sweden.Add("Travel Visa Requirement", "Yes required");
            Sweden.Add("Destination", "Sweden");
            Sweden.Add("Note", " ");  

        }

        public DestinyInfoRepository(string connection = "TravelRequirementApp.DestinationContext")
        {
            PopulateGermany();
            PopulateEngland();
            PopulateAustralia();
            PopulateSweden();
            PopulateItaly();
            _dbContext = new DestinationContext();
            _dbContext.Destinations.Load();
        }

        public DestinationContext Context()
        {
            return _dbContext;
        }

        public DbSet<Model.DestinyInfo> GetDbSet()
        {
            return _dbContext.Destinations;
        }

        public int GetCount()
        {
            return _dbContext.Destinations.Count<Model.DestinyInfo>();
        }

        public void Add(Model.DestinyInfo D)
        {
            _dbContext.Destinations.Add(D);
            _dbContext.SaveChanges();     
        }

        public void Delete(DestinyInfo D)
        {
            _dbContext.Destinations.Remove(D);
            _dbContext.SaveChanges();
        }

        public void Clear()
        {
            var a = this.All();
            _dbContext.Destinations.RemoveRange(a);
            _dbContext.SaveChanges();
        }
       
        
        public  IEnumerable<DestinyInfo> All()
        {
            var qu = from DestinyInfo in _dbContext.Destinations select DestinyInfo;
            return qu.ToList<Model.DestinyInfo>();
        }
        public DestinyInfo GetById(int DestinyInfoId)
        {
            //experimenting other options
            return _dbContext.Destinations.Find(DestinyInfoId);
            //var query = from DestinyInfo in _dbContext.Destinations
            //            where DestinyInfo.DestinyInfoId == DestinyInfoId
            //            select DestinyInfo;
            //return query.First<Model.DestinyInfo>();
        }

        public Model.DestinyInfo GetByDestination(string Destination)
        {
            var query = from DestinyInfo in _dbContext.Destinations
                        where DestinyInfo.Destination == Destination
                        select DestinyInfo;
            return query.First<Model.DestinyInfo>();

        }

        
        public void UpDateDB(string p, string s) 
        {
            var query = from DestinyInfo in _dbContext.Destinations
                        where DestinyInfo.Destination == s
                        select DestinyInfo;
            var selected = query.First<DestinyInfo>();
            selected.Note = p;
            _dbContext.SaveChanges();
          }

        
       public void Dispose()
        {
            _dbContext.Dispose();
        }

        public Dictionary<string, string> GetDestinationInfo(string country )
        {
            switch (country)
            {
                case "Germany":
                    return Germany;
                case "England":
                    return England;
                case "Australia":
                    return Australia;
                case "Italy":
                    return Italy;
                case "Sweden":
                    return Sweden;
            
                default:
                    return null;
            }
         }
    }
}
