namespace MeetMe.Data.Models
{
    public class UserFriend
    {
        public UserFriend() {}

        public UserFriend(int userId, string friendIdentityId, int friendId)
        {
            this.UserId = userId;
            this.FriendIdentityId = friendIdentityId;
            this.FriendId = friendId;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public string FriendIdentityId { get; set; }

        public int FriendId { get; set; }
    }
}
