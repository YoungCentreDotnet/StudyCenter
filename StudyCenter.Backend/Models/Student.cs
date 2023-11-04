using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudyCenter.Backend.Models
{
    public class Student
    {
        [Identity]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        [Required]
        public string? LogIn { get; set; }
        [Required]
        [PasswordPropertyText]
        public string? Password { get; set; }
        public string? Image { get; set; }
        public Teacher? Teachers { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
        public decimal Payment { get; set; }
    }
}
