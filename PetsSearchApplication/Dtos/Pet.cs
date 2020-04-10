using Newtonsoft.Json;
using PetsSearchApplication.Constants;

namespace PetsSearchApplication.Dtos
{
    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("type")]
        public PetTypeEnum Type { get; }

        public Pet(string name, PetTypeEnum type)
        {
            Name = name;
            Type = type;
        }
    }


}
