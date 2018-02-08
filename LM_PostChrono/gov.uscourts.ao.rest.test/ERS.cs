using System;
using gov.uscourts.ao.rest.sts;
using gov.uscourts.ao.rest.client;
using gov.uscourts.ao.rest.dal.Domain;
using gov.uscourts.ao.rest.pacts;
using gov.uscourts.ao.rest.pacts.Services;
using Microsoft.Practices.Unity;
using System.Linq;
using log4net;
using System.Reflection;
using System.Data;
using gov.uscourts.ao.rest.pacts.Interfaces;
using gov.uscourts.ao.rest.common.DTO;
using gov.uscourts.ao.rest.common.Interfaces.IMAP;
using gov.uscourts.ao.rest.common.BLL;
using gov.uscourts.ao.rest.client.IProxies;
using gov.uscourts.ao.rest.common.MAP;
using gov.uscourts.ao.rest.dal.Interfaces.IDomain;
using gov.uscourts.ao.rest.ts.Interfaces;


namespace gov.uscourts.ao.rest.test
{
    public class ERS 
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        IUnityContainer container;

        public ERS(IUnityContainer container)
        {
            this.container = container;
        }

        //Simulate application flow:
        //1. Build Chronos POCO (DTO) - gather data elements needed to Post Chronos via Rest
        //2. Load the PACTS Chronos object (uses JSON)
        //3. POST Chronos using PACTS Rest

        public void TestSuccess()
        {
            //// This is a contrived step to simulate normal program flow
            BLLChronoData bllChronoData = BuildChronoObj();

            IMAPSPCSChronoDataToPactsChronos mapper = container.Resolve<IMAPSPCSChronoDataToPactsChronos>();
            chronos chrono = mapper.MapFrom(bllChronoData);

            IPACTSRestChrono chronoService = container.Resolve<IPACTSRestChrono>();

            if (!chronoService.PostChrono(chrono, "0970"))
            {
                chronoService.LogFailedChrono(chrono, "0970");
            }
        }

        public string[] TestGetStaffName()
        {
            IPACTSRestDistrict district = container.Resolve<IPACTSRestDistrict>();
            var name = district.GetStaffName("364", "0970");
            return name;
        }

        public string TestGetPactsType()
        {
           IPACTSRestDistrict district = container.Resolve<IPACTSRestDistrict>();
           var pactsType = district.GetPactsType("AZX-70728");
           return pactsType;
        }

        public int TestAuthorCode()
        {
            ITSRestStaff staff = container.Resolve<ITSRestStaff>();
            var authorCode = staff.GetAuthorCode("0970");
            return authorCode;
        }

        public void TestFailure()
        {
            //// This is a contrived step to simulate normal program flow
            BLLChronoData bllChronoData = BuildChronoObj();

            IMAPSPCSChronoDataToPactsChronos mapper = container.Resolve<IMAPSPCSChronoDataToPactsChronos>();
            chronos chrono = mapper.MapFrom(bllChronoData);
            
            chrono.chronosStatus = ""; // THIS WILL CAUSE A POSTING ERROR

            IPACTSRestChrono chronoService = container.Resolve<IPACTSRestChrono>();

            if (!chronoService.PostChrono(chrono, "0970"))
            {
                chronoService.LogFailedChrono(chrono, "0970");
            }
        }
        public void TestRetry()
        {
            IPACTSRestChrono chronoService = container.Resolve<IPACTSRestChrono>();
            chronoService.PostFailedChrono(container.Resolve<IMAPChronoLogToPactsChronos>());
        }

        public BLLChronoData BuildChronoObj()
        {
            BLLChronoData chronoObj = new BLLChronoData
            (
                DistrictID : "0970",
                VendorID : "384",
                ClientID : "202968", 
                StaffID : "364", // authorCode  is the Staff Id
                
                StaffLastName : "Mike Acosta",
                ChronoType : "P",
                ChronoCode : "C-TREAT", //chronoCode,                       
                ChronoNotes : "This ERS was run was on : " + DateTime.Now.ToString(),
                
                ChronoDate : DateTime.Now, //.ToString("yyyy-MM-dd"),
                ChronoTime : DateTime.Now, //.ToString("HH:mm"),
                chronoDateTime : DateTime.Now, //.ToString("yyyy-MM-ddTHH:mm:ss"),
                attempted : "N",

                noncompliance : "N",
                resp_noncompliance : "N",
                third_party_risk : "N",
                plan_change : "N",
                confidential : "N"            
            );
            return chronoObj;
        }

