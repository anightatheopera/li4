using Microsoft.AspNetCore.Components.Forms;

namespace MercadUM.Areas.Barracas.Pages.Manage
{
    public interface IImageHandler
    {
        Task DeleteImageAsync(string path);
        Task<string> SaveImageAsync(IBrowserFile file, string fileName);
    }
}