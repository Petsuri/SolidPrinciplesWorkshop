using System;
using System.Net.Http;
using System.Threading.Tasks;
using DIP.Domain.Abstractions;
using Newtonsoft.Json;

namespace DIP.Infrastructure
{
    public sealed class OrganizationIdentifierValidation : IOrganizationIdentifierValidation
    {
        private readonly HttpClient _httpClient;

        public OrganizationIdentifierValidation()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> IsExistingOrganizationIdentifier(string value)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get,
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