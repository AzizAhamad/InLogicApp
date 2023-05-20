using System;
using System.Text.Json.Serialization;

namespace InLogicApp.API.Entities
{
	public class User
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}

