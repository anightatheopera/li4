using DataAcessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLibrary
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
            string sql = @"insert into dbo.utilizadores (Nome, Email, Password, DataNascimento, Telemovel, Morada, Pagamento)
                           values (@Nome, @Email, @Password, @DataNascimento, @Telemovel, @Morada, @Pagamento );";

            return _db.SaveData(sql, utilizador);
        }
    }
} 
