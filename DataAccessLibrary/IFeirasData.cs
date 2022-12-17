using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public interface IFeirasData
    {
        Task<List<FeiraModel>> GetFeiras();
        Task InsertFeira(FeiraModel feira);
    }
}