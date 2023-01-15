using MercadUM.Model;
using MercadUM.SqlDataAccess;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using Microsoft.AspNetCore.Components.Forms;

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

            [Required]
            [Display(Name = "Imagem")]
            public byte[] Imagem { get; set; }

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
            string sql = "select * from dbo.produtos;";
            return _db.LoadData<ApplicationProduto, dynamic>(sql, new { });
        }

        public Task<List<ApplicationProduto>> GetProdutosByBarraca(string Id_Barraca)
        {
            string sql = @"SELECT * FROM [dbo].[produtos] WHERE Id_Barraca = @Id_Barraca";
            return _db.LoadData<ApplicationProduto, dynamic>(sql, new { Id_Barraca = Id_Barraca });
        }

        public Task InsertProduto(ApplicationProduto produto)
        {
            string sql = @"insert into dbo.produtos (Id_Produtos, Nome, Descricao, Preco, Id_Barraca, Imagem)
                           values (@Id_Produtos, @Nome, @Descricao, @Preco, @Id_Barraca, @Imagem);";
            produto.Id_Produtos = RandomId();
            return _db.SaveData(sql, produto);
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
