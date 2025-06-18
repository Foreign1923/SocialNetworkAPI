namespace SocialNetworkAPI.DTO
{
    public class CommentCreateDto
    {
        public string Content { get; set; } = null;
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
