using gov.uscourts.ao.rest.dal.Domain;
using System;
using System.Data.Entity;

namespace gov.uscourts.ao.rest.data.Intefaces.IDomain
{
    public interface IERSDbContext : IDisposable
    {
        DbSet<ChronoLog> chronoLog { get; set; }
        DbSet<ChronoStatus> chronoStatus { get; set; }
        DbSet<ClientAssign> clientAssign { get; set; }
    }
}
