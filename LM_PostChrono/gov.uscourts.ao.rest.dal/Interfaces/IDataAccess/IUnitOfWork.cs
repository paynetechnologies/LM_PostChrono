using gov.uscourts.ao.rest.dal.DataAccess;
using gov.uscourts.ao.rest.dal.Domain;
using System;

namespace gov.uscourts.ao.rest.dal.Interfaces.IDataAccess
{
    public interface IUnitOfWork
    {
        GenericRepository<ChronoLog> ChronoLogRepository { get; }
        GenericRepository<ChronoStatus> ChronoStatusRepository { get; }
        GenericRepository<ClientAssign> ClientAssignRepository { get; }
        void Dispose();
        void Save();
    }
}
