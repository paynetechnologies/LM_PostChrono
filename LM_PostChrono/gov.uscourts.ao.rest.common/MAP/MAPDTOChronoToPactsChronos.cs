using gov.uscourts.ao.rest.common.Interfaces.IDTO;
using gov.uscourts.ao.rest.common.Interfaces.IMAP;
using gov.uscourts.ao.rest.dal.Domain;
using gov.uscourts.ao.rest.dal.Interfaces.IDomain;

namespace gov.uscourts.ao.rest.common.MAP
{
    public class MAPDTOChronoToPactsChronos : IMAPDTOChronoToPactsChronos
    {
   
        public chronos MapFrom(IDTOChrono input)
        {
            chronos chronos = ChronoDTOChronos(input);
            return chronos;
        }

       // #endregion
        public chronos ChronoDTOChronos(IDTOChrono chronoDTO)
        {
            var chronos = new chronos()
            {
                attempted = chronoDTO.Attempted, //"N",
                authorCode = chronoDTO.AuthorCode, //"364" <==> authorCode  is the Staff Id
                chronosNotes = chronoDTO.ChronosNotes, //"This ERS was run was on : ..."
                chronosContacts = new chronosContact[]
                    {
                        new chronosContact()
                        {
                            id = new chronosContactPK()
                            {
                                chronosCode =  chronoDTO.ChronosCode, //"C-TREAT" etc...
                                probPts =  chronoDTO.ProbPts,
                            },
                            createdOn =  chronoDTO.ContactDate,
                            createdBy =  chronoDTO.AuthorCode, //"Mike Acosta"
                        }
                    },

                clientId = int.Parse(chronoDTO.ClientId).ToString(), //"202968",
                confidential = chronoDTO.Confidential, //"N",
                contactDate = chronoDTO.ContactDate,
                contactTime = chronoDTO.ContactTime,
                createdOn = chronoDTO.ContactDate,
                createdBy = chronoDTO.CreatedBy, //"Mike Acosta"
                noncompliance = chronoDTO.NonCompliance, //"N",
                probPts = chronoDTO.ProbPts,
                planChange = chronoDTO.PlanChange, //"N",
                respNoncompliance = chronoDTO.RespNoncompliance, //"N",
                thirdPartyRisk = chronoDTO.ThirdPartyRisk, //"N",
            };

            // What does chronosStatus of "D" mean? Used only by ERS-SPCS sndmssg,cs and viewmsg.cs
            if (chronoDTO.ChronosStatus != null)
                chronos.chronosStatus = chronoDTO.ChronosStatus;

            return chronos;
        }
    }
}
