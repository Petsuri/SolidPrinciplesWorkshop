using System.Threading.Tasks;

namespace OCP.ExternalModule
{
    public sealed class Database
    {
        private readonly IConnection _connection;

        public Database(IConnection connection)
        {
            _connection = connection;
        }

        public Task<T> Query<T>(string sql, object parameters)
        {
            return _connection.Query<T>(sql, parameters);
        }

        public Task Execute(string sql, object parameters)
        {
            return _connection.Execute(sql, parameters);
        }
    }
}
