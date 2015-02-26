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
    
       public List<string> countries = new List<string> { "Germany", "England", "Australia", "Sweden" };
        public Dictionary<string, string> Germany = new Dictionary<string, string>();
        private void PopulateGermany()
        {
            Germany.Add("Passport Validity", "Must be valid for three months");
            Germany.Add("Vaccination", "Not Required");
            Germany.Add("Currency Restriction", "10,000Euros");
            Germany.Add("Travel Visa Requirement", "Not required");
            Germany.Add("Destination", "Germany");  
        }
        public Dictionary<string, string> England = new Dictionary<string, string>();
        private void PopulateEngland()
        {
            England.Add("Passport Validity", "Must be valid for duration of your stay");
            England.Add("Vaccination", "Not Required");
            England.Add("Currency Restriction", "None");
            England.Add("Travel Visa Requirement", "Not required");
            England.Add("Destination", "England");
        }
        public Dictionary<string, string> Australia = new Dictionary<string, string>();
        private void PopulateAustralia()
        {
            Australia.Add("Passport Validity", "Must be valid at the time of entry");
            Australia.Add("Vaccination", "None");
            Australia.Add("Currency Restriction", "None");
            Australia.Add("Travel Visa Requirement", "Yes");
            Australia.Add("Destination", "Australia");
        }
        public Dictionary<string, string> Sweden = new Dictionary<string, string>();
        private void PopulateSweden()
        {
            Sweden.Add("Passport Validity", "six months visa");
            Sweden.Add("Vaccination", "Not Required");
            Sweden.Add("Currency Restriction", "None");
            Sweden.Add("Travel Visa Requirement", "Yes required");
            Sweden.Add("Destination", "Sweden");
        }
       
    

        public DestinyInfoRepository()
        {
            PopulateGermany();
            PopulateEngland();
            PopulateAustralia();
            PopulateSweden();
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
            throw new NotImplementedException();
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
        public DestinyInfo GetById(int id)
        {
            var query = from DestinyInfo in _dbContext.Destinations
                        where DestinyInfo.DestinyInfoId == id
                        select DestinyInfo;
            return query.First<Model.DestinyInfo>();
        }

        public Model.DestinyInfo GetByDestination(string destination)
        {
            var query = from DestinyInfo in _dbContext.Destinations
                        where DestinyInfo.Destination == destination
                        select DestinyInfo;
            return query.First<Model.DestinyInfo>();

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
                case "Sweden":
                    return Sweden;
            
                default:
                    return null;
            }
         }
    }
}
