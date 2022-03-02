using Microsoft.EntityFrameworkCore;
using ApiPengurus.Models;

namespace ApiPengurus.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Pengurus> pengurus { get; init; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}