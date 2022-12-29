using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public interface IBarracasData
    {
        Task InsertBarraca(BarracaModel barraca);
        Task<List<BarracaModel>> GetBarracas();
    }
}