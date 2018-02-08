using gov.uscourts.ao.rest.dal.Domain;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using gov.uscourts.ao.rest.dal.Interfaces.IDataAccess;


namespace gov.uscourts.ao.rest.dal.DataAccess
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ERSDbContext context = new ERSDbContext();

        private GenericRepository<ClientAssign> clientAssignRepository;
        private GenericRepository<ChronoLog> chronoLogRepository;
        private GenericRepository<ChronoStatus> chronoStatusRepository;

        public GenericRepository<ClientAssign> ClientAssignRepository
        {
            get
            {

                if (this.clientAssignRepository == null)
                {
                    this.clientAssignRepository = new GenericRepository<ClientAssign>(context);
                }
                return clientAssignRepository;
            }
        }

        public GenericRepository<ChronoLog> ChronoLogRepository
        {
            get
            {

                if (this.chronoLogRepository == null)
                {
                    this.chronoLogRepository = new GenericRepository<ChronoLog>(context);
                }
                return chronoLogRepository;
            }
        }

        public GenericRepository<ChronoStatus> ChronoStatusRepository
        {
            get
            {

                if (this.chronoStatusRepository == null)
                {
                    this.chronoStatusRepository = new GenericRepository<ChronoStatus>(context);
                }
                return chronoStatusRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        /// Requires NET Framework 4.5
        //public void SaveAsync()
        //{
        //    context.SaveChangesAsync();
        //}

        /// Requires NET Framework 4.5
        //public virtual Task<int> SaveAsync()
        //{
        //    return context.SaveChangesAsync();
        //}

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}