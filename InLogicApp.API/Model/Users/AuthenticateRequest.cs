using System;
using System.ComponentModel.DataAnnotations;

namespace InLogicApp.API.Model.Users
{
	public class AuthenticateRequest
	{
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

