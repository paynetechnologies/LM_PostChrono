using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestERS.Model
{
    public class Chrono
    {
        [Required]
        public string attempted {get; set;}
   
        public string author {get; set;}

        [Required]
        public string authorCode {get; set;}

        [Required]        
        public ChronosContact[] chronosContacts {get; set;}
    
        public string chronosNotes {get; set;}
        public string chronosStatus {get; set;}

        [Required]        
        public string clientId {get; set;}

        [Required]        
        public string confidential {get; set;}

        [Required]        
        public string contactDate {get; set;}
      
        public string contactTime {get; set;}

        [Required]        
        public string noncompliance {get; set;}

        [Required]        
        public string planChange {get; set;}

        [Required]        
        public string probPts {get; set;}

        [Required]        
        public string respNoncompliance {get; set;}

        [Required]        
        public string thirdPartyRisk {get; set;}

        [Required]        
        public string createdOn {get; set;}

        [Required]        
        public string createdBy {get; set;}

        public string updatedOn {get; set;}
        public string updatedBy {get; set;}

    }

    public class ChronosContact
    {
        [Required]
        public ChronosContactPK id {get; set;}

        [Required]
        public string createdOn {get; set;}

        [Required]
        public string createdBy {get; set;}
    }

    public class ChronosContactPK
    {
        [Required]
        public string chronosCode {set; get;}

        [Required]
        public string probPts  {set; get;}
    }
}
