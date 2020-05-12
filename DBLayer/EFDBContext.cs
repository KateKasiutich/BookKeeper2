using DBLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Directory> Directory { get; set; }
        public DbSet<Content> Books { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }


        //for migrations
        public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
        {
            public EFDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookKeeperDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DBLayer"));

                return new EFDBContext(optionsBuilder.Options);
            }
        }
    }
}