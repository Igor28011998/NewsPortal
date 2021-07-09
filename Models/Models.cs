using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public string Headline { get; set; }
        public string Body { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public Guid NewsId { get; set; }
        public News News { get; set; }

        //public List<Comment> Comments = new List<Comment>();
    }
    public class Comment
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public string Answer { get; set; }

        //public Guid UserId { get; set; }
        //public User User { get; set; }
    }
    public class Registration
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
