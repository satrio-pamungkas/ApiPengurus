using ApiPengurus.Models;

namespace ApiPengurus.Repositories
{
    public interface IPengurusRepository
    {
        void AddPengurus(Pengurus pengurus);
        // void UpdatePengurus(Pengurus pengurus);
        // void DeletePengurus(string id);
        Pengurus GetPengurusSingleRecord(string nim);
        // List<Pengurus> GetAllPengurus();
    }
}