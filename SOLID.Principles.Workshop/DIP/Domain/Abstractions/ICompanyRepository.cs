using System.Threading.Tasks;

namespace DIP.Domain.Abstractions
{
    public interface ICompanyRepository
    {
        Task CreateCompany(string organizationIdentifier, string name);
        Task<bool> IsExistingCompany(string organizationIdentifier);
    }
}