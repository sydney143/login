using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login.Models
{
    public class User
    {
        [Key]

        public int UserId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(5,  ErrorMessage ="Password must be 5 charaters long")]
        public string Password {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;} =DateTime.Now;
        public DateTime UpdatedAt {get;set;} =DateTime.Now;

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
            public string Confirm {get;set;}

            
        
    }
}