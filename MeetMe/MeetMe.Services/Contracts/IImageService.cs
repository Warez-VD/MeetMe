using System.Drawing;
using System.IO;

namespace MeetMe.Services.Contracts
{
    public interface IImageService
    {
        byte[] ImageToByteArray(Image imageIn);

        byte[] GetByteArrayFromStream(Stream inputStream);

        string ByteArrayToImageUrl(byte[] byteArrayIn);

        Image GetImage(string path);
    }
}
