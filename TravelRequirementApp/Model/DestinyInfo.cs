using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRequirementApp.Model
{
    public class DestinyInfo
    {
        public int DestinyInfoId { get; set; }
        public string Name { get; set; }
        public string passportvalidity { get; set; }

        public DestinyInfo() 
        { }
        public DestinyInfo(string DestinationName, string passportvalidity)
        {
            this.Name = DestinationName;
            this.passportvalidity = passportvalidity;
        }

    }
}
