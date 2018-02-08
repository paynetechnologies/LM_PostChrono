using System;
namespace gov.uscourts.ao.rest.pacts.Interfaces
{
    public interface IPACTSRestGen3Config
    {
        PublicDomain.TzTimeZone GetTimeZone(string districtId);
    }
}
