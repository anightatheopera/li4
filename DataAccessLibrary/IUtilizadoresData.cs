using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public interface IUtilizadoresData
    {
        Task<List<UtilizadorModel>> GetUtilizadores();
        Task InsertUtilizador(UtilizadorModel utilizador);
    }
}