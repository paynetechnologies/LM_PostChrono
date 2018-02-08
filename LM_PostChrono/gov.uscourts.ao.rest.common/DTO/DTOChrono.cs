using gov.uscourts.ao.rest.common.Interfaces.IDTO;
using System;

namespace gov.uscourts.ao.rest.common.DTO

{
    public class DTOChrono : IDTOChrono
    {
        public string Attempted { get; set; }
        public string Author { get; set; }
        public string AuthorCode { get; set; }
        public string ClientId { get; set; }

        public string ChronosCode { set; get; }
        public string ChronosNotes { get; set; }
        public string ChronosStatus { get; set; }
        public string Confidential { get; set; }

        public string ContactDate { get; set; }
        public string ContactTime { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }

        public string DistrictId { get; set; }
        public string NonCompliance { get; set; }
        public string PlanChange { get; set; }
        public string ProbPts { set; get; }

        public string RespNoncompliance { get; set; }
        public string ThirdPartyRisk { get; set; }


        public DTOChrono(string sAttempted, string sAuthor, string sAuthorCode, string sClientId,
                    string sChronosCode, string sChronosNotes, string sChronosStatus, string sConfidential,
                    string sContactDate, string sContactTime, string sCreatedBy, string sCreatedOn,
                    string sDistrictId, string sNonCompliance, string sPlanChange, string sProbPts,
                    string sRespNoncompliance, string sThirdPartyRisk)
        {
            Attempted = sAttempted;
            Author = sAuthor;
            AuthorCode = sAuthorCode;
            ClientId = sClientId;

            ChronosCode = sChronosCode;
            ChronosNotes = sChronosNotes;
            ChronosStatus = sChronosStatus;
            Confidential = sConfidential;

            ContactDate = sContactDate;
            ContactTime = sContactTime;
            CreatedBy = sCreatedBy;
            CreatedOn = sCreatedOn;

            DistrictId = sDistrictId;
            NonCompliance = sNonCompliance;
            PlanChange = sPlanChange;
            ProbPts = sProbPts;

            RespNoncompliance = sRespNoncompliance;
            ThirdPartyRisk = sThirdPartyRisk;
        }



        public DTOChrono(string pAttempted, string pAuthor, string pAuthorCode, string pClientId,
                            string pChronosCode, string pChronosNotes, string pChronosStatus, string pConfidential,
                            DateTime pContactDate, DateTime pContactTime, string pCreatedBy, DateTime pCreatedOn,
                            string pDistrictId, string pNonCompliance, string pPlanChange, string pProbPts,
                            string pRespNoncompliance, string pThirdPartyRisk)
        {
            Attempted = pAttempted;
            Author = pAuthor;
            AuthorCode = pAuthorCode;
            ClientId = pClientId;

            ChronosCode = pChronosCode;
            ChronosNotes = pChronosNotes;
            ChronosStatus = pChronosStatus;
            Confidential = pConfidential;

            ContactDate = pContactDate.ToString("yyyy-MM-dd");
            ContactTime = pContactTime.ToString("HH:mm") != "00:00" ? pContactTime.ToString("HH:mm") : "00:01";
            CreatedBy = pCreatedBy;
            CreatedOn = pCreatedOn.ToString("yyyy-MM-ddTHH:mm:ss");

            DistrictId = pDistrictId;
            NonCompliance = pNonCompliance;
            PlanChange = pPlanChange;
            ProbPts = pProbPts;

            RespNoncompliance = pRespNoncompliance;
            ThirdPartyRisk = pThirdPartyRisk;
        }
    }

}
