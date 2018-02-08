using System;
namespace gov.uscourts.ao.rest.common.Interfaces.IBLL
{
    public interface IBLLChronoData
    {
        string Attempted { get; set; }
        string ChronoCode { get; set; }
        DateTime ChronoDate { get; set; }
        DateTime ChronoDateTime { get; set; }
        string ChronoNotes { get; set; }
        DateTime ChronoTime { get; set; }
        string ChronoType { get; set; }
        string ClientID { get; set; }
        string Confidential { get; set; }
        string DistrictID { get; set; }
        string Noncompliance { get; set; }
        string PlanChange { get; set; }
        string RespNoncompliance { get; set; }
        string StaffID { get; set; }
        string StaffLastName { get; set; }
        string ThirdPartyRisk { get; set; }
        string VendorID { get; set; }
    }
}
