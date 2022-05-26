using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_1.Task.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(maximumLength:10)]
        public List<Plant> Colors { get; set; }
    }
}

