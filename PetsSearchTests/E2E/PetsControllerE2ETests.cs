using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetsSearchApplication.Constants;
using PetsSearchApplication.Dtos;
using Shouldly;
using Xunit;

namespace PetsSearchTests.E2E
{
    public class PlayersControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public PlayersControllerIntegrationTests(CustomWebApplicationFactory factory) => _client = factory.CreateClient();

        [Theory]
        [InlineData("/pets/invalidpettype")]
        [InlineData("/wrongurl")]
        public async Task GivenCatsUrl_ShouldReturn404Exception(string url)
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync(url);

            // Must be successful.
            httpResponse.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
        
        [Theory]
        [InlineData("/pets/cat", 2, 4 ,3)]
        [InlineData("/pets/", 2, 4 ,3)]
        public async Task GivenValidUrl_ShouldReturnExpectValue(string url, int expectedNumberOfOwner, int expectedCatNumberForMaleOwner, int expectedCatNumberForFemaleNumber)
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync(url);

            // Must be successful.
            httpResponse.StatusCode.ShouldBe(HttpStatusCode.OK);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PetsDto>>(stringResponse).ToList();

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

        [Theory]
        [InlineData("/pets/fish", 1, 1 )]
        public async Task GivenOtherPetsUrl_ShouldReturnExpectValue(string url, int expectedNumberOfOwner, int expectedCatNumberForFemaleNumber)
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync(url);

            // Must be successful.
            httpResponse.StatusCode.ShouldBe(HttpStatusCode.OK);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PetsDto>>(stringResponse).ToList();

            result.Count.ShouldBe(expectedNumberOfOwner);
            var catsOffemaleOwners = result.Single(o => (GenderEnum)Enum.Parse(typeof(GenderEnum), o.Gender) == GenderEnum.Female).PetNames.ToList();
            catsOffemaleOwners.Count.ShouldBe(expectedCatNumberForFemaleNumber);

            catsOffemaleOwners[0].ShouldBe("Nemo");
        }
    }
}