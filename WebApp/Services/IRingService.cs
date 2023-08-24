using WebAPI.Dto;

namespace WebApp.Services
{
    public interface IRingService
    {
        public Task<IEnumerable<RingDto>> GetRingsAsync();
    }
}
