//using gov.uscourts.ao.rest.client.IProxies;
//using gov.uscourts.ao.rest.client.ISupport;
//using gov.uscourts.ao.rest.client.Support;
//using gov.uscourts.ao.rest.common.DTO;
//using gov.uscourts.ao.rest.common.Interfaces.IMAP;
//using gov.uscourts.ao.rest.dal.Domain;
//using gov.uscourts.ao.rest.dal.Interfaces.IDataAccess;
//using gov.uscourts.ao.rest.dal.Interfaces.IDomain;
//using gov.uscourts.ao.rest.pacts.Interfaces;
//using gov.uscourts.ao.rest.pacts.Services;
//using gov.uscourts.ao.rest.sts;
//using log4net;
//using PublicDomain;
//using System;
//using System.Data;
//using System.Linq;
//using System.Reflection;

//namespace gov.uscourts.ao.rest.pacts.Services
//{
//    public class PACTSRestChrono : IPACTSRestChrono 
//    {
//        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

//        IAORestClient aoRestClient;
//        IPACTSRestDistrict district;
//        IPACTSRestGen3Config gen3Config;
//        ISecurityTokenService sts;
//        IUnitOfWork uow;
//        IPACTSClientConfiguration clientConfig;

//        public PACTSRestChrono
//            (
//              IAORestClient aoRestClient
//            , IPACTSRestDistrict district
//            , IPACTSRestGen3Config gen3Config
//            , ISecurityTokenService sts
//            , IUnitOfWork uow,
//              IPACTSClientConfiguration clientConfig
//            )
//        {
//            this.aoRestClient = aoRestClient;
//            this.district = district;
//            this.gen3Config = gen3Config;
//            this.sts = sts;
//            this.uow = uow;
//            this.clientConfig = clientConfig;
//        }

//        public bool PostChrono(chronos chrono, string districtId)
//        {
//            string resourceUri = String.Format("chronos/chronos?lcdId={0}", districtId);

//            try
//            {
//                clientConfig.authenticationToken = sts.GetSTS();
//                clientConfig.districtId = districtId;

//                //var request = aoRestClient.CreatePACTSRequest(resourceUri, clientConfig);
//                //bool results = aoRestClient.RestPostNonQuery<chronos>(request, chrono, clientConfig);

//                bool results = aoRestClient.PACTSRestPostNonQuery<chronos>(resourceUri, chrono, clientConfig);
                
//                if (results == false)
//                {
//                    return (false);
//                }
//                return true;

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public void PostFailedChrono(IMAPChronoLogToPactsChronos mapper)
//        {
//            int totalRetry = 0;
//            int totalPosted = 0;
//            int totalFailed = 0;

//            // Get a list of new chronos
//            Log.Info(" <==== Starting RetryPostChronos ====>");

//            IQueryable<ChronoStatus> allFailedChronos = uow.ChronoStatusRepository.Get(c => c.status != "posted", d => d.OrderByDescending(x => x.ChronoStatusId), "ChronoLog");

//            totalRetry = allFailedChronos.Count();

//            Log.Info(String.Format("RetryPostChronos ### total number of chronos to retry : {0}", totalRetry.ToString()));

//            foreach (ChronoStatus failedChrono in allFailedChronos)
//            {
//                ChronoLog chronoLog = failedChrono.chronoLog;

//                // Build PACTS Chronos object using ChronoStatus; ChronoStatus includes ChronoLog object;
//                chronos chronos = mapper.MapFrom(failedChrono.chronoLog);

//                if (chronos == null)
//                {
//                    Log.Error(string.Format("??? PostFailedChrono - Failed to load chronos from chrono log model for lcd_id : {0} - client : {1} : ChronoStatus PK : {2}", chronoLog.districtId, chronoLog.clientId.ToString(), failedChrono.ChronoStatusId.ToString()));
//                }


//                //RETRY POST
//                try
//                {
//                    bool b = PostChrono(chronos, chronoLog.districtId);

