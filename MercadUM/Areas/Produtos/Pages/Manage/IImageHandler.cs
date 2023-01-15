using Microsoft.AspNetCore.Components.Forms;

namespace MercadUM.Areas.Produtos.Pages.Manage
{
    public interface IImageHandler
    {
        Task DeleteImageAsync(string path);
        Task<string> SaveImageAsync(IBrowserFile file, string fileName);
    }
}