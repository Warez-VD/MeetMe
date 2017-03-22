using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class ImageService : IImageService
    {
        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream memoryStream = new MemoryStream();
            imageIn.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        public string ByteArrayToImageUrl(byte[] byteArrayIn)
        {
            string base64String = Convert.ToBase64String(byteArrayIn, 0, byteArrayIn.Length);
            string resultUrl = "data:image/jpg;base64," + base64String;
            return resultUrl;
        }

        public Image GetImage(string path)
        {
            return Image.FromFile(path);
        }

        public byte[] GetByteArrayFromStream(Stream inputStream)
        {
            MemoryStream target = new MemoryStream();
            inputStream.CopyTo(target);
            byte[] data = target.ToArray();
            return data;
        }
    }
}