//                    if (b)
//                    {
//                        // success
//                        UpdateChronoStatus(failedChrono, "posted");
//                        totalPosted += 1;
//                    }
//                    else
//                    {
//                        // Failure
//                        UpdateChronoStatus(failedChrono, "failed");
//                        totalFailed += 1;
//                    }

//                    try
//                    {
//                        uow.Save();
//                    }
//                    catch (DataException ex)
//                    {
//                        Log.Error(String.Format("??? PostFailedChrono Rest : Database Save Failed : Excetion {0}", ex.Message.ToString()));
//                        throw new Exception("??? PostFailedChrono Rest : Database Save Failed");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }

//            }

//            Log.Info(String.Format(" ### Total retries {0} : total posted {1} : total failed {2}", totalRetry.ToString(), totalPosted.ToString(), totalFailed.ToString()));
//            Log.Info(" <==== Finsihed PostFailedChrono ====>");
//        }

//        public void LogFailedChrono(chronos chrono, string pDistrictId)
//        {
//            using (var db = new ERSDbContext())
//            {
//                var chronoStatus = new ChronoStatus() // Parent
//                {
//                    application = "ERS",
//                    status = "new",
//                    retryCount = 0,
//                    addDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
//                    modifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
//                    retryDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),

//                    chronoLog = new ChronoLog() // Child
//                    {
//                        districtId = pDistrictId,
//                        attempted = chrono.attempted,
//                        //author = chrono.author,
//                        authorCode = chrono.authorCode, // authorCode  is the Staff Id
//                        chronosNotes = chrono.chronosNotes,
//                        probPts = chrono.probPts,
//                        chronosCode = chrono.chronosContacts[0].id.chronosCode.ToString(),
//                        createdOn = chrono.createdOn,
//                        createdBy = chrono.createdBy,
//                        chronosStatus = chrono.chronosStatus,
//                        clientId = chrono.clientId,
//                        confidential = chrono.confidential,
//                        noncompliance = chrono.noncompliance,
//                        planChange = chrono.planChange,
//                        respNoncompliance = chrono.respNoncompliance,
//                        thirdPartyRisk = chrono.thirdPartyRisk,
//                        contactDate = chrono.contactDate,
//                        contactTime = chrono.contactTime,
//                    }
//                };

//                try
//                {
//                    db.chronoStatus.Add(chronoStatus);
//                    db.SaveChanges();
//                }
//                catch (DataException ex)
//                {
//                    Log.Error(String.Format("??? ChronoService method LogFailedChrono : Excetion {0}", ex.Message.ToString()));
//                    throw new Exception(String.Format("??? ChronoService methodLogFailedChrono : Excetion {0}", ex.Message.ToString()), ex.InnerException);
//                }
//            }
//        }

//        private void UpdateChronoStatus(ChronoStatus chrono, string status)
//        {
//            chrono.status = status;
//            chrono.retryCount += 1;
//            chrono.modifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//            chrono.retryDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//        }

//        private void LogData(ChronoStatus chrono)
//        {
//            string status = String.Format(" LogFailedChrono ChronoStatus Data :: ChronoStatusId: {0}, application: {1}, status: {2} " +
//                                " retryCount {3}, addDate: {4}, retryDate: {5}, modifiedDate: {6} "
//                                , chrono.ChronoStatusId, chrono.application, chrono.status,
//                                chrono.retryCount, chrono.addDate, chrono.retryDate, chrono.modifiedDate);
//            Log.Info(status);

//            string message = String.Format(
//                            " LogFailedChrono ChronoLog Data    :: lcd_id: {0}, clientID: {1}, authorCode: {2}, " +
//                            " chronosNotes: {3}, chronoCode: {4}, ProbPts: {5}, " +
//                            " contactDate: {6},  contactTime: {7}, createdOn: {8}, " +
//                            " createdBy: {9}",
//                             chrono.chronoLog.districtId, chrono.chronoLog.clientId, chrono.chronoLog.authorCode,
//                             chrono.chronoLog.chronosNotes, chrono.chronoLog.chronosCode, chrono.chronoLog.probPts,
//                             chrono.chronoLog.contactDate, chrono.chronoLog.contactTime, chrono.chronoLog.createdOn,
//                             chrono.chronoLog.createdBy);

