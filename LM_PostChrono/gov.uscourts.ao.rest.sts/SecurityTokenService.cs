using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.uscourts.ao.rest.sts
{
    public class SecurityTokenService : ISecurityTokenService
    {

        // DEBUG STS Connections
        public void CheckSTS()
        {
            #region old SOAP
            //Binding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            //EndpointAddress address = new EndpointAddress("https://usppsesb-training.chnt.gtwy.dcn:8443/uspps-sts/sts");
            //SecurityTokenServiceClient tokenClient = new SecurityTokenServiceClient(binding, address);
            //string serviceToken = tokenClient.issueToken("username", "password");
            #endregion


            List<string> env = new List<string>();
            env.Add("SAND");
            env.Add("SANDA");
            env.Add("INT");
            env.Add("INTA");
            env.Add("TEST");
            env.Add("TESTA");
            env.Add("STAGE");
            env.Add("STAGEA");

            string baseUrl = System.Configuration.ConfigurationManager.AppSettings["StsBaseURL"];  //App.config
            string user = System.Configuration.ConfigurationManager.AppSettings["user"];  //App.config
            string pass = System.Configuration.ConfigurationManager.AppSettings["pass"];  //App.config

            string tkn = "";
            string newBaseURL = "";

            foreach (string e in env)
            {
                Console.WriteLine("=== Validating Environment : {0} ===", e.ToString());

                newBaseURL = baseUrl.Replace("ENVX", e);
                tkn = GetSTS(newBaseURL, user, pass);

                if (!String.IsNullOrEmpty(tkn))
                {
                    Console.WriteLine("*** Valid Environment : {0}", e.ToString());
                }
                else
                {
                    Console.WriteLine("??? InValid Environment : {0}", e.ToString());
                }
                Console.WriteLine("");
            }
        }

        public string GetSTS(string baseUrl, string user, string password)
        {
            // from RestSharp.dll
            var restClient = new RestClient(baseUrl); // Client to translate RestRequests into Http requests and process response results
            var request = new RestRequest(Method.POST);

            var stsUserPass = new Dictionary<string, string>
            {
                { "userName", user },
                { "password", password }
            };

            //Check HTTP Status
            try
            {
                request.AddParameter("application/json", JsonConvert.SerializeObject(stsUserPass), ParameterType.RequestBody);

                //Execute the request
                var response = restClient.Execute(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(String.Format("Rest Security Token Service StatusCode {0}", response.StatusCode));
                    return "response.StatusCode != System.Net.HttpStatusCode.OK";
                }

                //Get dynamic JSON
                dynamic tokenResponse = JsonConvert.DeserializeObject(response.Content);

                //Check for empty or null dynamic object
                if (tokenResponse.HasValues == false)
                {
                    Console.WriteLine(string.Format("Rest Security Token Service token response has no value : {0} ", response.Content));
                    return "Rest Security Token Service token response has no value";
                }
                
                return tokenResponse.token;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Rest Security Token Service Exception : {0}", ex.Message.ToString()));
            }
        }

        public string GetSTS()
        {
            string baseUrl = System.Configuration.ConfigurationManager.AppSettings["STSBaseURL"];  //App.config
            string SecurityToken_Username = System.Configuration.ConfigurationManager.AppSettings["SecurityTokenService_Username"];  //App.config
            string SecurityToken_Password = System.Configuration.ConfigurationManager.AppSettings["SecurityTokenService_Password"];  //App.config

            try
            {
                return (GetSTS(baseUrl, SecurityToken_Username, SecurityToken_Password));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
