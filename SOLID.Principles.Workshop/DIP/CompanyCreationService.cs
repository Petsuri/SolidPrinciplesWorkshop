using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DIP
{
    public sealed class CompanyCreationService
    {
        private class HttpRequestResponse
        {
            public bool IsFound { get; set; }
        }

        private class AccessRights
        {
            public bool IsAdminUser { get; set; }
        }

        private readonly Database _db;

        internal CompanyCreationService()
        {
            _db = Database.GetInstance();
        }

        public async Task Create(string organizationIdentifier, string name)
        {
            if (await IsExistingCompany(organizationIdentifier))
            {
                throw new InvalidOperationException("Organization already exists");
            }

            if (!await IsExistingOrganizationIdentifier(organizationIdentifier))
            {
                throw new InvalidOperationException("Organization identifier is not existing organization");
            }

            if (!await CanCurrentUserCreateOrganization())
            {
                throw new InvalidOperationException("Current user doesn't have access rights to create new company");
            }

            await _db.Execute(
                "INSERT INTO Company (OrganizationIdentifier, Name) VALUES (@OrganizationIdentifier, @Name)",
                new {OrganizationIdentifier = organizationIdentifier, Name = name});

        }

        private async Task<bool> CanCurrentUserCreateOrganization()
        {
            var rights = await _db.Query<AccessRights>(
                "SELECT IsAdminUser FROM CompanyAccessRights WHERE ID = @CurrentUserID",
                new {CurrentUserID = HttpSession.GetInstance().UserId});

            return rights.IsAdminUser;
        }


        private async Task<bool> IsExistingCompany(string organizationIdentifier)
        {
            var id = await _db.Query<int?>(
                "SELECT ID FROM Companies WHERE OrganizationIdentifier = @OrganizationIdentifier",
                new {OrganizationIdentifier = organizationIdentifier});

            return id.HasValue;
        }

        private async Task<bool> IsExistingOrganizationIdentifier(string value)
        {
            var client = new HttpClient();
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get,
                new Uri($"https://petrispizzer.ia?search={value}")));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Unable to validate given organization identifier");
            }

            var organization = JsonConvert.DeserializeObject<HttpRequestResponse>(await response.Content.ReadAsStringAsync());
            return organization.IsFound;
        }


    }
}
