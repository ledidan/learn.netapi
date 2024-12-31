

using System;
using System.ComponentModel.DataAnnotations;


namespace DTOs.Account.RegisterDTO
{
    public class RegisterDTO
    {
        [Required]
        public string? UserName {get; set;}
        [Required]
        [EmailAddress]
        public string? Email {get; set;}

        [Required]
        public string? Password {get; set;}

    }
}

