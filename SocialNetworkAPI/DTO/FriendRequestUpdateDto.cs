namespace SocialNetworkAPI.DTO
{
    public class FriendRequestUpdateDto
    {
        public int RequestId { get; set; }
        public string Status { get; set; } = "Accepted";
    }
}
