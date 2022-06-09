using System.ComponentModel.DataAnnotations;

namespace BackEnd_1.ProniaProject.ViewModels
{
    public class EditVM
    {
        [Required, StringLength(maximumLength: 15)]
        public string Username { get; set; }

        [Required, StringLength(maximumLength: 15)]
        public string FirstName { get; set; }

        [Required, StringLength(maximumLength: 20)]
        public string LastName { get; set; }

        [ DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public bool Condition { get; set; }
    }
}
