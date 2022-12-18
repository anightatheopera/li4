using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public class BarracasData : IBarracasData
    {
        private readonly ISqlDataAccess _db;

        public BarracasData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<BarracaModel>> GetBarracasPorFeira()
        {
            string sql = "select * from dbo.barracas b inner join dbo.feiras f on f.Id_feiras = b.Id_feira ;";
            return _db.LoadData<BarracaModel, dynamic>(sql, new { });
        }

        public Task<List<BarracaModel>> GetBarracas()
        {
            string sql = "select * from dbo.barracas;";
            return _db.LoadData<BarracaModel, dynamic>(sql, new { });
        }

        public Task InsertBarraca(BarracaModel barraca)
        {
            string sql = @"insert into dbo.Barracas (Nome, Descricao, Logotipo, Vendedor)
                           values (@Nome, @Descricao, @Logotipo, @Vendedor);";

            return _db.SaveData(sql, barraca);
        }
    }
}
