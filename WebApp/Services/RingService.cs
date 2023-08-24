using System.Net.Http.Headers;
using WebAPI.Dto;

namespace WebApp.Services
{
    public class RingService : IRingService
    {
        public async Task<IEnumerable<RingDto>> GetRingsAsync()
        {
            HttpClient client = new();
            client.BaseAddress = new Uri("https://localhost:44300/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Rings");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<RingDto>>();
                return result ?? new List<RingDto>();
            }
            else
            {
                return new List<RingDto>();
            }
        }
    }
}
