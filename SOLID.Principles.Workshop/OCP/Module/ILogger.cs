using System.Collections.Generic;

namespace OCP.Module
{
    public interface ILogger
    {
        void Info(string message, IReadOnlyDictionary<string, string> context = null);
    }
}
