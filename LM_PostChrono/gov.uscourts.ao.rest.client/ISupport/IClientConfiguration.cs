using gov.uscourts.ao.rest.client.Support;
using System.Collections.Generic;

namespace gov.uscourts.ao.rest.client.ISupport
{
    public interface IClientConfiguration
    {
        string Accept { get; set; }
        string ContentType { get; set; }
        ISerializerAdapter InBoundSerializerAdapter { get; set; }
        ISerializerAdapter OutBoundSerializerAdapter { get; set; }
        bool RequrieSession { get; set; }
        Dictionary<string, string> additionalHeader { get; set; }
    }

    public interface IPACTSClientConfiguration : IClientConfiguration
    {
        string authenticationToken { get; set; }
        string districtId { get; set; }
    }

    public interface ITSClientConfiguration : IClientConfiguration
    {
        string authenticator { get; set; }
    }
}
