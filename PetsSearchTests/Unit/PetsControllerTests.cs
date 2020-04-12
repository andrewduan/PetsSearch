using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PetsSearchApi.Controllers;
using PetsSearchApplication.Constants;
using PetsSearchApplication.Dtos;
using PetsSearchApplication.Implements;
using Shouldly;
using Xunit;

namespace PetsSearchTests.Unit
{
    public class PetsControllerTests : TestsBase
    {
        [Fact]
        public void GivenAPetService_ShouldCreateControllerSuccessfully()
        {
            // Assert
            Should.NotThrow(() => new PetsController(PetsService.Object));
        }

        [Fact]
        public async Task GivenNoDataReturn_WhenGetAllAsyncCalled_ShouldReturnEmptyList()
        {
            // Arrange
            HttpClient.Setup(c => c.GetContentAsync(It.IsAny<string>())).ReturnsAsync("");
            PetsService.Setup(c => c.GetAllAsync(PetTypeEnum.Cat)).ReturnsAsync(new List<PetsDto>());
            var sut = new PetsController(PetsService.Object);

            // Act
            var result = await sut.GetAsync();

            result.ShouldBeOfType<OkObjectResult>();
            
            // Assert
            ((result as OkObjectResult).Value as IEnumerable<PetsDto>).ToList().Count.ShouldBe(0);
        }

        [Theory]
        [InlineData(2, 4,3)]
        public async Task GivenValidDataReturn_WhenGetAllAsyncCalled_ShouldReturnPetDtoList(int expectedNumberOfOwner, int expectedCatNumberForMaleOwner, int expectedCatNumberForFemaleNumber)
        {
            // Arrange
            HttpClient.Setup(c => c.GetContentAsync(It.IsAny<string>())).ReturnsAsync(CreateJsonString());
            
            var sut = new PetsController(new PetsService(HttpClient.Object));

            // Act
            var result = await sut.GetAsync();

            result.ShouldBeOfType<OkObjectResult>();

            // Assert
            var petsDto = ((result as OkObjectResult).Value as IEnumerable<PetsDto>).ToList();
            petsDto.Count.ShouldBe(expectedNumberOfOwner);

            var catsOffemaleOwners = petsDto.Single(o => (GenderEnum)Enum.Parse(typeof(GenderEnum), o.Gender) == GenderEnum.Female).PetNames.ToList();
            catsOffemaleOwners.Count.ShouldBe(expectedCatNumberForFemaleNumber);

            catsOffemaleOwners[0].ShouldBe("Garfield");
            catsOffemaleOwners[1].ShouldBe("Simba");
            catsOffemaleOwners[2].ShouldBe("Tabby");

            var catsOfMaleOwners = petsDto.Single(o => (GenderEnum)Enum.Parse(typeof(GenderEnum), o.Gender) == GenderEnum.Male).PetNames.ToList();
            catsOfMaleOwners.Count.ShouldBe(expectedCatNumberForMaleOwner);
            catsOfMaleOwners[0].ShouldBe("Garfield");
            catsOfMaleOwners[1].ShouldBe("Jim");
            catsOfMaleOwners[2].ShouldBe("Max");
            catsOfMaleOwners[3].ShouldBe("Tom");

        }

        [Fact]
        public void GivenExceptionThrownFromPetService_ShouldThrowExceptionInContoller()
        {
            // Arrange
            PetsService.Setup(c => c.GetAllAsync(PetTypeEnum.Cat)).Throws(new Exception("some exception happened"));

            var sut = new PetsController(PetsService.Object);

            // Assert
            Should.Throw<Exception>(async () => await sut.GetAsync()).Message.ShouldBe("some exception happened");
        }
    }
}
