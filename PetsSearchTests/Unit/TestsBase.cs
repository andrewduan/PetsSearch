using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PetsSearchApplication.Constants;
using PetsSearchApplication.Dtos;
using PetsSearchApplication.Interfaces;

namespace PetsSearchTests.Unit
{
    public abstract class TestsBase : IDisposable
    {
        protected IFixture Fixture;
        protected Mock<IHttpClient> HttpClient;
        protected Mock<IPetsService> PetsService;


        public TestsBase()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            HttpClient = Fixture.Freeze<Mock<IHttpClient>>();
            PetsService = Fixture.Freeze<Mock<IPetsService>>();
        }

        public void Dispose()
        {
            Fixture = null;
            HttpClient = null;
            PetsService = null;
        }

        protected static string CreateJsonString()
        {
            var list = new List<Owner>
            {
                new Owner("Bob", GenderEnum.Male, 23, new List<Pet>
                {
                    new Pet("Garfield", PetTypeEnum.Cat),
                    new Pet("Fido", PetTypeEnum.Dog)
                }),
                new Owner("Jennifer", GenderEnum.Female, 18, new List<Pet>
                {
                    new Pet("Garfield", PetTypeEnum.Cat)
                }),
                new Owner("Steve", GenderEnum.Male, 45, null),
                new Owner("Fred", GenderEnum.Male, 40, new List<Pet>
                {
                    new Pet("Tom", PetTypeEnum.Cat),
                    new Pet("Max", PetTypeEnum.Cat),
                    new Pet("Sam", PetTypeEnum.Dog),
                    new Pet("Jim", PetTypeEnum.Cat)
                }),
                new Owner("Samantha", GenderEnum.Female, 40, new List<Pet>
                {
                    new Pet("Tabby", PetTypeEnum.Cat)
                }),
                new Owner("Alice", GenderEnum.Female, 64, new List<Pet>
                {
                    new Pet("Simba", PetTypeEnum.Cat),
                    new Pet("Nemo", PetTypeEnum.Fish)
                })
            };

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(list, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return json;
        }
    }
}