        public ChronoLog BuildChronoLog()
        {
            var chronolog = new ChronoLog
            {
                //Blcd_id = "0970",
                attempted = "N",
                authorCode = "364", // authorCode  is the Staff Id
                chronosNotes = "This ERS was run was on : " + DateTime.Now.ToString(),
                probPts = "P",
                chronosCode = "C-TREAT", //chronoCode,                       
                createdOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdBy = "Mike Acosta",
                chronosStatus = "D",
                clientId = "202968",
                confidential = "N",
                noncompliance = "N",
                planChange = "N",
                respNoncompliance = "N",
                thirdPartyRisk = "N",
                contactDate = DateTime.Now.ToString("yyyy-MM-dd"),
                contactTime = DateTime.Now.ToString("HH:mm"),
            };
            return chronolog;
        }


        public DTOChronoJson LoadObject(ChronoLog chrono)
        {
            //Rehydrate object

            var retryChrono = new DTOChronoJson() // PACTS Chronos object 
            {
                attempted = chrono.attempted,
                //author = chrono.author ?? null, DEPRECATED
                authorCode = chrono.authorCode, // authorCode  is the Staff Id
                chronosNotes = chrono.chronosNotes,

                chronosContacts = new chronosContact[]
                {
                    new chronosContact()
                    {
                        id = new chronosContactPK()
                        {
                            probPts = chrono.probPts,
                            chronosCode = chrono.chronosCode,  
                        },
                        createdOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                        createdBy = chrono.createdBy,
                    }
                },

                //chronosStatus = chrono.chronosStatus,
                clientId = chrono.clientId,
                probPts = chrono.probPts,
                confidential = chrono.confidential,
                nonCompliance = chrono.noncompliance,
                planChange = chrono.planChange,
                respNoncompliance = chrono.respNoncompliance,
                thirdPartyRisk = chrono.thirdPartyRisk,
                contactDate = chrono.contactDate,
                contactTime = chrono.contactTime,
                createdOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdBy = chrono.createdBy,
            };
            return retryChrono;
        }
    }
}

// PATTERN for saving to database: 
/*        
    var parent = new Parent
    {
        // fill other properties
        Children = new List<Child>()
    }

    parent.Children.add(new Child { // fill values);

    dbContext.Parents.Add(parent); // whatever your context is named
    dbContext.SaveChanges();
*/

/*
    var chronoStatus = new ChronoStatus() // Parent
    {
        application = "ERS",
        status = "new",
        retryCount = 0,
        addDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        modifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        retryDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),

        chronoLog = new ChronoLog() // Child
        {
            attempted = "N",
            author = "",
            authorCode = "364", // authorCode  is the Staff Id
            chronosNotes = "This ERS was run was on : " + DateTime.Now.ToString(),
            probPts = ProbPts,
            chronosCode = chronoCode,
            createdOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
            createdBy = "Mike Acosta",
            chronosStatus = "",
            clientId = "202968",
            confidential = "N",
            noncompliance = "N",
            planChange = "N",
            respNoncompliance = "N",
            thirdPartyRisk = "N",
            contactDate = DateTime.Now.ToString("yyyy-MM-dd"),
            contactTime = DateTime.Now.ToString("HH:mm"),
        }
    };

    using (var db2 = new ChronoDbContext())
    {
        try
        {
            db2.chronoStatus.Add(chronoStatus);
            db2.SaveChanges();
        }
        catch (DataException ex)
        {
            Log.Error(String.Format("??? DB Save Failed : Excetion {0}", ex.Message.ToString()));
           // throw new Exception("DB Save Failed");
        }
    }
}
 */