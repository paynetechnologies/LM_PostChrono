using gov.uscourts.ao.rest.common.Interfaces.IDTO;
using gov.uscourts.ao.rest.common.Interfaces.IMAP;
using gov.uscourts.ao.rest.dal.Domain;
using gov.uscourts.ao.rest.dal.Interfaces.IDomain;

namespace gov.uscourts.ao.rest.common.MAP
{
    public class MAPChronoLogToPactsChronos : IMAPChronoLogToPactsChronos
    {
        public chronos MapFrom(IChronoLog p)
        {
            var chronos = new chronos()
            {
                attempted = p.attempted, //"N",
                authorCode = p.authorCode, //"364" <==> authorCode  is the Staff Id
                chronosNotes = p.chronosNotes, //"This ERS was run was on : ..."
                chronosContacts = new chronosContact[]
                    {
                        new chronosContact()
                        {
                            id = new chronosContactPK()
                            {
                                chronosCode =  p.chronosCode, //"C-TREAT" etc...
                                probPts =  p.probPts,
                            },
                            createdOn =  p.contactDate, //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                            createdBy =  p.authorCode, //"Mike Acosta"
                        }
                    },

                clientId = p.clientId , //int.Parse(chronoDTO.ClientId).ToString(), //"202968",
                confidential = p.confidential, //"N",
                contactDate = p.contactDate, //DateTime.Now.ToString("yyyy-MM-dd"),
                contactTime = p.contactTime, //DateTime.Now.ToString("HH:mm"),
                createdOn = p.createdOn, //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                createdBy = p.createdBy, //"Mike Acosta"
                noncompliance = p.noncompliance, //"N",
                probPts = p.probPts,
                planChange = p.planChange, //"N",
                respNoncompliance = p.respNoncompliance, //"N",
                thirdPartyRisk = p.thirdPartyRisk, //"N",
            };

            if (!string.IsNullOrEmpty(p.chronosStatus))
                chronos.chronosStatus = p.chronosStatus;

            return chronos;
        }
    }
}
