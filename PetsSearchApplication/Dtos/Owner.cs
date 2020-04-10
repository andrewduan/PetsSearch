using System.Collections.Generic;
using Newtonsoft.Json;
using PetsSearchApplication.Constants;

namespace PetsSearchApplication.Dtos
{
    public class Owner
    {
        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("gender")]
        public GenderEnum Gender { get; }
        [JsonProperty("age")]
        public int Age { get; }
        [JsonProperty("pets")]
        public IEnumerable<Pet> Pets { get; }

        public Owner(string name, GenderEnum gender, int age, IEnumerable<Pet> pets)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Pets = pets;
        }
    }
}
