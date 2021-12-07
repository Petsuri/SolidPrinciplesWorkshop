using System.Threading.Tasks;
using DIP.Domain;
using DIP.Domain.Abstractions;

namespace DIP.Infrastructure
{
    public sealed class AccessRightsRepository : IAccessRightsRepository
    {
        private readonly Database _db;
        private readonly HttpSession _session;

        public AccessRightsRepository()
        {
            _db = Database.GetInstance();
            _session = HttpSession.GetInstance();
        }

        public async Task<bool> CanCurrentUserCreateOrganization()
        {
            var rights = await _db.Query<AccessRights>(
                "SELECT IsAdminUser FROM CompanyAccessRights WHERE ID = @CurrentUserID",
                new {CurrentUserID = _session.UserId});

            return rights.IsAdminUser;
        }
    }
}