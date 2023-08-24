
namespace WebAPI.Dto
{
    public class RingDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public string ImageUrl { get; set; }
        public List<String> HowToGet { get; set; }
    }
}
