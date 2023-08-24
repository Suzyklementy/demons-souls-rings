using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class WayToGet
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string HowToGet { get; set; }
        public int RingId { get; set; }
    }
}
