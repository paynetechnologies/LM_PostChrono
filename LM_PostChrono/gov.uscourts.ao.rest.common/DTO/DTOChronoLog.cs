using gov.uscourts.ao.rest.common.Interfaces.IDTO;
using gov.uscourts.ao.rest.dal.Domain;
using System;

namespace gov.uscourts.ao.rest.common.DTO

{
    public class DTOChronoLog : IDTOChronoLog
    {
            public string attempted { get; set; }
            public string author { get; set; }
            public string authorCode { get; set; }
            public string clientId { get; set; }

            public string chronosCode { set; get; }
            public string chronosNotes { get; set; }
            public string chronosStatus { get; set; }
            public string confidential { get; set; }

            public string contactDate { get; set; }
            public string contactTime { get; set; }
            public string createdBy { get; set; }
            public string createdOn { get; set; }

            public string districtId { get; set; }
            public string nonCompliance { get; set; }
            public string planChange { get; set; }
            public string probPts { set; get; }

            public string respNoncompliance { get; set; }
            public string thirdPartyRisk { get; set; }

            //public ChronoStatus chronoStatus { get; set; }

        /// <summary>
        /// Build ChronoLog from a list or parameters
        /// </summary>
        /// <param name="pAttempted"></param>
        /// <param name="pAuthor"></param>
        /// <param name="pAuthorCode"></param>
        /// <param name="pClientId"></param>
        /// <param name="pChronosCode"></param>
        /// <param name="pChronosNotes"></param>
        /// <param name="pChronosStatus"></param>
        /// <param name="pConfidential"></param>
        /// <param name="pContactDate"></param>
        /// <param name="pContactTime"></param>
        /// <param name="pCreatedBy"></param>
        /// <param name="pCreatedOn"></param>
        /// <param name="pDistrictId"></param>
        /// <param name="pNoncompliance"></param>
        /// <param name="pPlanChange"></param>
        /// <param name="pProbPts"></param>
        /// <param name="pRespNoncompliance"></param>
        /// <param name="pThirdPartyRisk"></param>
        public DTOChronoLog(string pAttempted, string pAuthor, string pAuthorCode, string pClientId,
                            string pChronosCode, string pChronosNotes, string pChronosStatus, string pConfidential,
                            string pContactDate, string pContactTime, string pCreatedBy, string pCreatedOn,
                            string pDistrictId, string pNoncompliance, string pPlanChange, string pProbPts,
                            string pRespNoncompliance, string pThirdPartyRisk)
        {
            attempted = pAttempted;
            author = pAuthor;
            authorCode = pAuthorCode;
            clientId = pClientId;

            chronosCode = pChronosCode;
            chronosNotes = pChronosNotes;
            chronosStatus = pChronosStatus;
            confidential = pConfidential;

            contactDate = pContactDate;
            contactTime = pContactTime;
            createdBy = pCreatedBy;
            createdOn = pCreatedOn;

            districtId = pDistrictId;
            respNoncompliance = pNoncompliance;
            planChange = pPlanChange;
            probPts = pProbPts;

            respNoncompliance = pRespNoncompliance;
            thirdPartyRisk = pThirdPartyRisk;
        }

    }

}
