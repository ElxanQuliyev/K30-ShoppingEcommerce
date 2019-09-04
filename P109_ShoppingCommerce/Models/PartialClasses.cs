using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P109_ShoppingCommerce.Models
{
    [MetadataType(typeof(ApplicationUserMetadata))]
    public partial class ApplicationUser
    {
        public virtual string ConfirmPassword { get; set; }

        private class ApplicationUserMetadata
        {
            [Required]
            public string Firstname { get; set; }
            public string Lastname { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Username { get; set; }

            [Required, MinLength(7)]
            public string Password { get; set; }

            [Required]
            [Compare(nameof(Password))]
            public virtual string ConfirmPassword { get; set; }
        }
    }

    public class UserLogin
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}