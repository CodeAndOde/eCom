using eCom.Core.DTO;
using eCom.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = eCom.Core.DTO.LoginRequest;
using RegisterRequest = eCom.Core.DTO.RegisterRequest;

namespace eCom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }
       [HttpPost("register")]
       public async Task<IActionResult> Register(RegisterRequest registerRequest)
       {
            if(registerRequest == null)
            {
                return BadRequest("Invalid Registeration data");
            }

          AuthenticationResponse authenticationResponse = await  _userServices.Register(registerRequest);
            if(authenticationResponse ==null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
       }
        [HttpPost("login")]
       public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid Registeration data");
            }
            AuthenticationResponse authenticationResponse = await _userServices.Login(loginRequest);
            if (authenticationResponse == null || authenticationResponse.Success == false) return Unauthorized(authenticationResponse);

            return Ok(authenticationResponse);
        }
    }
}
