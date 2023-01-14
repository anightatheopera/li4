using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;


namespace MercadUM.SqlDataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {

        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sqlStatement, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sqlStatement, parameters);

                return rows.ToList();
            }
        }

        public async Task SaveData<T>(string sqlStatement, T parameters)
        {

            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sqlStatement, parameters);
            }
        }

    }
}