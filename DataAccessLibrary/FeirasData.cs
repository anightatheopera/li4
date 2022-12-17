using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class FeirasData : IFeirasData
    {
        private readonly ISqlDataAccess _db;

        public FeirasData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<FeiraModel>> GetFeiras()
        {
            string sql = "select * from dbo.feiras;";
            return _db.LoadData<FeiraModel, dynamic>(sql, new { });
        }

        public Task InsertFeira(FeiraModel feira)
        {
            string sql = @"insert into dbo.Feiras (Nome, Descricao, DataInicio, DataFim, N_barracas, Organizador)
                           values (@Nome, @Descricao, @DataInicio, @DataFim, @N_barracas, @Organizador);";

            return _db.SaveData(sql, feira);
        }
    }
}
