using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PetsSearchApplication.Settings;
using PetsSearchCommon;

namespace PetsSearchApplication.Interfaces
{
    public interface IHttpClient
    {
        Task<string> GetContentAsync(string url);
    }

    public class PetsHttpClient : IHttpClient
    {
        private readonly Uri _baseAddress;

        public PetsHttpClient(UriSetting setting)
        {
            var baseUrl = setting.BaseUrl;
            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out _))
            {
                throw new InvalidUrlException("Invalid BaseUrl in appsettings");
            }

            _baseAddress = new Uri(baseUrl);
        }

        public async Task<string> GetContentAsync(string url)
        {
            using var client = new HttpClient
            {
                BaseAddress = _baseAddress
            };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonString = await client.GetStringAsync(url);

            return jsonString;
        }
    }
}
