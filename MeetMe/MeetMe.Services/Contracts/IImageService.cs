using System.Drawing;

namespace MeetMe.Services.Contracts
{
    public interface IImageService
    {
        byte[] ImageToByteArray(Image imageIn);

        string ByteArrayToImageUrl(byte[] byteArrayIn);

        Image GetImage(string path);
    }
}
