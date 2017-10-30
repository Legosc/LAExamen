using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Proyecto.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleLine> SaleLines { get; set; }
        public DbSet<VariantAttribute> VariantAttributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<ProductVariant> Variants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<IdentityUser> IdentityUser { get; set; }
        public ApplicationDbContext()

            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<ApplicationUser>()
           .HasOptional(obj => obj.Client)
           .WithOptionalPrincipal();
            modelBuilder.Entity<ApplicationUser>()
           .HasOptional(obj => obj.Employee)
           .WithOptionalPrincipal();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductVariants)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Category)
                .WithMany(e => e.Products)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductVariant>()
                .HasMany(e => e.VariantAttributes)
                .WithRequired(e => e.ProductVariant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.AttributeValues)
                .WithRequired(e => e.Attributes)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Sale>()
                .HasRequired(e => e.Client)
                .WithMany(e => e.Sales);

            modelBuilder.Entity<Sale>()
                .HasOptional(e => e.Employee)
                .WithMany(e => e.Sales);

            modelBuilder.Entity<Sale>()
                .HasMany(e => e.SaleLine)
                .WithRequired(e => e.Sale)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SaleLine>()
                .HasRequired(sl => sl.Sale)
                .WithMany(s => s.SaleLine)
                .WillCascadeOnDelete(true);
        }

    }
}