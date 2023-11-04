using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudyCenter.Backend.Models
{
    public class Teacher
    {
        [Identity]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName  { get; set; }
        public DateTimeOffset DataOfBrith  { get; set; }
        [Required]
        public string? LogIn { get; set; }
        [Required]
        [PasswordPropertyText]
        public string? Password { get; set; }
        public ICollection<Student>? Students{ get; set; }
        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<Group>? Groups { get; set; }
        public decimal Salary { get; set; }
        public string? Image { get; set; }
    }
}
