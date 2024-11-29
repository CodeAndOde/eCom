using eCom.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Core.RepositoryContract
{
    public interface IUserRepository
    {
         Task<ApplicationUser?> AddUserAsync(ApplicationUser user);
        Task <ApplicationUser?> GetUserByEmailAndPassword(string? email, string password);
    }
}
