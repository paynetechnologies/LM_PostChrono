using gov.uscourts.ao.rest.dal.Interfaces.IDomain;
using System;
using System.ComponentModel.DataAnnotations;

namespace gov.uscourts.ao.rest.dal.Domain
{
    /// <summary>
    /// DTO for Chronos
    /// If chrono Posted with success, log is not used; Otherwise, log is written to database;
    /// </summary>
    public class ChronoLog : IChronoLog
    {
        [Key]
        public int ChronoLogId { get; set; }
        // CAN BE NULL
        public int PactsChronoId { get; set; }
        [Required]
        public string attempted { get; set; }
        // CAN BE NULL
        public string author { get; set; }
        [Required]
        public string authorCode { get; set; }
        [Required]
        public string clientId { get; set; }
        [Required]
        public string chronosCode { set; get; }
        [Required]
        public string chronosNotes { get; set; }
        // CAN BE NULL
        public string chronosStatus { get; set; }
        [Required]
        public string confidential { get; set; }
        [Required]
        public string contactDate { get; set; }
        [Required]
        public string contactTime { get; set; }
        [Required]
        public string createdBy { get; set; }
        [Required]
        public string createdOn { get; set; }
        [Required]
        public string districtId { get; set; }
        [Required]
        public string noncompliance { get; set; }
        [Required]
        public string planChange { get; set; }
        [Required]
        public string probPts { set; get; }
        [Required]
        public string respNoncompliance { get; set; }
        [Required]
        public string thirdPartyRisk { get; set; }

        [Required]
        public virtual ChronoStatus chronoStatus { get; set; }

    }
}
