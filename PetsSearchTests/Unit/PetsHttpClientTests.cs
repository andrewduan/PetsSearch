using Moq;
using PetsSearchApplication.Implements;
using PetsSearchApplication.Settings;
using PetsSearchCommon;
using Shouldly;
using Xunit;

namespace PetsSearchTests.Unit
{
    public class PetsHttpClientTests
    {
        [Fact]
        public void GivenInvalidUrlSetting_ShouldThrowException()
        {
            // Assert
            Should.Throw<InvalidUrlException>(() => new PetsHttpClient(new UriSetting(It.IsNotNull<string>())))
                .ErrorMessage.ShouldBe("Invalid BaseUrl in appsettings");
        }

        [Fact]
        public void GivenValidUrlSetting_ShouldCreateSuccessfully()
        {
            // Assert
            Should.NotThrow(() => new PetsHttpClient(new UriSetting("http://test.com")));
        }
    }
}
