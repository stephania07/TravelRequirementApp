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
        //private string p;

        public int DestinyInfoId { get; set; }
        public string Destination { get; set; }
        public string PassportValidity { get; set; }
        public string CurrencyRestriction { get; set; }
        public string Vaccination { get; set; }
        public string TouristVisaRequirement { get; set; }
        public string Note { get; set; }

        public DestinyInfo() 
        { //
        }
        public DestinyInfo(string Destination, string PassportValidity, string CurrencyRestriction, string Vaccination, string TouristVisaRequirement, string Note)
        {
            
            this.Destination = Destination;
            this.PassportValidity = PassportValidity;
            this.CurrencyRestriction = CurrencyRestriction;
            this.Vaccination = Vaccination;
            this.TouristVisaRequirement = TouristVisaRequirement;
            this.Note = Note;
        }
    }
}
