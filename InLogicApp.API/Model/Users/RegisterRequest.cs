using System;
using System.ComponentModel.DataAnnotations;

namespace InLogicApp.API.Model.Users
{
	public class RegisterRequest
	{
        [Required(ErrorMessage ="Please enter firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter email address")]
        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

