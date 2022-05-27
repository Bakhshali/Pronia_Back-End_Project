using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_1.Task.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Range(0,100)]
        public byte Discount { get; set; }
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Subtitle { get; set; }

        public string DiscoverURL { get; set; }

        public string  Image { get; set; }

        [Range(1,10)]
        public byte Order { get; set; }

        [NotMapped]

        public IFormFile Photo { get; set; }
    }
}
