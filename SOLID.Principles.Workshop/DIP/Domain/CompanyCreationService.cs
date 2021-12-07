using System;
using System.Threading.Tasks;
using DIP.Domain.Abstractions;

namespace DIP.Domain
{
    public sealed class CompanyCreationService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IOrganizationIdentifierValidation _organizationIdentifierValidation;
        private readonly IAccessRightsRepository _accessRightsRepository;

        internal CompanyCreationService(ICompanyRepository companyRepository, IOrganizationIdentifierValidation organizationIdentifierValidation, IAccessRightsRepository accessRightsRepository)
        {
            _companyRepository = companyRepository;
            _organizationIdentifierValidation = organizationIdentifierValidation;
            _accessRightsRepository = accessRightsRepository;
            // _companyRepository = new CompanyRepository();
            // _organizationIdentifierValidation = new OrganizationIdentifierValidation();
            // _accessRightsRepository = new AccessRightsRepository();
        }

        public async Task Create(string organizationIdentifier, string name)
        {
            if (await _companyRepository.IsExistingCompany(organizationIdentifier))
            {
                throw new InvalidOperationException("Organization already exists");
            }

            if (!await _organizationIdentifierValidation.IsExistingOrganizationIdentifier(organizationIdentifier))
            {
                throw new InvalidOperationException("Organization identifier is not existing organization");
            }

            if (!await _accessRightsRepository.CanCurrentUserCreateOrganization())
            {
                throw new InvalidOperationException("Current user doesn't have access rights to create new company");
            }

            await _companyRepository.CreateCompany(organizationIdentifier, name);
        }
    }
}
