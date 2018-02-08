using gov.uscourts.ao.rest.client.ISupport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace gov.uscourts.ao.rest.client.Support
{
    public class AORestSupport
    {/* empty */}

    // Defines interface for the serializers
    public interface ISerializerAdapter
    {
        string Serialize(object obj);
        T Deserialize<T>(string input);
    }

    public class JsonSerializerAdapter : ISerializerAdapter
    {
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj); 
        }

        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }

    // The configuration class defines how the rest call is made.
    public class ClientConfiguration : IClientConfiguration
    {
        public string Accept { get; set; }
        public string ContentType { get; set; }
        public bool RequrieSession { get; set; }
        public ISerializerAdapter OutBoundSerializerAdapter { get; set; }
        public ISerializerAdapter InBoundSerializerAdapter { get; set; }
        public Dictionary<string, string> additionalHeader { get; set; }
        
        public ClientConfiguration()
        {
            Accept = "application/json";
            ContentType = "application/json";
            RequrieSession = false;
            OutBoundSerializerAdapter = new JsonSerializerAdapter();
            InBoundSerializerAdapter = new JsonSerializerAdapter();
            additionalHeader = new Dictionary<string, string>();
        }
    }

    // The configuration class defines how the rest call is made.
    public class PACTSClientConfiguration : ClientConfiguration, IPACTSClientConfiguration
    {
        public string authenticationToken { get; set; }
        public string districtId { get; set; }
    }

    // The configuration class defines how the rest call is made.
    public class TSClientConfiguration : ClientConfiguration,  ITSClientConfiguration
    {
        public string authenticator { get; set; }
    }

    // The delegates use for asychronous calls
    public delegate void RestCallBack<T>(Exception ex, T result);
    public delegate void RestCallBackNonQuery(Exception ex);
}
