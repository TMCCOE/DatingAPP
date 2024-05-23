
using DatingAPP.Domain.Entities;
using System.Diagnostics.Metrics;

namespace DatingApp.Data.Repositories.UserRepository
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(Dating_APPContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
