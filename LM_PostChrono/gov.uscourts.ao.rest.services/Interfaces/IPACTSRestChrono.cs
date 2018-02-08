using gov.uscourts.ao.rest.common.DTO;
using gov.uscourts.ao.rest.common.Interfaces.IMAP;
using gov.uscourts.ao.rest.dal.Domain;

namespace gov.uscourts.ao.rest.pacts.Interfaces
{
    public interface IPACTSRestChrono
    {
        //DTOChrono LoadDTOChrono(
        //         int pactsId    , string lcd_id         , string CCID       , string chronoCode
        //    , string actionDesc , string actionType     , string firstName  , string lastName
        //    , string reportDate , string rejectReason   , string ProbPts    , string csid);

        //DTOChrono LoadDTOChrono(
        //            string pAttempted,          string pAuthor,         string pAuthorCode,     string pClientId,
        //            string pChronosCode,        string pChronosNotes,   string pChronosStatus,  string pConfidential,
        //            string pContactDate,        string pContactTime,    string pCreatedBy,      string pCreatedOn,
        //            string pDistrictId,         string pNonCompliance,  string pPlanChange,     string pProbPts,
                    //string pRespNoncompliance,  string pThirdPartyRisk);

        bool PostChrono(chronos chrono, string districtId);
        void PostFailedChrono(IMAPChronoLogToPactsChronos mapper);
        void LogFailedChrono(chronos chrono, string pDistrictId);

    }
}