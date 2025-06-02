using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.DTO;
using SocialNetworkAPI.Services;

namespace SocialNetworkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            if (await _authService.UserExists(dto.Email))
                return BadRequest("Bu e-posta adresi zaten kayıtlı.");

            var userId = await _authService.Register(dto);
            return Ok(new { message = "Kayıt başarılı", userId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var token = await _authService.Login(dto);
            if (token == null)
                return Unauthorized("Geçersiz e-posta veya şifre.");

            return Ok(new { token });
        }
    }
}
