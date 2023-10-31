using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using StudyCenter.Backend.Models.Postion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace StudyCenter.Backend.Models
{
    public class Admin
    {
        [Identity]
        public int Id { get; set; }
        public string? FirsName { get; set; }
        public string? LastName { get; set; }

        public Role EmployeeRole { get; set; }
        [Required]
        [EmailAddress]
        public string? Login { get; set; }
        [PasswordPropertyText]
        [MaxLength(8)]
        public string? Password { get; set; }
    }
}
