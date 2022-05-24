using BackEnd_1.Task.Models;
using System.Collections.Generic;

namespace BackEnd_1.Task.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders{ get; set; }

        public List<Card> Cards{ get; set; }
    }
}
