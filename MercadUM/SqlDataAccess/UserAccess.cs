using MercadUM.Model;

namespace MercadUM.SqlDataAccess
{
    public class UserAccess : IUserAccess
    {
        private readonly ISqlDataAccess _db;
        public UserAccess(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ApplicationUser>> GetUtilizadores()
        {
            string sql = "select * from Identity.User;";
            return _db.LoadData<ApplicationUser, dynamic>(sql, new { });
        }

        public Task<List<ApplicationUser>> GetUserByEmail(string UserName)
        {
            string sql = @"SELECT * FROM [Identity].[User] WHERE UserName = @UserName";
            return _db.LoadData<ApplicationUser, dynamic>(sql, new { UserName = UserName });
        }


    }
}
