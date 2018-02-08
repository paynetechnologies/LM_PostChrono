
using gov.uscourts.ao.rest.common.Interfaces.IBLL;
using System;

namespace gov.uscourts.ao.rest.common.BLL
{
    /// <summary>
    /// Chrono Object used to pass information to chrono Service Call
    /// </summary>
    public class BLLChronoData : IBLLChronoData
    {
        public string DistrictID { get; set; }
        public string VendorID { get; set; }
        public string ClientID { get; set; }
        public string StaffID { get; set; }

        public string StaffLastName { get; set; }
        public string ChronoType { get; set; }
        public string ChronoCode { get; set; }
        public string ChronoNotes { get; set; }

        public DateTime ChronoDate { get; set; }
        public DateTime ChronoTime { get; set; }
        public DateTime ChronoDateTime { get; set; }
        public string Attempted { get; set; }

        public string Noncompliance { get; set; }
        public string RespNoncompliance { get; set; }
        public string ThirdPartyRisk { get; set; }
        public string PlanChange { get; set; }

        public string Confidential { get; set; }


        public  BLLChronoData
            (string DistrictID, string VendorID, string ClientID, string StaffID
            , string StaffLastName, string ChronoType, string ChronoCode, string ChronoNotes
            , DateTime ChronoDate, DateTime ChronoTime, DateTime chronoDateTime, string attempted
            , string noncompliance, string resp_noncompliance, string third_party_risk, string plan_change
            , string confidential)
        {

            this.DistrictID = DistrictID;
            this.VendorID = VendorID;
            this.ClientID = ClientID;
            this.StaffID = StaffID;

            this.StaffLastName = StaffLastName;
            this.ChronoType = ChronoType;
            this.ChronoCode = ChronoCode;
            this.ChronoNotes = ChronoNotes;

            this.ChronoDate = ChronoDate;
            this.ChronoTime = ChronoTime;
            this.ChronoDateTime = chronoDateTime;
            this.Attempted = attempted;

            this.Noncompliance = noncompliance;
            this.RespNoncompliance = resp_noncompliance;
            this.ThirdPartyRisk = third_party_risk;
            this.PlanChange = plan_change;

            this.Confidential = confidential;

        }
    }
}