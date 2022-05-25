using System.Collections.Generic;

namespace BackEnd_1.Task.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Plant> Sizes { get; set; }
    }
}
