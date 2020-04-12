using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetsSearchApplication.Constants;
using PetsSearchApplication.Dtos;
using PetsSearchApplication.Interfaces;

namespace PetsSearchApplication.Implements
{
    public class PetsService : IPetsService
    {
        private readonly IHttpClient _httpClient;
        public PetsService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PetsDto>> GetAllAsync(PetTypeEnum category)
        {
            var jsonString = await _httpClient.GetContentAsync("people.json");
            
            var owners = JsonConvert.DeserializeObject<List<Owner>>(jsonString);

            if (owners?.Any() != true)
            {
                return new List<PetsDto>();
            }
            Func<Pet, PetTypeEnum, bool> predict = (pet, category) => pet.Type == category || PetTypeEnum.All == category;

            var petDtos = owners
                .Where(owner => owner.Pets?.Any(p => predict(p, category)) == true)
                .GroupBy(owner => owner.Gender)
                .Select(grp =>
                {
                    var gender = grp.Key;
                    var pets = grp.SelectMany(value => value.Pets.Where(p => predict(p, category)).Select(c => c.Name));
                    return new PetsDto(Enum.GetName(typeof(GenderEnum), gender), pets);
                });

            return petDtos.Select(p => new PetsDto(p.Gender, p.PetNames.OrderBy(n => n)));
        }
    }
}