using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudyCenter.Backend.Models
{
    public class Admin
    {
        [Identity]
        public int Id { get; set; }
        [Required]
        public string FirsName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        [PasswordPropertyText]
        [MaxLength(8)]
        public string Password { get; set; }
    }
}
