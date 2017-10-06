using System.Data.Common;
using System.Data.Entity;

namespace Examen2.Models
{
    public class Examen2DbContext<T> : DbContext
    {
        private string v;
        private bool throwIfV1Schema;

        public DbSet<User> Users { get; set; }

        public Examen2DbContext()
          : base("DefaultConnection")
        {

        }

        // Constructor to use on a DbConnection that is already opened
        public Examen2DbContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }

        public Examen2DbContext(string v, bool throwIfV1Schema)
        {
            this.v = v;
            this.throwIfV1Schema = throwIfV1Schema;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().MapToStoredProcedures();
        }
    }
}