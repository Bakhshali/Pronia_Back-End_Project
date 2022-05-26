using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_1.Task.Models
{
    public class Size
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(maximumLength:15)]

        public List<Plant> Sizes { get; set; }
    }
}
