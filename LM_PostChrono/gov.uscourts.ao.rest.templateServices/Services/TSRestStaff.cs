using gov.uscourts.ao.rest.client.IProxies;
using gov.uscourts.ao.rest.ts.Domain;
using gov.uscourts.ao.rest.ts.Interfaces;
using log4net;
using RestSharp;
using System;
using System.Reflection;

namespace gov.uscourts.ao.rest.ts.Services
{
    public class TSRestStaff : ITSRestStaff
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        IAORestClient aoRestClient;

        public TSRestStaff(IAORestClient aoRestClient)
        {
            this.aoRestClient = aoRestClient;
        }


        public int GetAuthorCode(string districtId)
        {
            const string baseURL = "https://ts-int.opps.gtwy.dcn/v1/";

            const string user = "opps_soag_pacts";
            const string pass = "pacts4G00d";
            
            aoRestClient.baseURL = "https://ts-int.opps.gtwy.dcn/v1/";

            RestClient restClient = aoRestClient.CreateClient(baseURL);
            restClient.Authenticator = new HttpBasicAuthenticator(user, pass);
            //Equivalent Service Call: https://ts-int.opps.gtwy.dcn/v1/aztrain/client/20807

            string resourceUri = String.Format("aztrain/staff?$filter=lastName eq {0}", "'ERS Web'");

            //Staff staff = aoRestClient.RestGet<Staff>(restClient, resourceUri, aoRestClient.DefaultConfiguration);
            Staff []staff = aoRestClient.RestGet<Staff[]>(restClient, resourceUri, aoRestClient.DefaultConfiguration);

            return (staff[0].staffID);
        }
    }
}
