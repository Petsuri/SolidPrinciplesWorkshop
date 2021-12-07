using System.Threading.Tasks;

namespace DIP.Domain.Abstractions
{
    public interface IOrganizationIdentifierValidation
    {
        Task<bool> IsExistingOrganizationIdentifier(string value);
    }
}