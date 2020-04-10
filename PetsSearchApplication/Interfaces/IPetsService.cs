using System.Collections.Generic;
using System.Threading.Tasks;
using PetsSearchApplication.Dtos;

namespace PetsSearchApplication.Interfaces
{
    public interface IPetsService
    {
        Task<IEnumerable<PetsDto>> GetAllAsync();
    }    
}
