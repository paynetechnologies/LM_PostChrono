using gov.uscourts.ao.rest.client.IProxies;
using gov.uscourts.ao.rest.dal.Domain;
using gov.uscourts.ao.rest.dal.Interfaces.IDataAccess;
using gov.uscourts.ao.rest.pacts.Interfaces;
using gov.uscourts.ao.rest.sts;
using log4net;
using System;
using System.Linq;
using System.Reflection;

namespace gov.uscourts.ao.rest.pacts.Services
{
    public class PACTSRestDistrict : IPACTSRestDistrict
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        ISecurityTokenService sts;
        IUnitOfWork uow; 
        IAORestClient aoRestClient;

        public PACTSRestDistrict(ISecurityTokenService sts, IAORestClient aoRestClient, IUnitOfWork uow)
        {
            this.sts = sts;
            this.aoRestClient = aoRestClient;
            this.uow = uow;
        }

        public string[] GetStaffName(string staffId, string districtId)
        {
            LogData("GetStaffName Parameters", staffId, districtId);

            string resourceUri = String.Format("/district/staff/{0}?lcdId={1}", staffId, districtId); 

            try
            {
                aoRestClient.DefaultConfiguration.additionalHeader.Add("authenticationToken", sts.GetSTS());
                aoRestClient.DefaultConfiguration.additionalHeader.Add("districtId", districtId);

                staff stf = aoRestClient.RestGet<staff>(resourceUri);
                string[] name = new string[2];
                name[0] = stf.firstName;
                name[1] = stf.lastName;
                return (name);
            }
            catch (Exception ex)
            {
                LogData("GetStaffName failed", staffId, districtId);
                throw ex;
            }
        }

        public string GetPactsType(string ccid)
        {
            //string sqlQuery = "select pactsType "
            //       + "from ClientAssign ca "
            //       + "where CCID = @CCID "
            //       + "and assignNum = ( select max(assignNum)from ClientAssign where ca.CCID = CCID) ";

            //using (dbCtx)
            //{
            //    var pt = dbCtx.clientAssign
            //        .Where(c => (c.CCID == ccid) && (c.Active==true)).OrderByDescending(x => x.AssignNum).FirstOrDefault();
            //    return pt.PactsType; 
            //}

            try
            {
                IQueryable<ClientAssign> clientAssign = uow.ClientAssignRepository.Get(c => c.CCID == ccid && c.Active == true , o => o.OrderByDescending(x => x.AssignNum)
                , "");

                if (clientAssign.Count() > 0 )
                    return clientAssign.FirstOrDefault().PactsType;
                return null;
            }
            catch (Exception ex)
            {
                LogData("GetPactsType failed", ccid, "0970");
                throw ex;
            }
        }


        public void LogData(string msg, string staffId, string districtId)
        {
            string status = String.Format(" PACTSRestDistrict GetStaffName {0} : StaffId {1}, districtId {2}", msg, staffId, districtId);
            Log.Info(status);
        }
        
    }
}
