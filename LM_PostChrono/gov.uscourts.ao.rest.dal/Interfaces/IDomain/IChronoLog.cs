
using gov.uscourts.ao.rest.dal.Domain;
namespace gov.uscourts.ao.rest.dal.Interfaces.IDomain
{
    public interface IChronoLog : IDomainObject
    {
        int ChronoLogId { get; set; }
        int PactsChronoId { get; set; }
        string attempted { get; set; }
        string author { get; set; }
        string authorCode { get; set; }
        string clientId { get; set; }
        string chronosCode { set; get; }
        string chronosNotes { get; set; }
        string chronosStatus { get; set; }
        string confidential { get; set; }
        string contactDate { get; set; }
        string contactTime { get; set; }
        string createdBy { get; set; }
        string createdOn { get; set; }
        string districtId { get; set; }
        string noncompliance { get; set; }
        string planChange { get; set; }
        string probPts { set; get; }
        string respNoncompliance { get; set; }
        string thirdPartyRisk { get; set; }
        ChronoStatus chronoStatus { get; set; }

    }
}
