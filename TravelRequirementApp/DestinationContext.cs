using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRequirementApp.Model;

namespace TravelRequirementApp
{
    public class DestinationContext : DbContext
    {
       public DbSet<DestinyInfo> Destinations {get; set;} 
    }
}
