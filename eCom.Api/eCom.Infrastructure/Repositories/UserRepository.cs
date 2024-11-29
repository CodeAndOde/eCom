using Dapper;
using eCom.Core.DTO;
using eCom.Core.Entities;
using eCom.Core.RepositoryContract;
using eCom.Infrastructure.DBContext;

namespace eCom.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;
        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();
            string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") " +
                                "VALUES (@UserID, @Email, @PersonName, @Gender, @Password);";

          int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
            if(rowCountAffected > 0)
            {
                return user;

            }
            else
            {
                return null;
            }

        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string password)
        {
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
            var parameters = new { Email = email, Password = password };
            ApplicationUser? users = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            return users;

            //return new ApplicationUser()
            //{
            //    UserID = Guid.NewGuid(),
            //    Email = email,
            //    Password = password,
            //    PersonName = "Jerwin",
            //    Gender = GenderOptions.Male.ToString()

            //};
        }
    }
}
