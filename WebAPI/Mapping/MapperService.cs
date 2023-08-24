using WebAPI.Dto;
using WebAPI.Entities;

namespace WebAPI.Mapping
{
    public static class MapperService
    {
        public static RingDto MapRing(Ring ring, List<WayToGet> howToGet)
        {
            List<string> howToGetList = new();
            foreach(var e in howToGet) 
            {
                howToGetList.Add(e.HowToGet);
            }

            RingDto dto = new()
            {
                Id = ring.Id,
                Name = ring.Name,
                Effect = ring.Effect,
                ImageUrl = ring.ImageUrl,
                HowToGet = howToGetList
            };

            return dto;
        }

        public static List<RingDto> MapRings(List<Ring> rings, List<WayToGet> howToGet)
        {
            List<RingDto> dto = new();

            foreach(var ring in rings)
            {
                List<string> howToGetList = new();
                foreach (var e in howToGet.Where(h => h.RingId == ring.Id))
                {
                    howToGetList.Add(e.HowToGet);
                }

                dto.Add(new RingDto()
                {
                    Id = ring.Id,
                    Name = ring.Name,
                    Effect = ring.Effect,
                    ImageUrl = ring.ImageUrl,
                    HowToGet = howToGetList
                });
            }

            return dto;
        }

        public static Ring MapRing(RingDto ringDto)
        {
            Ring ring = new()
            {
                Name = ringDto.Name,
                Effect = ringDto.Effect,
                ImageUrl = ringDto.ImageUrl,
                HowToGet = new List<WayToGet>()
            };

            foreach(var howToGet in ringDto.HowToGet)
            {
                ring.HowToGet.Add(new WayToGet()
                {
                    HowToGet = howToGet,
                    RingId = ring.Id
                });
            }

            return ring;
        }
    }
}
