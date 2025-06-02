namespace SocialNetworkAPI.DTO
{
    public class PostCreateDto
    {
        public string Content { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public int UserId { get; set; } // Şimdilik body'den alacağız, sonra JWT'den çekeceğiz
    }

}
