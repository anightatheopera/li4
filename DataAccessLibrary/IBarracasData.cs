using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public interface IBarracasData
    {
        Task InsertBarraca(BarracaModel barraca);
        public Task<List<BarracaModel>> GetBarracas();
    }
}