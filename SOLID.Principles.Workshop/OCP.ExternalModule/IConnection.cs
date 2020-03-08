using System.Threading.Tasks;

namespace OCP.ExternalModule
{
    public interface IConnection
    {
        Task<T> Query<T>(string sql, object parameters);
        Task Execute(string sql, object parameters);
    }
}
