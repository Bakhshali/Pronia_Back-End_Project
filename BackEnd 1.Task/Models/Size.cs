using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_1.Task.Models
{
    public class Size
    {
        public int Id { get; set; }

        [StringLength(maximumLength:15,ErrorMessage ="You must write max 15 length")]

        public string Name { get; set; }


        public List<Plant> Sizes { get; set; }
    }
}
