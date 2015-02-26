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
        IEnumerable<DestinyInfo> All();
        DestinyInfo GetById(int id);
        DestinyInfo GetByDestination(string destination);
       Dictionary<string, string> GetDestinationInfo(string country);
        

    }
}
