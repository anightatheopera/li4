using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MercadUM.Model;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using MercadUM.SqlDataAccess;

namespace MercadUM.Areas.Barracas.Pages.Manage
{
    public class AdicionarBarracaModel : PageModel, IAdicionarBarracaModel
    {

        [BindProperty]
        public InputModel Input { get; set; }

        private readonly ISqlDataAccess _db;



        public class InputModel
        {
            public string Id_Barracas { get; set; }

            [Required]
            [Display(Name = "Nome")]
            public string? Nome { get; set; }

            [Display(Name = "Logótipo")]
            public string? Url_Logotipo { get; set; }

        }

        private static string RandomId()
        {
            return Guid.NewGuid().ToString();
        }



        public AdicionarBarracaModel(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ApplicationBarraca>> GetBarracas()
        {
            string sql = "select * from dbo.barracas;";
            return _db.LoadData<ApplicationBarraca, dynamic>(sql, new { });
        }


        public Task InsertBarraca(ApplicationBarraca barraca)
        {
            string sql = @"insert into dbo.barracas (Id_barracas, Id_Vendedor, Id_feira, Nome, Url_Logotipo)
                           values (@Id_barracas, @Id_Vendedor, @Id_feira, @Nome, @Url_Logotipo);";

            barraca.Id_Barracas = RandomId();
            return _db.SaveData(sql, barraca);
        }
    }
}
