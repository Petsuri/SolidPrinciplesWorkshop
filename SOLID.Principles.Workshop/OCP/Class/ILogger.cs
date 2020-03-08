using System.Collections.Generic;

namespace OCP.Class
{
    public interface ILogger
    {
        void Info(string message, IReadOnlyDictionary<string, string> context = null);
    }
}
