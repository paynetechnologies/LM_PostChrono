/*
 * 
 */
using gov.uscourts.ao.rest.common.DTO;
using gov.uscourts.ao.rest.common.Interfaces.IBLL;
using gov.uscourts.ao.rest.common.Interfaces.IDTO;
using gov.uscourts.ao.rest.common.Interfaces.IMAP;
using gov.uscourts.ao.rest.dal.Domain;
using gov.uscourts.ao.rest.dal.Interfaces.IDomain;

namespace gov.uscourts.ao.rest.common.MAP
{
    public class MAPSPCSChronoDataToPactsChronos : IMAPSPCSChronoDataToPactsChronos
    {
        #region IMAP<IChronoBLLDTO, Ichronos> Members

        public chronos MapFrom(IBLLChronoData input)
        {
            chronos chronos = MapHelper(input);
            return chronos;
        }
        #endregion

        // #endregion
        public chronos MapHelper(IBLLChronoData input)
        {
            var chronos = new chronos()
            {
                attempted = input.Attempted, //"N",
                authorCode = input.StaffID, //"364" <==> authorCode  is the Staff Id
                chronosNotes = input.ChronoNotes, //"This ERS was run was on : ..."
                chronosStatus = "D",
                chronosContacts = new chronosContact[]
                    {
                        new chronosContact()
                        {
                            id = new chronosContactPK()
                            {
                                chronosCode =  input.ChronoCode, //"C-TREAT" etc...
                                probPts =  input.ChronoType,
                            },
                            createdOn =  input.ChronoDate.ToString("yyyy-MM-dd"), //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                            createdBy =  input.StaffID, //"Mike Acosta"
                        }
                    },

                clientId = int.Parse(input.ClientID).ToString(), //"202968",
                confidential = input.Confidential, //"N",
                contactDate = input.ChronoDate.ToString("yyyy-MM-dd"), //DateTime.Now.ToString("yyyy-MM-dd"),
                contactTime = input.ChronoTime.ToString("HH:mm") != "00:00" ? input.ChronoTime.ToString("HH:mm") : "00:01", //DateTime.Now.ToString("HH:mm"),
                createdOn = input.ChronoDate.ToString("yyyy-MM-dd"), //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdBy = input.StaffLastName, //"Mike Acosta"
                noncompliance = input.Noncompliance, //"N",
                probPts = input.ChronoType,
                planChange = input.PlanChange, //"N",
                respNoncompliance = input.RespNoncompliance, //"N",
                thirdPartyRisk = input.ThirdPartyRisk, //"N",
            };
            return chronos;
        }
    }
}
