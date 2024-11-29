using eCom.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Core.ServiceContracts
{
    public interface IUserServices
    {
       Task<AuthenticationResponse?> Login(LoginRequest login);
       Task<AuthenticationResponse?> Register(RegisterRequest request);
    }
}
