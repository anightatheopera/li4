namespace MercadUM.SqlDataAccess
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sqlStatement, U parameters);
        Task SaveData<T>(string sqlStatement, T parameters);
    }
}