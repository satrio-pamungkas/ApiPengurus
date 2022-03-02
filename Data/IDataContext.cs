using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPengurus.Models;

namespace ApiPengurus.Data
{
    public interface IDataContext
    {
        DbSet<Pengurus> pengurus { get; init; }

        int SaveChanges();
    }
}