using DataAcessLibrary.Model;

namespace DataAcessLibrary
{
    public interface IUtilizadoresData
    {
        Task<List<UtilizadorModel>> GetUtilizadores();
        Task InsertUtilizador(UtilizadorModel utilizador);
    }
}