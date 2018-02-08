using gov.uscourts.ao.rest.common.Interfaces.IDTO;
using gov.uscourts.ao.rest.dal.Domain;
using gov.uscourts.ao.rest.dal.Interfaces.IDomain;
using System;

namespace gov.uscourts.ao.rest.common.DTO
{
    public class DTOChronoJson : IDTOChronoJson
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

        public chronosContact[] chronosContacts { get; set; }

        /// <summary>
        /// Create DTOChronoJson using Object Initializer Pattern
        ///         
        /*
         * DTOChronoJson cj = new DTOChronoJson()
         * {
         *     field1 = x,
         *     field2 = y,
         *     field3 = z
         *     };
         */
        /// </summary>
        public DTOChronoJson() { }


        public DTOChronoJson(IDTOChrono p)
        {
            attempted = p.Attempted;
            author = p.Author;
            authorCode = p.AuthorCode;
            clientId = p.ClientId;

            chronosCode = p.ChronosCode;
            chronosNotes = p.ChronosNotes;
            chronosStatus = p.ChronosStatus;
            confidential = p.Confidential;

            //contactDate = p.ContactDate.ToString("yyyy-MM-dd"); 
            //contactTime = p.ContactTime.ToString("HH:mm") != "00:00" ? p.ContactTime.ToString("HH:mm") : "00:01";
            //createdBy = p.CreatedBy;
            //createdOn = p.ContactDate.ToString("yyyy-MM-dd"); 


            contactDate = p.ContactDate;
            contactTime = p.ContactTime;
            createdBy = p.CreatedBy;
            createdOn = p.ContactDate;


            districtId = p.DistrictId;
            nonCompliance = p.NonCompliance;
            planChange = p.PlanChange;
            probPts = p.ProbPts;

            respNoncompliance = p.RespNoncompliance;
            thirdPartyRisk = p.ThirdPartyRisk;

            chronosContacts = new chronosContact[]
            {
                new chronosContact()
                {
                    id = new chronosContactPK()
                {
                    chronosCode =  p.ChronosCode, //"C-TREAT" etc...
                    probPts =  p.ProbPts,
                },
                //createdOn =  p.ContactDate.ToString("yyyy-MM-dd"), //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdOn =  p.ContactDate, //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdBy =  p.AuthorCode, //"364"
                }
            };
        }

        /// <summary>
        /// Build ChronoJson from database ChronoLog 
        /// </summary>
        /// <param name="p"></param>
        public DTOChronoJson(IChronoLog p)
        {
            attempted = p.attempted;
            author = p.author;
            authorCode = p.authorCode;
            clientId = p.clientId;

            //chronosCode = p.chronosCode;
            chronosNotes = p.chronosNotes;
            chronosStatus = p.chronosStatus;
            confidential = p.confidential;

            contactDate = p.contactDate;
            contactTime = p.contactTime;
            createdBy = p.createdBy;
            createdOn = p.contactDate;

            districtId = p.districtId;
            nonCompliance = p.noncompliance;
            planChange = p.planChange;
            probPts = p.probPts;

            respNoncompliance = p.respNoncompliance;
            thirdPartyRisk = p.thirdPartyRisk;

            chronosContacts = new chronosContact[]
            {
                new chronosContact()
                {
                    id = new chronosContactPK()
                {
                    chronosCode =  p.chronosCode, //"C-TREAT" etc...
                    probPts =  p.probPts,
                },
                createdOn =  p.contactDate,
                createdBy =  p.authorCode,
                }
            };
        }

        /// <summary>
        /// Build ChronoJson from a list of parameters
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
        public DTOChronoJson(string pAttempted, string pAuthor, string pAuthorCode, string pClientId,
                            string pChronosCode, string pChronosNotes, string pChronosStatus, string pConfidential,
                            DateTime pContactDate, DateTime pContactTime, string pCreatedBy, DateTime pCreatedOn,
                            string pDistrictId, string pNoncompliance, string pPlanChange, string pProbPts,
                            string pRespNoncompliance, string pThirdPartyRisk)
        {
            attempted = pAttempted;
            author = pAuthor;
            authorCode = pAuthorCode;
            clientId = pClientId;

            //chronosCode = pChronosCode;
            chronosNotes = pChronosNotes;
            chronosStatus = pChronosStatus;
            confidential = pConfidential;

            contactDate = pContactDate.ToString("yyyy-MM-dd"); 
            contactTime = pContactTime.ToString("HH:mm") != "00:00" ? pContactTime.ToString("HH:mm") : "00:01";
            createdBy = pCreatedBy;
            createdOn = pContactDate.ToString("yyyy-MM-dd"); 

            districtId = pDistrictId;
            nonCompliance = pNoncompliance;
            planChange = pPlanChange;
            probPts = pProbPts;

            respNoncompliance = pRespNoncompliance;
            thirdPartyRisk = pThirdPartyRisk;

            chronosContacts = new chronosContact[]
            {
                new chronosContact()
                {
                    id = new chronosContactPK()
                {
                    chronosCode =  pChronosCode, //"C-TREAT" etc...
                    probPts =  pProbPts,
                },
                createdOn =  pContactDate.ToString("yyyy-MM-dd"), //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdBy =  pAuthorCode, //"364"
                }
            };
        }

        /// <summary>
        /// /// Build ChronoJson from a list of parameters and ChronoContact from interal method
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
        public DTOChronoJson(string pAttempted, string pAuthor, string pAuthorCode, string pClientId,
                            string pChronosCode, string pChronosNotes, string pChronosStatus, string pConfidential,
                            string pContactDate, string pContactTime, string pCreatedBy, string pCreatedOn,
                            string pDistrictId, string pNoncompliance, string pPlanChange, string pProbPts,
                            string pRespNoncompliance, string pThirdPartyRisk)
        {
            attempted = pAttempted;
            author = pAuthor;
            authorCode = pAuthorCode;
            clientId = pClientId;

            //chronosCode = pChronosCode;
            chronosNotes = pChronosNotes;
            chronosStatus = pChronosStatus;
            confidential = pConfidential;

            contactDate = pContactDate;
            contactTime = pContactTime;
            createdBy = pCreatedBy;
            createdOn = pContactDate;

            districtId = pDistrictId;
            nonCompliance = pNoncompliance;
            planChange = pPlanChange;
            probPts = pProbPts;

            respNoncompliance = pRespNoncompliance;
            thirdPartyRisk = pThirdPartyRisk;

            chronosContacts = CreateChronoContacts();
        }

        internal chronosContact[] CreateChronoContacts()
        {
            return new chronosContact[]
            {
                new chronosContact()
                {
                    id = new chronosContactPK()
                {
                    chronosCode =  this.chronosCode, //"C-TREAT" etc...
                    probPts =  this.probPts,
                },
                createdOn =  this.contactDate, //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdBy =  this.authorCode, //"364"
                }
            };
        }
    }
}
