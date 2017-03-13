using System;
using NUnit.Framework;

namespace MeetMe.Services.Tests.TextServiceTests
{
    [TestFixture]
    public class ConvertBase64_Should
    {
        [Test]
        public void ThrowWhenInputIsInvalidFormat()
        {
            // Arrange
            var textService = new TextService();

            // Act
            Assert.Throws<FormatException>(() => textService.ConvertBase64("invalid"));
        }

        [Test]
        public void ThrowWhenInputIsNull()
        {
            // Arrange
            var textService = new TextService();

            // Act
            Assert.Throws<ArgumentNullException>(() => textService.ConvertBase64(null));
        }

        [Test]
        public void ReturnArray_WhenInputIsValid()
        {
            // Arrange
            string input = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAADAFBMVEUAAAAAAACLpEKEnz3a2tqywYiiqmHHx8emt3SFn0DD0IinuErL0V7U2Gq2w0+UrEP08X3w7Xrr6Xbl5HGGqJxYj8KQqG++vr7+/v7e3mtdbEtJZHW7xG5zfl6QsKMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAC8FdgAAAB9ALd9AAAAAADV8ADwALoAutW8sPgAfQAEAAAAAADseCR353WEdeyZATIFMpgAAMMBAAAAAAD4AABQYAEAA3YAAAAAAAQAAACkAAAAEvrsWi9pe3WEdeyZATIS+qRgmQDFdewsARUS++CtUAD6Am51fw1+nQ/1i3V4U4sAEvtDQokytQBUfgUAAAAS+6BPhgB5AEAAQz8S+4hCigB4AEMAEvsFMpgAAMNQAAACbq0AAACtUADwAm4Auv0FMpgAAMNYAAB18GHwYUBhWHUYdfAAEvvsadBhQHWYdfDDBTIAAAAAAAAvAAF17FrsaBAymHWgwwUCbEtAL75FQQABAEB3FlxASQk64wD0AEMAEvtsS6BMhAK1Amx+BTIS+/T7dAArABIAQ1KHWmRSMwCYAEPDBTIAAACtUAAYAm4CbExurVD7/AI2ABIAQ0cAAAAAAACgAAAAEvsS/AhHQAD8AEMAEvsS/DtL0AABAmwCbq0AAAAAAQABAACeIEm4AAAAAXRSTlMAQObYZgAAAAFiS0dEAIgFHUgAAAAJcEhZcwAALiMAAC4jAXilP3YAAACgSURBVBhXVc7rDsIgDIZhQmVSSgsyxoab3v9lyiEm+v6A5Ek+glJKw03NDCz9Arj/gwVE3UJEMB0cIHlmLwHG2EHwMcZHWlmGLFpydjGtdivUNhql7EeOqW5HXggVaLF579BOIq0wCFub2sQXKwNI1/loFaTQ4XkWrszX63wOEHt+owl85a2XL5ng1+TM27j22QYAgUS8F5E2CKCcM7+5Dy96C6Slq6q8AAAAAElFTkSuQmCC";
            var textService = new TextService();

            // Act
            var result = textService.ConvertBase64(input);

            // Assert
            Assert.IsInstanceOf<byte[]>(result);
        }
    }
}
