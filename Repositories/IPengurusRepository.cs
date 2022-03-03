using ApiPengurus.Models;

namespace ApiPengurus.Repositories
{
    public interface IPengurusRepository
    {
        void AddPengurus(Pengurus pengurus);
        Pengurus GetPengurusSingleRecord(string nim);
    }
}