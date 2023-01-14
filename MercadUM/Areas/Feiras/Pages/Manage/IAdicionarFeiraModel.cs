using MercadUM.Model;

namespace MercadUM.Areas.Feiras.Pages.Manage
{
    public interface IAdicionarFeiraModel
    {
        Task<List<ApplicationFeira>> GetFeiras();
        Task InsertFeira(ApplicationFeira feira);
    }
}