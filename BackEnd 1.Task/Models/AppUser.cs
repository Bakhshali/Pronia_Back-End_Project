using Microsoft.AspNetCore.Identity;

namespace BackEnd_1.Task.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
