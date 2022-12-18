using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public interface IBarracasData
    {
        Task<List<BarracaModel>> GetBarracasPorFeira();
        Task InsertBarraca(BarracaModel barraca);
        public Task<List<BarracaModel>> GetBarracas();
    }
}