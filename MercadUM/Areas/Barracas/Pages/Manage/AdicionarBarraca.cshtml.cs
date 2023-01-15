using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MercadUM.Model;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using MercadUM.SqlDataAccess;
using MercadUM.Areas.Produtos.Pages.Manage;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;

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

        public class ImageHandler : IImageHandler
        {
            private readonly string _imagePath = "wwwroot/images";
            private readonly string _nonroot = "images/";
            private readonly int _maxFileSize = 4000000;
            private readonly string[] _allowedFileTypes = new[] { ".jpg", ".jpeg", ".png" };

            public ImageHandler()
            { }

            public async Task DeleteImageAsync(string path)
            {
                path = "wwwroot/" + path;
                if (System.IO.File.Exists(path))
                {
                    await Task.Run(() => System.IO.File.Delete(path));
                }
            }

            public async Task<string> SaveImageAsync(IBrowserFile file, string fileName)
            {
                if (file == null)
                    throw new Exception("File not found");
                if (file.Size > _maxFileSize)
                    throw new Exception("File is too large");
                var extension = Path.GetExtension(file.Name).ToLower();
                if (!_allowedFileTypes.Contains(extension))
                    throw new Exception("Invalid file type");
                var filePath = Path.Combine(_imagePath, fileName + extension);
                if (System.IO.File.Exists(filePath))
                    throw new Exception("File already exists");
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream(_maxFileSize).CopyToAsync(stream);
                }

                return _nonroot + fileName + extension;
            }

        }

    }
}
