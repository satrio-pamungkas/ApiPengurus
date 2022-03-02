using ApiPengurus.Data;
using ApiPengurus.Models;

namespace ApiPengurus.Repositories
{
    public class PengurusRepository: IPengurusRepository
    {
        private readonly IDataContext _context = null!;

        public PengurusRepository(IDataContext context)
        {
            _context = context;
        }

        public void AddPengurus(Pengurus pengurus)
        {
            _context.pengurus.Add(pengurus);
            _context.SaveChanges();
        }
    }
}