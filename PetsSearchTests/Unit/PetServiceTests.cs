using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using PetsSearchApplication.Constants;
using PetsSearchApplication.Implements;
using PetsSearchApplication.Interfaces;
using Shouldly;
using Xunit;

namespace PetsSearchTests.Unit
{
    public class PetServiceTests : TestsBase
    {
        [Theory]
        [InlineData(0)]
        public async Task GivenNoDataReturn_WhenGetAllAsyncCalled_ShouldReturnEmptyList(int expectCount)
        {
            // Arrange
            HttpClient.Setup(c => c.GetContentAsync(It.IsAny<string>())).ReturnsAsync("");
            var sut = Fixture.Create<PetsService>();

            // Act
            var result = await sut.GetAllAsync(PetTypeEnum.Cat);

            // Assert
            result.Count().ShouldBe(expectCount);
        }

        [Theory]
        [InlineData(2, 4, 3)]
        public async Task GivenValidDataReturn_WhenGetAllAsyncCalled_ShouldReturnPetDtoList(int expectedNumberOfOwner, int expectedCatNumberForMaleOwner, int expectedCatNumberForFemaleNumber)
        {
            // Arrange
            HttpClient.Setup(c => c.GetContentAsync(It.IsAny<string>())).ReturnsAsync(CreateJsonString());
            var sut = Fixture.Create<PetsService>();

            // Act
            var result = (await sut.GetAllAsync(PetTypeEnum.Cat)).ToList();

            // Assert
            result.Count.ShouldBe(expectedNumberOfOwner);
            var catsOffemaleOwners = result.Single(o => (GenderEnum)Enum.Parse(typeof(GenderEnum), o.Gender) == GenderEnum.Female).PetNames.ToList();
            catsOffemaleOwners.Count.ShouldBe(expectedCatNumberForFemaleNumber);

            catsOffemaleOwners[0].ShouldBe("Garfield");
            catsOffemaleOwners[1].ShouldBe("Simba");
            catsOffemaleOwners[2].ShouldBe("Tabby");

            var catsOfMaleOwners = result.Single(o => (GenderEnum)Enum.Parse(typeof(GenderEnum), o.Gender) == GenderEnum.Male).PetNames.ToList();
            catsOfMaleOwners.Count.ShouldBe(expectedCatNumberForMaleOwner);
            catsOfMaleOwners[0].ShouldBe("Garfield");
            catsOfMaleOwners[1].ShouldBe("Jim");
            catsOfMaleOwners[2].ShouldBe("Max");
            catsOfMaleOwners[3].ShouldBe("Tom");

        }
    }
}
