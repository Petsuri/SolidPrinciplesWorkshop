using System.Threading.Tasks;

namespace SRP
{
    public sealed class Database
    {
        public Task<T> Query<T>(string sql, object parameters)
        {
            return Task.FromResult(default(T));
        }

        public Task Execute(string sql, object parameters)
        {
            return Task.CompletedTask;
        }
    }
}
