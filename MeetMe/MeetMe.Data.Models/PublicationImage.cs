namespace MeetMe.Data.Models
{
    public class PublicationImage
    {
        public PublicationImage()
        {
        }

        public PublicationImage(byte[] content)
        {
            this.Content = content;
        }

        public int Id { get; set; }

        public byte[] Content { get; set; }
    }
}
