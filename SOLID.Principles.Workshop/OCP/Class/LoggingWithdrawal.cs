namespace OCP.Class
{
    public class LoggingWithdrawal : IWithdrawal
    {
        private readonly IWithdrawal _decorated;
        private readonly ILogger _logger;
        private readonly ISession _session;

        public LoggingWithdrawal(IWithdrawal decorated, ILogger logger, ISession session)
        {
            _decorated = decorated;
            _logger = logger;
            _session = session;
        }

        public decimal Amount(decimal value)
        {
            _logger.Info($"Value: {value}, UserId:{_session.UserId()}");
            return _decorated.Amount(value);
        }
    }
}