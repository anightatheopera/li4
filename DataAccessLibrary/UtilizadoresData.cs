using DataAccessLibrary.Model;

namespace DataAccessLibrary
{
    public class UtilizadoresData : IUtilizadoresData
    {
        private readonly ISqlDataAccess _db;

        public UtilizadoresData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<UtilizadorModel>> GetUtilizadores()
        {
            string sql = "select * from dbo.utilizadores;";
            return _db.LoadData<UtilizadorModel, dynamic>(sql, new { });
        }

        public Task InsertUtilizador(UtilizadorModel utilizador)
        {
            string sql = @"insert into dbo.utilizadores (Nome, Email, Password, DataNascimento, Telemovel, Morada, Pagamento, Tipo de Conta)
                           values (@Nome, @Email, @Password, @DataNascimento, @Telemovel, @Morada, @Pagamento, @Tipo_de_conta);";

            return _db.SaveData(sql, utilizador);
        }
    }
} 
