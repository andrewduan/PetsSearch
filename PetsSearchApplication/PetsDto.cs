using System.Collections.Generic;

namespace PetsSearchApplication
{
    public class PetsDto
    {
        public string Gender { get; }
        public IEnumerable<string> PetNames { get; }

        public PetsDto(string gender, IEnumerable<string> petNames)
        {
            Gender = gender;
            PetNames = petNames;
        }
    }
}
