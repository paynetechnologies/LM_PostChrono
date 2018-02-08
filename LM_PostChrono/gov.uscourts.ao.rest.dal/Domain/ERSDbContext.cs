namespace gov.uscourts.ao.rest.dal.Domain
{
    using gov.uscourts.ao.rest.dal.Domain;
    using gov.uscourts.ao.rest.data.Intefaces.IDomain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ERSDbContext : DbContext//, IERSDbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AOChronoService.Model.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public ERSDbContext()
            : base("name=ERSdb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<ChronoStatus> chronoStatus { get; set; }
        public virtual DbSet<ChronoLog> chronoLog { get; set; }
        public virtual DbSet<ClientAssign> clientAssign { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }       
}