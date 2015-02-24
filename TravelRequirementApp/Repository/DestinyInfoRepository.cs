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
            Germany.Add("Passport Validity", "six months visa");
            Germany.Add("Vaccination", "Not Required");
            Germany.Add("Currency Restriction", "None");
            Germany.Add("Travel visa Requirement", "None");
            Germany.Add("Destination", "Germany");


        
        }
       
    

        public DestinyInfoRepository()
        {
            PopulateGermany();
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

            // throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public string GetDestinationInfo(string country, string field)
        {
            return ""; 
        }
    }
}
