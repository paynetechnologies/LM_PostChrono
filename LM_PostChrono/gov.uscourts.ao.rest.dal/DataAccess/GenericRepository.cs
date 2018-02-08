using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using gov.uscourts.ao.rest.dal.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace gov.uscourts.ao.rest.dal.DataAccess
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal ERSDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ERSDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /*
         * The Get method uses lambda expressions to allow the calling code to specify a filter 
         * condition and a column to order the results by, and a string parameter lets the caller 
         * provide a comma-delimited list of navigation properties for eager loading:
         */
        /*
         * The code Expression<Func<TEntity, bool>> filter means the caller will provide a lambda 
         * expression based on the TEntity type, and this expression will return a Boolean value. 
         * For example, if the repository is instantiated for the Student entity type, the code in 
         * the calling method might specify student => student.LastName == "Smith" for the filter parameter.
         */
        /*
         * The code Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy also means the caller 
         * will provide a lambda expression. But in this case, the input to the expression is an IQueryable 
         * object for the TEntity type. The expression will return an ordered version of that IQueryable object. 
         * For example, if the repository is instantiated for the Student entity type, the code in the calling 
         * method might specify q => q.OrderBy(s => s.LastName) for the orderBy parameter.
         */
        /*
         * When you call the Get method, you could do filtering and sorting on the IEnumerable collection 
         * returned by the method instead of providing parameters for these functions. But the sorting and 
         * filtering work would then be done in memory on the web server. 
         * 
         * By using these parameters, you ensure that the work is done by the database rather than the web server.   
         */
        // Change to IQueryable..
        //public virtual IEnumerable<TEntity> Get(
        //
        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            //The code in the Get method creates an IQueryable object and then applies the filter expression if there is one:
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //The code in the Get method creates an IQueryable object and then applies the filter expression if there is one:
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            //Finally, it applies the orderBy expression if there is one and returns the results; otherwise it returns the results from the unordered query:
            if (orderBy != null)
            {
                return orderBy(query).ToList().AsQueryable();
            }
            else
            {
                return query.ToList().AsQueryable();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        
        /// Requires NET Framework 4.5
        //public virtual Task<TEntity> GetByIDAsync(object id)
        //{
        //    return dbSet.FindAsync(id);
        //}
        
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /*
         * Two overloads are provided for the Delete method:
         * 
         * One of these lets you pass in just the ID of the entity to be deleted, 
         * and one takes an entity instance. As you saw in the Handling Concurrency 
         * tutorial, for concurrency handling you need a Delete method that takes an 
         * entity instance that includes the original value of a tracking property
         */
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}