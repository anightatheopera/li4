using MercadUM.Model;
using MercadUM.SqlDataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MercadUM.Areas.Produtos.Pages.Manage
{
    public class AdicionarProdutoModel : PageModel, IAdicionarProdutoModel
    {

        [BindProperty]
        public InputModel Input { get; set; }

        private readonly ISqlDataAccess _db;
        public class InputModel
        {
            public string Id_Produtos { get; set; }

            [Required]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Display(Name = "Descrição")]
            public string Descricao { get; set; }

            [Required]
            [Display(Name = "Preço")]
            public float Preco { get; set; }

            [Required]
            [Display(Name = "Stock")]
            public int Stock { get; set; }

        }

        private static string RandomId()
        {
            return Guid.NewGuid().ToString();
        }

        public AdicionarProdutoModel(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ApplicationProduto>> GetProdutos()
        {
            string sql = "select * from dbo.feiras;";
            return _db.LoadData<ApplicationProduto, dynamic>(sql, new { });
        }


        public Task InsertProduto(ApplicationProduto produto)
        {
            string sql = @"insert into dbo.produtos (Id_Produtos, Nome, Descricao, Preco, Id_Barracas)
                           values (@Id_Produtos, @Nome, @Descricao, @Preco, @Id_Barracas);";
            produto.Id_Produtos = RandomId();
            return _db.SaveData(sql, produto);
        }
    }
}
