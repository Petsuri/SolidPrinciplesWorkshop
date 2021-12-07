using System.Threading.Tasks;

namespace DIP.Domain.Abstractions
{
    public interface IAccessRightsRepository
    {
        Task<bool> CanCurrentUserCreateOrganization();
    }
}