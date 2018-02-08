using gov.uscourts.ao.rest.common.Interfaces.IBLL;
using gov.uscourts.ao.rest.dal.Domain;

namespace gov.uscourts.ao.rest.common.Interfaces.IMAP
{

    public interface IMAPSPCSChronoDataToPactsChronos : IMAP<IBLLChronoData, chronos>
    {
        // Business Logic --> PACTS chronos
    }
}
