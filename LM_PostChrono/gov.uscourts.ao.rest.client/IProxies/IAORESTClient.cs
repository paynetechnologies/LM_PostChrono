using gov.uscourts.ao.rest.client.ISupport;
using gov.uscourts.ao.rest.client.Support;
using RestSharp;
using System;

namespace gov.uscourts.ao.rest.client.IProxies
{
    public interface IAORestClient
    {
        IClientConfiguration DefaultConfiguration { get; set; }

        TR RestGet<TR>(string url);
        TR RestGet<TR>(string url, IClientConfiguration configuration);

        void RestGetNonQuery(string url);
        void RestGetNonQuery(string url, IClientConfiguration configuration);

        TR RestPost<TR, TI>(string url, TI data);
        TR RestPost<TR, TI>(string url, TI data, IClientConfiguration configuration);

        bool RestPostNonQuery<TI>(string url, TI data);
        bool RestPostNonQuery<TI>(string url, TI data, IClientConfiguration configuration);
        
        //pacts
        TR RestGet<TR>(RestRequest request, IClientConfiguration clientConfig);

        //ts
        TR RestGet<TR>(RestClient restClient, string url, IClientConfiguration clientConfig);
        TR RestGet<TR>(RestClient restClient, RestRequest request, IClientConfiguration clientConfig);
        
        TR RestPost<TR, TI>(RestRequest request, TI data, IClientConfiguration clientConfig);
        
        RestClient CreateClient(string baseURL);
        RestClient CreateClient(string baseURL, IClientConfiguration clientConfig);
        
        string baseURL { get; set; }
    }
}
