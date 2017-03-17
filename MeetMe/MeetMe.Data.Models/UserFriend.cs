namespace MeetMe.Data.Models
{
    public class UserFriend
    {
        public UserFriend(int userId, int friendId)
        {
            this.UserId = userId;
            this.FriendId = friendId;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }
    }
}
