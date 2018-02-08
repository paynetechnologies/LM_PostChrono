using System;

namespace gov.uscourts.ao.rest.common.Interfaces.IDTO
{
    public interface IDTOChrono
    {
        string Attempted { get; set; }
        string Author { get; set; }
        string AuthorCode { get; set; }
        string ClientId { get; set; }

        string ChronosCode { set; get; }
        string ChronosNotes { get; set; }
        string ChronosStatus { get; set; }
        string Confidential { get; set; }

        string ContactDate { get; set; }
        string ContactTime { get; set; }
        string CreatedBy { get; set; }
        string CreatedOn { get; set; }

        string DistrictId { get; set; }
        string NonCompliance { get; set; }
        string PlanChange { get; set; }
        string ProbPts { set; get; }

        string RespNoncompliance { get; set; }
        string ThirdPartyRisk { get; set; }
    }
}