//            Log.Info(message);
//        }
        
        
//        //public DTOChrono LoadDTOChrono(
//        //      int pactsId,          string lcd_id,          string CCID,        string chronoCode
//        //    , string actionDesc,    string actionType,      string firstName,   string lastName
//        //    , string reportDate,    string rejectReason,    string ProbPts,     string csid)
//        //{

//        //    int clientId = pactsId;

//        //    //convert to csid in Pacts format
//        //    csid = csid.Substring(csid.IndexOf('-') + 1);

//        //    //Get Staff first and Last name
//        //    //string[] staffName = verifyModuleUtil.GetStaffName(DsnPacts, csid, lcd_id);
//        //    string[] staffName = district.GetStaffName(csid, lcd_id);

//        //    //set the message
//        //    string chronosMessage = staffName[0] + " " + staffName[1] + " denied the " + actionDesc + " " + actionType
//        //                             + " transaction that was submitted by " + firstName + " " + lastName + " on " + reportDate + " because " + rejectReason + ".";

//        //    int authorCode;
//        //    int.TryParse(csid, out authorCode);

//        //    //Convert to district time zone time
//        //    //TzTimeZone pactsZone = verifyModuleUtil.GetTimeStamps(DsnPacts, lcd_id);
//        //    TzTimeZone pactsZone = gen3Config.GetTimeZone(lcd_id);
//        //    TzDateTime tzPactsDt = pactsZone.Now;
//        //    DateTime PactsDateTime = tzPactsDt.DateTimeLocal.ToLocalTime();

//        //    //as ther is no chrono code MR_INTERNET ,change to MR_WEB
//        //    if (chronoCode.ToUpper().Equals("INTERNET"))
//        //        chronoCode = "WEB";

//        //    if (ProbPts.Equals("P"))
//        //    {
//        //        chronoCode = "MR-" + chronoCode;
//        //    }
//        //    else if (ProbPts.Equals("S"))
//        //    {
//        //        chronoCode = "BSR-" + chronoCode;
//        //    }

//        //    DTOChrono dtoChrono = new DTOChrono(
//        //         "N"                        //attempted
//        //        , ""                        //author
//        //        , authorCode.ToString()     //authorCode
//        //        , clientId.ToString()       //clientId
//        //        , chronoCode                //ChronoCode
//        //        , chronosMessage            //chronosNotes
//        //        , "D"                       //ChronoType
//        //        , "N"                       //confidential
//        //        , PactsDateTime             //contactDate
//        //        , PactsDateTime             //contactTime
//        //        , staffName[1]              //createdBy
//        //        , PactsDateTime             //createdOn
//        //        , lcd_id                    //districtId
//        //        , "N"                       //noncompliance
//        //        , "N"                       //planChange
//        //        , ProbPts                   //probPts
//        //        , "N"                       //respNoncompliance
//        //        , "N"                       //thirdPartyRisk
//        //    );

//        //    // For testing....Loggging method's input parameters 
//        //    Log.Info(String.Format("ERSRest method LoadChronoDTO input parameters - " +
//        //        "pactsId: {0},          lcd_id: {1},    CCID: {2}, chronoCode: {4}, actionDesc: {5}, actionType: {6}, firstName: {7}, lastName: {8}, reportDate: {9}, rejectReason: {10}, ProbPts: {11}",
//        //         pactsId.ToString(), lcd_id, CCID, chronoCode, actionDesc, actionType, firstName, lastName, reportDate, rejectReason, ProbPts));

//        //    // Logging arguments sent to chrono service
//        //    Log.Info(String.Format("ERSRest method LoadChronoDTO : parameters for PostChrono - " +
//        //        "clientID: {0},         lcd_id: {1}, authorCode: {2},       chronosMassaged: {3},   chronoCode: {4},    probPts: {5}, contactDate: {6},                     contactTime: {7},                createdOn: {8},                                staffName: {9} ",
//        //         clientId.ToString(), lcd_id, authorCode.ToString(), chronosMessage, chronoCode, ProbPts, PactsDateTime.ToString("yyyy-MM-dd"), PactsDateTime.ToString("HH:mm"), PactsDateTime.ToString("yyyy-MM-ddTHH:mm:ss"), staffName[1]));

