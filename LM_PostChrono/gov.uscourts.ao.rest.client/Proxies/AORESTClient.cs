using RestSharp;
using System.Configuration;
using gov.uscourts.ao.rest.client.Support;
using System.Net;
using gov.uscourts.ao.rest.client.IProxies;
using gov.uscourts.ao.rest.client.ISupport;
using System.Collections.Generic;

namespace gov.uscourts.ao.rest.client
{
    public  partial class AORestClient : IAORestClient
    {
        /// <summary>
        ///     baseURL is the DNS name where the resources can be found
        ///     in the form of: http://www.somerestapi.com/
        /// </summary>
       
        public string baseURL { get; set; }
        
        /// <summary>
        /// Clients can configure the HTTP request, serializer, etc
        /// Accept
        ///     application/atom+xml
        ///     application/rss+xml
        ///     application/json
        ///     text/xml
        /// Content-Type
        ///     application/atom+xml
        ///     application/rss+xml
        ///     application/json
        ///     text/xml
        /// </summary>
        
        public IClientConfiguration DefaultConfiguration { get; set; }

        public AORestClient()
        {
            DefaultConfiguration = new ClientConfiguration();
            DefaultConfiguration.Accept = "application/json";
            DefaultConfiguration.ContentType = "application/json";
            DefaultConfiguration.RequrieSession = false;
            DefaultConfiguration.OutBoundSerializerAdapter = new JsonSerializerAdapter();
            DefaultConfiguration.InBoundSerializerAdapter = new JsonSerializerAdapter();
            DefaultConfiguration.additionalHeader = new Dictionary<string, string>();
            baseURL = ConfigurationManager.AppSettings["RestBaseURL"];
        }

        /// <summary>
        /// Create the client using the base URL
        /// </summary>
        /// <param name="baseURL"></param>
        /// <param name="clientConfig"></param>
        /// <returns></returns>
        public RestClient CreateClient(string baseURL, IClientConfiguration clientConfig)
        {
            return new RestClient(baseURL);
        }

        /// <summary>
        /// Create the client using the base URL
        /// </summary>
        /// <param name="baseURL"></param>
        /// <param name="clientConfig"></param>
        /// <returns></returns>
        public RestClient CreateClient(string baseURL)
        {
            return new RestClient(baseURL);
        }
        /// <summary>
        /// Create the request using a resource URI 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="clientConfig"></param>
        /// <returns></returns>
        private RestRequest CreateRequest(string uri, IClientConfiguration clientConfig)
        {
            var request = new RestRequest(uri);
            request.AddHeader("Accept", clientConfig.Accept);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("ContentType", clientConfig.ContentType);
            request.AddHeader("Accept", clientConfig.Accept);
            foreach (KeyValuePair<string, string> s in clientConfig.additionalHeader)
            {
                request.AddHeader(s.Key, s.Value);
            }
            request.RequestFormat = DataFormat.Json;

            return request;
        }

        /// <summary>
        /// Post data to service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="clientConfig"></param>
        /// <param name="data"></param>
        private bool PostData<T>(RestRequest request, IClientConfiguration clientConfig, T data)
        {
            var restClient = new RestClient(baseURL);
            var response = restClient.Execute(request);
            return (response.StatusCode == HttpStatusCode.OK);

        }

        /// <summary>
        /// Post data to service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="clientConfig"></param>
        /// <param name="data"></param>
        private bool PostData<T>(RestClient restClient, RestRequest request, IClientConfiguration clientConfig, T data)
        {
            var response = restClient.Execute(request);
            return (response.StatusCode == HttpStatusCode.OK);
        }

        /// <summary>
        /// Get data from the service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="clientConfig"></param>
        /// <returns></returns>
        private T GetData<T>(RestRequest request, IClientConfiguration clientConfig)
        {
            var restClient = new RestClient(baseURL);
            var response = restClient.Execute(request);
            string jsonResponseString = response.Content;
            return clientConfig.InBoundSerializerAdapter.Deserialize<T>(jsonResponseString);
        }


        /// TS 
        /// Get data from the service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="clientConfig"></param>
        /// <returns></returns>
        private T GetData<T>(RestClient restClient, RestRequest request, IClientConfiguration clientConfig)
        {
            var response = restClient.Execute(request);
            string jsonResponseString = response.Content;
            return clientConfig.InBoundSerializerAdapter.Deserialize<T>(jsonResponseString);
        }

    }
}
