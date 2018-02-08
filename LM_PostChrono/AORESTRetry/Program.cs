using gov.uscourts.ao.rest.test;
using Microsoft.Practices.Unity;
using gov.uscourts.ao.rest.dal.Interfaces.IDataAccess;
using gov.uscourts.ao.rest.dal.DataAccess;
using gov.uscourts.ao.rest.client;
using gov.uscourts.ao.rest.client.IProxies;
using gov.uscourts.ao.rest.pacts.Services;
using gov.uscourts.ao.rest.sts;
using gov.uscourts.ao.rest.pacts.Interfaces;
using gov.uscourts.ao.rest.common.Interfaces.IDTO;
using gov.uscourts.ao.rest.common.DTO;
using gov.uscourts.ao.rest.common.Interfaces.IMAP;
using gov.uscourts.ao.rest.common.MAP;
using gov.uscourts.ao.rest.common.BLL;
using gov.uscourts.ao.rest.common.Interfaces.IBLL;
using gov.uscourts.ao.rest.client.ISupport;
using gov.uscourts.ao.rest.client.Support;
using gov.uscourts.ao.rest.ts.Interfaces;
using gov.uscourts.ao.rest.ts.Services;

namespace AORestRetry
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Unity
            IUnityContainer container = new UnityContainer();

            //****************** Project gov.uscourts.ao.rest.client **************

            // gov.uscourts.ao.rest.client.ISupport
            container.RegisterType<IClientConfiguration, ClientConfiguration>();
            container.RegisterType<IPACTSClientConfiguration, PACTSClientConfiguration>();


            // gov.uscourts.ao.rest.client.proxies
            container.RegisterType<IAORestClient, AORestClient>();
            
            // gov.uscourts.ao.rest.client.Support

            //****************** Project  gov.uscourts.ao.rest.dal ***************

            // gov.uscourts.ao.rest.dal.Interfaces.IDataAccess

            // gov.uscourts.ao.rest.dal.Interfaces.IDomain
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            //****************** Project  gov.uscourts.ao.rest.common ***************

            // gov.uscourts.ao.rest.pacts.IDTO
            container.RegisterType<IDTOChrono, DTOChrono>();
            container.RegisterType<IDTOChronoJson, DTOChronoJson>();

            // gov.uscourts.ao.rest.pacts.IBLL
            container.RegisterType<IBLLChronoData, BLLChronoData>();

            // gov.uscourts.ao.rest.pacts.IMAP

            container.RegisterType<IMAPSPCSChronoDataToPactsChronos, MAPSPCSChronoDataToPactsChronos>();
            container.RegisterType<IMAPDTOChronoToPactsChronos,     MAPDTOChronoToPactsChronos>();
            container.RegisterType<IMAPChronoLogToPactsChronos,     MAPChronoLogToPactsChronos>();

            //****************** Project  gov.uscourts.ao.rest.pacts ***************

            // gov.uscourts.ao.rest.pacts.IService

            container.RegisterType<IPACTSRestChrono, PACTSRestChrono>();
            container.RegisterType<IPACTSRestDistrict, PACTSRestDistrict>();
            container.RegisterType<IPACTSRestGen3Config, PACTSRestGen3Config>();

            //****************** Project  gov.uscourts.ao.rest.sts *******************

            // gov.uscourts.ao.rest.sts

            container.RegisterType<ISecurityTokenService, SecurityTokenService>();

            //****************** Project   gov.uscourts.ao.rest.ts *******************

            container.RegisterType<ITSRestStaff, TSRestStaff>();

            container.RegisterType<ERS>();

            #endregion

            //IAOChronoService service = container.Resolve<IAOChronoService>();

            //ERS ers = new ERS(container);
            ERS ers = container.Resolve<ERS>();
            //ers.TestGetStaffName();
            //ers.TestGetPactsType();
            ers.TestAuthorCode();
            //ers.TestSuccess();
            //ers.TestRetry();
        }
    }
}
