using System;
namespace gov.uscourts.ao.rest.pacts.Interfaces
{
    public interface IPACTSRestDistrict
    {
        string GetPactsType(string ccid);
        string[] GetStaffName(string staffId, string districtId);
        void LogData(string msg, string staffId, string districtId);
    }
}
