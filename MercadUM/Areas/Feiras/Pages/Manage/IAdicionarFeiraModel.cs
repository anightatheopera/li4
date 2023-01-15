using MercadUM.Model;

namespace MercadUM.Areas.Feiras.Pages.Manage
{
    public interface IAdicionarFeiraModel
    {

        Task<List<ApplicationFeira>> GetFeiras();
        Task<List<ApplicationFeira>> GetFeirasById(string Id_Feiras);
        Task InsertFeira(ApplicationFeira feira);
    }
}