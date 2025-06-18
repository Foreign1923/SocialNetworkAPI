using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetworkAPI.Data;
using SocialNetworkAPI.DTO;
using SocialNetworkAPI.Model;

namespace SocialNetworkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController :ControllerBase
    {
        private readonly AppDbContext _context;
        public LikeController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> LikePost(LikeDto dto)
        {
            // Aynı kullanıcı aynı postu daha önce beğenmiş mi?
            bool alreadyLiked = await _context.Likes
                .AnyAsync(l => l.UserId == dto.UserId && l.PostId == dto.PostId);

            if (alreadyLiked)
                return BadRequest("Bu post zaten beğenilmiş.");

            var like = new Like
            {
                UserId = dto.UserId,
                PostId = dto.PostId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Beğeni eklendi." });
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetLikesForPost(int postId)
        {
            var likeCount = await _context.Likes
                .CountAsync(l => l.PostId == postId);

            return Ok(new { postId, likeCount });
        }

        [HttpDelete]
        public async Task<IActionResult> UnlikePost(LikeDto dto)
        {
            var like = await _context.Likes
                .FirstOrDefaultAsync(l => l.UserId == dto.UserId && l.PostId == dto.PostId);

            if (like == null)
                return NotFound("Beğeni bulunamadı.");

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Beğeni kaldırıldı." });
        }
    }
}
