using MercadUM.Model;

namespace MercadUM.Areas.Encomendas
{
    public interface IAdicionarEncomendaModel
    {
        AdicionarEncomendaModel.InputModel Input { get; set; }

        Task<List<ApplicationEncomenda>> GetEncomendas();
        Task<List<ApplicationEncomenda>> GetEncomendasByBarraca(string Id_barraca);
        Task<List<ApplicationEncomenda>> GetEncomendasByUser(string Id_utilizador);
        Task InsertEncomenda(ApplicationEncomenda encomenda);
        Task InsertEncomendaProduto(ApplicationEncomenda encomenda, string Id_Produto);
    }
}