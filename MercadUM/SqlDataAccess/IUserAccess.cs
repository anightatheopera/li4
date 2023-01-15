using MercadUM.Model;

namespace MercadUM.SqlDataAccess
{
    public interface IUserAccess
    {
        Task<List<ApplicationUser>> GetUserByEmail(string UserName);
        Task<List<ApplicationUser>> GetUtilizadores();
    }
}