using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.uscourts.ao.rest.dal.Interfaces.IDataAccess
{
    public interface IChronoStatusRepository : IRepository
    {
        IEnumerable GetAllFailedChronos();
    }
}
