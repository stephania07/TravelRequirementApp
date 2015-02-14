using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelRequirementApp.Model;

namespace TravelRequirementApp.Repository
{
    public class DestinyInfoRepository : IDestinyInfoRepository
    {
        private DestinationContext _dbContext;

        public DestinyInfoRepository()
        {
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
        
        public IEnumerable<DestinyInfo> PastDestinations()
        {
            throw new NotImplementedException();
        }
        
        public  IEnumerable<DestinyInfo> All()
        {
            var qu = from DestinyInfo in _dbContext.Destinations select DestinyInfo;
            return qu.ToList<Model.DestinyInfo>();
        }
        public DestinyInfo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DestinyInfo GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DestinyInfo> SearchFor(Expression<Func<DestinyInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
