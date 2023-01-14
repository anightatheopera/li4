using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MercadUM.Model;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using MercadUM.SqlDataAccess;

namespace MercadUM.Areas.Feiras.Pages.Manage
{
    public class AdicionarFeiraModel : PageModel, IAdicionarFeiraModel
    {

        [BindProperty]
        public InputModel Input { get; set; }

        private readonly ISqlDataAccess _db;

        public class InputModel
        {



            [Required]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Display(Name = "Descrição")]
            public string Descricao { get; set; }

            [Required]
            [Display(Name = "Data de Início")]
            public string Data_inicio { get; set; }

            [Required]
            [Display(Name = "Data de Fim")]
            public string Data_fim { get; set; }

            [Required]
            [Display(Name = "Número de Barracas")]
            public int N_Barracas { get; set; }

        }

        private static string RandomId()
        {
            return Guid.NewGuid().ToString();
        }

        public AdicionarFeiraModel(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ApplicationFeira>> GetFeiras()
        {
            string sql = "select * from dbo.feiras;";
            return _db.LoadData<ApplicationFeira, dynamic>(sql, new { });
        }


        public Task InsertFeira(ApplicationFeira feira)
        {
            string sql = @"insert into dbo.feiras (Id_feiras, Nome, Descricao, Data_inicio, Data_fim, N_barracas, Id_Organizador)
                           values (@Id_feiras,@Nome, @Descricao, @Data_inicio, @Data_fim, @N_barracas, @Id_Organizador);";
            feira.Id_Feiras = RandomId();
            return _db.SaveData(sql, feira);
        }
    }
}
