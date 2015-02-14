using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelRequirementApp.Model;

namespace TravelRequirementApp.Repository
{
    public interface IDestinyInfoRepository
    {
        int GetCount();
        void Add(DestinyInfo D);
        void Delete(DestinyInfo D);
        void Clear();
        IEnumerable<DestinyInfo> PastDestinations();
        IEnumerable<DestinyInfo> All();
        DestinyInfo GetById(int id);
        DestinyInfo GetByName(string name);
        IQueryable<DestinyInfo> SearchFor(Expression<Func<DestinyInfo, bool>> predicate);

    }
}
