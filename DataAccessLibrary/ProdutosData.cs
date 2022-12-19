using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public class ProdutosData : IProdutosData
    {
        private readonly ISqlDataAccess _db;

        public ProdutosData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ProdutoModel>> GetProdutosPorBarraca()
        {
            string sql = "SELECT * FROM dbo.barracas JOIN dbo.produtos ON (dbo.barracas.Id_barracas = dbo.produtos.Id_barraca);";
            return _db.LoadData<ProdutoModel, dynamic>(sql, new { });
        }

        public Task<List<ProdutoModel>> GetProdutos()
        {
            string sql = "select * from dbo.produtos;";
            return _db.LoadData<ProdutoModel, dynamic>(sql, new { });
        }

        public Task InsertProduto(ProdutoModel p)
        {
            string sql = @"insert into dbo.produtos (Nome, Descricao, Imagens, Preço, Stock)
                           values (@Nome, @Descricao, @Url_fotos, @Preço, @Stock);";

            return _db.SaveData(sql, p);
        }
    }
}
