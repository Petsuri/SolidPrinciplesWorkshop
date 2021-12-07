using System.Threading.Tasks;
using DIP.Domain.Abstractions;

namespace DIP.Infrastructure
{
    public sealed class CompanyRepository : ICompanyRepository
    {

        private readonly Database _db;

        internal CompanyRepository()
        {
            _db = Database.GetInstance();
        }


        public Task CreateCompany(string organizationIdentifier, string name)
        {
            return _db.Execute(
                "INSERT INTO Company (OrganizationIdentifier, Name) VALUES (@OrganizationIdentifier, @Name)",
                new {OrganizationIdentifier = organizationIdentifier, Name = name});
        }

        //SELECT ID FROM Company?
        public async Task<bool> IsExistingCompany(string organizationIdentifier)
        {
            var id = await _db.Query<int?>(
                "SELECT ID FROM Companies WHERE OrganizationIdentifier = @OrganizationIdentifier",
                new {OrganizationIdentifier = organizationIdentifier});

            return id.HasValue;
        }
    }
}
