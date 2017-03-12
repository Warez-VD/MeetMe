using System;
using MeetMe.Services.Contracts;

namespace MeetMe.Services
{
    public class TextService : ITextService
    {
        public byte[] ConvertBase64(string text)
        {
            return Convert.FromBase64String(text);
        }
    }
}
