using System.Threading.Tasks;

namespace DIP
{
    public sealed class Database
    {
        public Task<T> Query<T>(string sql, object parameters)
        {
            return Task.FromResult(default(T));
        }

        public Task Execute(string SQL, object parameters)
        {
            return Task.CompletedTask;
        }
    }
}
