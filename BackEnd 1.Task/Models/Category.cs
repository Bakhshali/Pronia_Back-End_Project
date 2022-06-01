using System.Collections.Generic;

namespace BackEnd_1.Task.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<PlantCategory> PlantCategories { get; set; }
        
    }
}
