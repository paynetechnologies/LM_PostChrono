using gov.uscourts.ao.rest.dal.Domain;
using gov.uscourts.ao.rest.dal.Interfaces.IDataAccess;
using System;
using System.Collections;
using System.Linq;

namespace gov.uscourts.ao.rest.dal.DataAccess
{
    public class ChronoStatusRepository// : IChronoStatusRepository
    {
        public IEnumerable GetAllFailedChronos()
        {
            using (var db = new ERSDbContext())
            {
                var chronoStatus = (from c in db.chronoStatus.Include("ChronoLog")
                                    where c.status != "posted"
                                    select c).ToList();

                return chronoStatus;
            }
        }




        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

    }
}
