using eCom.Core.DTO;
using eCom.Core.Entities;
using eCom.Core.RepositoryContract;

namespace eCom.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            return user;
        
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string password)
        {
            return new ApplicationUser()
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "Jerwin",
                Gender = GenderOptions.Male.ToString()

            };
        }
    }
}
