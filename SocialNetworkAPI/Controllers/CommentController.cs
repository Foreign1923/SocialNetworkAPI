using SocialNetworkAPI.Data;
using SocialNetworkAPI.DTO;
using SocialNetworkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SocialNetworkAPI.Controllers
{

    namespace SocialNetworkAPI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CommentController : ControllerBase
        {
            private readonly AppDbContext _context;

            public CommentController(AppDbContext context)
            {
                _context = context;
            }

            [HttpPost]
            public async Task<IActionResult> CreateComment(CommentCreateDto dto)
            {
                var comment = new Comment
                {
                    Content = dto.Content,
                    UserId = dto.UserId,
                    PostId = dto.PostId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return Ok(comment);
            }

            [HttpGet("post/{postId}")]
            public async Task<IActionResult> GetCommentsByPost(int postId)
            {
                var comments = await _context.Comments
                    .Where(c => c.PostId == postId)
                    .Include(c => c.User)
                    .OrderBy(c => c.CreatedAt)
                    .ToListAsync();

                return Ok(comments);
            }
        }
    }

}
