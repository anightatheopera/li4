using MercadUM.Model;
using MercadUM.SqlDataAccess;
using Microsoft.AspNetCore.Mvc;
using Smart.Blazor;
using System.ComponentModel.DataAnnotations;


namespace MercadUM.Areas.Encomendas
{
    public class AdicionarEncomendaModel : IAdicionarEncomendaModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        private readonly ISqlDataAccess _db;
        public class InputModel
        {

            [Required]
            [Display(Name = "Id_utilizador")]
            public string Id_utilizador { get; set; }

            [Display(Name = "Id_barraca")]
            public string Id_barraca { get; set; }

            [Required]
            [Display(Name = "Preço total")]
            public string Preco_Total { get; set; }

            [Required]
            [Display(Name = "Data")]
            public string Data { get; set; }

        }

        private static string RandomId()
        {
            return Guid.NewGuid().ToString();
        }

        public AdicionarEncomendaModel(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ApplicationEncomenda>> GetEncomendas()
        {
            string sql = "select * from dbo.encomendas;";
            return _db.LoadData<ApplicationEncomenda, dynamic>(sql, new { });
        }

        public Task<List<ApplicationEncomenda>> GetEncomendasByUser(string Id_utilizador)
        {
            string sql = @"SELECT * FROM [dbo].[encomendas] WHERE Id_utilizador = @Id_utilizador";
            return _db.LoadData<ApplicationEncomenda, dynamic>(sql, new { Id_utilizador = Id_utilizador });
        }

        public Task<List<ApplicationEncomenda>> GetEncomendasByBarraca(string Id_barraca)
        {
            string sql = @"SELECT * FROM [dbo].[encomendas] WHERE Id_barraca = @Id_barraca";
            return _db.LoadData<ApplicationEncomenda, dynamic>(sql, new { Id_barraca = Id_barraca });
        }

        public Task InsertEncomenda(ApplicationEncomenda encomenda)
        {
            string sql = @"insert into dbo.encomendas (Id_encomenda, Id_utilizador, Id_barraca, Data, Preco_total) 
            values (@Id_encomenda, @Id_utilizador, @Id_barraca, @Data, @Preco_total);";
            encomenda.Id_encomenda = RandomId();
            encomenda.PK = RandomId();
            return _db.SaveData(sql, encomenda);
        }

        public Task InsertEncomendaProduto(ApplicationEncomenda encomenda, string Id_Produto)
        {
            string sql = @"insert into dbo.encomendas_produtos (Id_encomenda, Id_produto) 
            values (@PK, @Id_encomenda, @Id_produto);";
            encomenda.PK = RandomId();
            return _db.SaveData(sql, encomenda);
        }

        public Task<List<string>> GetProdutosId(ApplicationEncomenda e)
        {
            string sql = @"SELECT Id_Produto FROM [dbo].[encomendas_produtos] WHERE Id_encomenda = @Id_encomenda";
            return _db.LoadData<string, dynamic>(sql, new { Id_encomenda = e.Id_encomenda});
        }


    }
}
