namespace SocialNetworkAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Post>? Posts { get; set; }
        public ICollection<Friendship>? FriendRequestsSent { get; set; } // Requester
        public ICollection<Friendship>? FriendRequestsReceived { get; set; } // Addressee
    }

}
