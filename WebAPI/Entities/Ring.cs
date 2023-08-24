using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class Ring
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(100)]
        public string Effect { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }
        public virtual ICollection<WayToGet> HowToGet { get; set; }
    }
}