//        //    return dtoChrono;
//        //}

//        //public DTOChrono LoadDTOChrono(
//        //      string pAttempted,            string pAuthor,         string pAuthorCode,     string pClientId
//        //    , string pChronosCode,          string pChronosNotes,   string pChronosStatus,  string pConfidential
//        //    , string pContactDate,          string pContactTime,    string pCreatedBy,      string pCreatedOn
//        //    , string pDistrictId,           string pNonCompliance,  string pPlanChange,     string pProbPts
//        //    , string pRespNoncompliance,    string pThirdPartyRisk)
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //public void PostFailedChrono_ORIG(IMAPChronoLogToPactsChronos mapper)
//        //{
//        //    int totalRetry = 0;
//        //    int totalPosted = 0;
//        //    int totalFailed = 0;

//        //    // Get a list of new chronos
//        //    Log.Info(" <==== Starting RetryPostChronos ====>");

//        //    //IEnumerable<ChronoStatus> failedChronos =  uow.ChronoStatusRepository.Get()
//        //   IQueryable<ChronoStatus> allFailedChronos = uow.ChronoStatusRepository.Get(c => c.status != "posted", d => d.OrderByDescending(x => x.ChronoStatusId)  , "ChronoLog");

//        //   using (var db = new ERSDbContext())
//        //   {

//        //        var chronoStatus = (from ChronoStatus c in db.chronoStatus.Include("ChronoLog")
//        //                            where c.status != "posted"
//        //                            select c).ToList();

//        //        //var chronoStatus = db.chronoStatus.Where(x => x.status != "posted").OrderBy(x => x.ChronoStatusId).ToList(); 

//        //        totalRetry = chronoStatus.Count();

//        //        Log.Info(String.Format("RetryPostChronos ### total number of chronos to retry : {0}", totalRetry.ToString()));

//        //        foreach (ChronoStatus chrono in chronoStatus)
//        //        {

//        //            //LogData(chrono);

//        //            // Build PACTS Chronos object using ChronoStatus; ChronoStatus includes ChronoLog object;
//        //            //IDTOChronoJson chronoJson = mapper.MapFrom(chrono.chronoLog);
//        //            chronos chronos = mapper.MapFrom(chrono.chronoLog);

//        //            if (chronos == null)
//        //            {
//        //                Log.Error(string.Format("??? RetryPostChronos - Failed to load chrono poco model for lcd_id : {0} - client : {1} : ChronoStatus PK : {2}", chrono.chronoLog.districtId, chrono.chronoLog.clientId.ToString(), chrono.ChronoStatusId.ToString()));
//        //            }

//        //            //RETRY POST
//        //            try
//        //            {
//        //                bool b = PostChrono(chronos, chrono.chronoLog.districtId);

//        //                if (b)
//        //                {
//        //                    // success
//        //                    UpdateChronoStatus(chrono, "posted");
//        //                    totalPosted += 1;
//        //                }
//        //                else
//        //                {
//        //                    // Failure
//        //                    UpdateChronoStatus(chrono, "failed");
//        //                    totalFailed += 1;
//        //                }

//        //                try
//        //                {
//        //                    db.SaveChanges();
//        //                }
//        //                catch (DataException ex)
//        //                {
//        //                    Log.Error(String.Format("??? RetryPostChronos Rest : Database Save Failed : Excetion {0}", ex.Message.ToString()));
//        //                    throw new Exception("??? RetryPostChronos Rest : Database Save Failed");
//        //                }
//        //            }
//        //            catch (Exception ex)
//        //            {
//        //                throw ex;
//        //            }
//        //        }
//        //    }

//        //    Log.Info(String.Format(" ### Total retries {0} : total posted {1} : total failed {2}", totalRetry.ToString(), totalPosted.ToString(), totalFailed.ToString()));
//        //    Log.Info(" <==== Finsihed RetryPostChronos ====>");
//        //}






//    }
//}
