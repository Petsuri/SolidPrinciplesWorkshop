using System.Threading.Tasks;
using OCP.ExternalModule;

namespace OCP.Module
{
    public class LoggingAdoNetConnection : IConnection
    {
        private readonly IConnection _decorated;
        private readonly ILogger _logger;
        private readonly ISession _session;

        public LoggingAdoNetConnection(IConnection decorated, ILogger logger, ISession session)
        {
            _decorated = decorated;
            _logger = logger;
            _session = session;
        }

        public Task<T> Query<T>(string sql, object parameters)
        {
            _logger.Info($"SQL: {sql}, Parameters:{parameters} UserId:{_session.UserId()}");
            return _decorated.Query<T>(sql, parameters);
        }

        public Task Execute(string sql, object parameters)
        {
            _logger.Info($"SQL: {sql}, Parameters:{parameters} UserId:{_session.UserId()}");
            return _decorated.Execute(sql, parameters);
        }
    }
}