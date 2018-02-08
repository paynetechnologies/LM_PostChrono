using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.uscourts.ao.rest.ts.Domain
{
    public class Staff
    {
        public int staffID { get; set; }
        public bool alwaysShow { get; set; }
        public string type { get; set; }
        public string location { get; set; }
        public bool probation { get; set; }
        public bool pretrial { get; set; }
        public bool combined { get; set; }
        public bool management { get; set; }
        public string badgeNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string initials { get; set; }
        public string title { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string fax { get; set; }
        public string beeper { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public string caseloadURL { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string officePhone { get; set; }
        public string officeFax { get; set; }
        public string superURL { get; set; }
        public int superID { get; set; }
        public string superType { get; set; }
        public string superLocation { get; set; }
        public string superFirstName { get; set; }
        public string superLastName { get; set; }
        public string superMiddleName { get; set; }
        public string superTitle { get; set; }
        public string superPhone1 { get; set; }
        public string superPhone2 { get; set; }
        public string superFax { get; set; }
        public string superBeeper { get; set; }
        public string superEmail { get; set; }
        public string superDescription { get; set; }
    }
}
