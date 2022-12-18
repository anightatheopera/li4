using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public interface IProdutosData
    {
        Task<List<ProdutoModel>> GetProdutos();
        Task<List<ProdutoModel>> GetProdutosPorBarraca();
        Task InsertProduto(ProdutoModel p);
    }
}