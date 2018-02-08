using System;
using gov.uscourts.ao.rest.dal.Domain;

namespace gov.uscourts.ao.rest.test
{
    public class SPCS
    {
        public void TestSuccess()
        {
            //ERS-SPCS Stacktrace:
            //ChronoServiceHelper - WriteIntoG3(ChronoObj _chronoData)
            //PactsProvider - ChronoHelper.WriteIntoG3(_chronoData);
            //MessageSources - PactsProvider - AddChrono(ChronoObj _chronoData, bool bGen3)
            //ManageSPMS/sndmsgs - MessageSource.AddChrono(_chronodata, bool.Parse(ersconsole.SessionHandler.isGen3)))

            /*
             * ChronoServiceHelper - WriteIntoG3(ChronoObj _chronoData)
             */

            /*
            bool bTransaction = false;

            string[] tempCode;
            try
            {
                tempCode = _chronoData.ChronoCode.Split(new char[] { ' ' });
                tempCode = tempCode.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            }
            catch
            {
                tempCode = new string[1];
                tempCode[0] = "C-TREAT";
            }

            string timeAccepted = _chronoData.ChronoTime.ToString("HH:mm");
            ChronoSvcG3 ChronoClient = new ChronoSvcG3();
            ChronoClient.DistrictId = _chronoData.DistrictID;

            WriteChronosRequest wcr = new WriteChronosRequest()
            {
                chronoId = 0,
                chronoIdSpecified = true,
                clientId = int.Parse(_chronoData.ClientID),
                clientIdSpecified = true,
                contactDateSpecified = true,
                contactDate = DateTime.Parse(_chronoData.ChronoDate.ToString("yyyy-MM-dd")),
                contactTime = timeAccepted != "00:00" ? timeAccepted : "00:01",
                probationOrPretrial = _chronoData.ChronoType,
                attempted = _chronoData.attempted,
                chronoNotes = _chronoData.ChronoNotes,
                chronoStatus = "D",
                confidential = _chronoData.confidential,
                planChange = _chronoData.plan_change,
                noncompliance = _chronoData.noncompliance,
                responseNoncompliance = _chronoData.resp_noncompliance,
                thirdPartyRisk = _chronoData.third_party_risk,
                authorCodeSpecified = true,
                authorCode = int.Parse(_chronoData.StaffID),
                createdBy = _chronoData.StaffLastName,
                codes = tempCode

            };
            */
            //string[] tempCode;
            //try
            //{
            //    tempCode = _chronoData.ChronoCode.Split(new char[] { ' ' });
            //    tempCode = tempCode.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            //}
            //catch
            //{
            //    tempCode = new string[1];
            //    tempCode[0] = "C-TREAT";
            //}

            string chronoCode = "C-TREAT";
            string ProbPts = "P";

            var chrono = new chronos()
            {
                attempted = "N",
                authorCode = "364", // authorCode  is the Staff Id
                chronosNotes = "This SPCS-I was run was on : " + DateTime.Now.ToString(),
                chronosStatus = "D",
                chronosContacts = new chronosContact[]
                    {
                        new chronosContact()
                        {
                            id = new chronosContactPK()
                            {
                                probPts = ProbPts,
                                chronosCode = chronoCode,                       
                            },
                            createdOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                            createdBy = "Mike Acosta"
                        }
                    },

                clientId = "202968",
                probPts = ProbPts,
                confidential = "N",
                noncompliance = "N",
                planChange = "N",
                respNoncompliance = "N",
                thirdPartyRisk = "N",
                contactDate = DateTime.Now.ToString("yyyy-MM-dd"),
                contactTime = DateTime.Now.ToString("HH:mm"),
                createdOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdBy = "Acosta"
            };

           // AORestClientChronos aoRestClientChronos = new AORestClientChronos(chrono, "0970");
        }

        public void TestFailure()
        {

            string chronoCode = "C-TREAT";
            string ProbPts = ""; // ERROR MISSING ProbPts normally "P" or "S"

            var chrono = new chronos()
            {
                attempted = "N",
                authorCode = "364", // authorCode  is the Staff Id
                chronosNotes = "This SPCS-I was run was on : " + DateTime.Now.ToString(),
                chronosStatus = "D",
                chronosContacts = new chronosContact[]
                    {
                        new chronosContact()
                        {
                            id = new chronosContactPK()
                            {
                                probPts = "", // probPts = ProbPts // ERROR MISSING ProbPts
                                chronosCode = chronoCode,                       
                            },
                            createdOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                            createdBy = "Mike Acosta"
                        }
                    },

                clientId = "202968",
                probPts = ProbPts, 
                confidential = "N",
                noncompliance = "N",
                planChange = "N",
                respNoncompliance = "N",
                thirdPartyRisk = "N",
                contactDate = DateTime.Now.ToString("yyyy-MM-dd"),
                contactTime = DateTime.Now.ToString("HH:mm"),
                createdOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdBy = "Acosta"
            };

            //AORestClientChronos aoRestClientChronos = new AORestClientChronos(chrono, "0970");
        }
    }
}