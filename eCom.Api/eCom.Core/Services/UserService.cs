

using eCom.Core.DTO;
using eCom.Core.Entities;
using eCom.Core.RepositoryContract;
using eCom.Core.ServiceContracts;

namespace eCom.Core.Services;

internal class UserService : IUserServices
{
    public readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest login)
    {
        ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(login.Email, login.Password);
        if (user == null)
        {
            return null;
        }
        return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {
        ApplicationUser? user = new ApplicationUser()
        {
            PersonName = request.PersonName,
            Email = request.Email,
            Password = request.Password,
            Gender = request.Gender.ToString()
        };
        ApplicationUser? registeredUser = await _userRepository.AddUserAsync(user);
        if (registeredUser == null) return null;
        return new AuthenticationResponse(registeredUser.UserID, registeredUser.Gender, registeredUser.PersonName, registeredUser.Email, "token", Success: true);

    }
}

