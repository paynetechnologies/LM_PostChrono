using gov.uscourts.ao.rest.client;
using gov.uscourts.ao.rest.client.IProxies;
using gov.uscourts.ao.rest.dal.Domain;
using gov.uscourts.ao.rest.pacts.Interfaces;
using gov.uscourts.ao.rest.pacts.Services;
using gov.uscourts.ao.rest.sts;
using log4net;
using PublicDomain;
using System;
using System.Linq;
using System.Reflection;

namespace gov.uscourts.ao.rest.pacts.Services
{
    public class PACTSRestGen3Config : IPACTSRestGen3Config
    {
        ISecurityTokenService sts;
        IAORestClient aoRestClient;

        public PACTSRestGen3Config(ISecurityTokenService sts, IAORestClient aoRestClient)
        {
            this.sts = sts;
            this.aoRestClient = aoRestClient;
        }

        public TzTimeZone GetTimeZone(string districtId)
        {
            string resourceUri = String.Format("/gen3config/district?lcdId={0}", districtId);
            localCircuitDistrictConfiguration lcdc = aoRestClient.RestGet<localCircuitDistrictConfiguration>(resourceUri);
            TzTimeZone pactsZone = TzTimeZone.GetTimeZone(lcdc.timeZoneName);
            return pactsZone;
        }

    }
}
