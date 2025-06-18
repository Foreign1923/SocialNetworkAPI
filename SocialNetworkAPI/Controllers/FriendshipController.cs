using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetworkAPI.Data;
using SocialNetworkAPI.DTO;
using SocialNetworkAPI.Model;

namespace SocialNetworkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendshipController: ControllerBase
    {
        private readonly AppDbContext _context;

        public FriendshipController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("send-friend-request")]
        public async Task<IActionResult> SendRequest(FriendRequestDto dto)
        {
            var exist = await _context.Friendships.AnyAsync(
                f =>
                (f.RequesterId == dto.RequesterId && f.AddresseeId == dto.AddresseeId) 
                ||
                (f.RequesterId == dto.AddresseeId && f.AddresseeId == dto.RequesterId)
                );
            if (exist)
            {
                return BadRequest("Friend request already exists.");
            }
            var friendship = new Model.Friendship
            {
                RequesterId = dto.RequesterId,
                AddresseeId = dto.AddresseeId,
                Status = FriendshipStatus.Pending
            };
            _context.Friendships.Add(friendship);
            await _context.SaveChangesAsync();
            return Ok(new {message = "Friend request sent successfully." });
        }
        

    }
}
