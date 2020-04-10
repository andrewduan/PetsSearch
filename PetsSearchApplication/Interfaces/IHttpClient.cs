using System.Threading.Tasks;

namespace PetsSearchApplication.Interfaces
{
    public interface IHttpClient
    {
        Task<string> GetContentAsync(string url);
    }    
}
