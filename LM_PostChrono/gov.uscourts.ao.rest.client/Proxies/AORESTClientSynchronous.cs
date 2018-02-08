using RestSharp;
using gov.uscourts.ao.rest.client.Support;
using gov.uscourts.ao.rest.client.IProxies;
using gov.uscourts.ao.rest.client.ISupport;
using System.Collections.Generic;

namespace gov.uscourts.ao.rest.client
{
    // ********************** Synchronous *************************
    public  partial class AORestClient : IAORestClient
    {
        //PACTS
        //public RestRequest CreatePACTSRequest(string uri, IPACTSClientConfiguration clientConfig)
        //{
        //    var request = CreateRequest(uri, clientConfig);
        //    request.AddHeader("Accept", clientConfig.Accept);
        //    request.AddHeader("authenticationToken", clientConfig.authenticationToken);
        //    request.AddHeader("districtId", clientConfig.districtId);
        //    request.RequestFormat = DataFormat.Json;
        //    return request;
        //}
        
        // Overloads
        public  TR RestGet<TR>(string url)
        {
            return RestGet<TR>(url, DefaultConfiguration);
        }
        
        // Basic
        public  TR RestGet<TR>(string uri, IClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            var request = CreateRequest(uri, clientConfig);            
            request.Method = Method.GET;

            return GetData<TR>(request, clientConfig);
        }

        //PACTS
        public TR RestGet<TR>(RestRequest request, IClientConfiguration clientConfig)
        {
            request.Method = Method.GET;
            return GetData<TR>(request, clientConfig);
        }

        //TS
        public TR RestGet<TR>(RestClient restClient, string uri, IClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            var request = CreateRequest(uri, clientConfig);
            request.Method = Method.GET;
            return GetData<TR>(restClient, request, clientConfig);
        }

        public TR RestGet<TR>(RestClient restClient, RestRequest request, IClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            request.Method = Method.GET;
            return GetData<TR>(restClient, request, clientConfig);

        }

        // ******** Synchronous GET, no response expected *******
        // Overloads
        public  void RestGetNonQuery(string url)
        {
            RestGetNonQuery(url, DefaultConfiguration);
        }

        public  void RestGetNonQuery(string url, IClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            var request = CreateRequest(url, clientConfig);
            request.Method = Method.GET;
            
            RestClient restClient = new RestClient();
            restClient.Execute(request);
        }

        //PACTS
        public void RestGetNonQuery(RestRequest request)
        {
            request.Method = Method.GET;
            RestClient restClient = new RestClient();
            restClient.Execute(request);
        }




        // ***************** POST ********************
        // Overload method
        public TR RestPost<TR, TI>(string url, TI data)
        {
            return RestPost<TR, TI>(url, data, DefaultConfiguration);
        }

        public TR RestPost<TR, TI>(string url, TI data, IClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            var request = CreateRequest(url, clientConfig);

            request.Method = Method.POST;

            var jsonRequestString = clientConfig.OutBoundSerializerAdapter.Serialize(data);
            request.AddParameter(clientConfig.ContentType, jsonRequestString,ParameterType.RequestBody);
            
            PostData(request, clientConfig, data);
            return GetData<TR>(request, clientConfig);
        }

        //PACTS
        public TR RestPost<TR, TI>(RestRequest request, TI data, IClientConfiguration clientConfig)
        {
            request.Method = Method.POST;
            var jsonRequestString = clientConfig.OutBoundSerializerAdapter.Serialize(data);
            request.AddParameter(clientConfig.ContentType, jsonRequestString, ParameterType.RequestBody);
            PostData(request, clientConfig, data);
            return GetData<TR>(request, clientConfig);
        }

        // ****** Synchronous GET, no respons expected ******

        // Overload method
        public bool RestPostNonQuery<TI>(string url, TI data)
        {
            return RestPostNonQuery(url, data, DefaultConfiguration);
        }

        public  bool RestPostNonQuery<TI>(string url, TI data, IClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            var request = CreateRequest(url, clientConfig);
            request.Method = Method.POST;
            var jsonRequestString = clientConfig.OutBoundSerializerAdapter.Serialize(data);
            request.AddParameter(clientConfig.ContentType, jsonRequestString, ParameterType.RequestBody);

            return (PostData(request, clientConfig, data));
        }

        //PACTS
        //public bool PACTSRestPostNonQuery<TI>(string url, TI data, IPACTSClientConfiguration clientConfig)
        //{
        //    var request = CreateRequest(url, clientConfig);
        //    request.Method = Method.POST;
        //    var jsonRequestString = clientConfig.OutBoundSerializerAdapter.Serialize(data);
        //    request.AddParameter(clientConfig.ContentType, jsonRequestString, ParameterType.RequestBody);
        //    return (PostData(request, clientConfig, data));
        //}
            
        public bool RestPostNonQuery<TI>(RestRequest request, TI data, IClientConfiguration clientConfig)
        {
            request.Method = Method.POST;
            var jsonRequestString = clientConfig.OutBoundSerializerAdapter.Serialize(data);
            request.AddParameter(clientConfig.ContentType, jsonRequestString, ParameterType.RequestBody);

            return (PostData(request, clientConfig, data));
        }

    }
}
