using SocialNetworkAPI.DTO;


namespace SocialNetworkAPI.Services
{

    public interface IAuthService
    {
        Task<bool> UserExists(string email);
        Task<int> Register(UserRegisterDto dto);
        Task<string?> Login(UserLoginDto dto);
    }

}
