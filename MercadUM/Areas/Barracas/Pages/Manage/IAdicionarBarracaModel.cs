using MercadUM.Model;

namespace MercadUM.Areas.Barracas.Pages.Manage
{
    public interface IAdicionarBarracaModel
    {
        Task<List<ApplicationBarraca>> GetBarracas();
        Task InsertBarraca(ApplicationBarraca barraca);
    }
}