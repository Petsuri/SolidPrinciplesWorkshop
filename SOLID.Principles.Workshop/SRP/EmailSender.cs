using System.Threading.Tasks;

namespace SRP
{
    public sealed class EmailSender
    {
        public Task Send(string receiver, string message)
        {
            return Task.CompletedTask;
        }
    }
}
