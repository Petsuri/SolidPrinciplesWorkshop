using System.Threading.Tasks;

namespace OCP.ExternalModule
{
    public sealed class AdoNetConnection: IConnection
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
