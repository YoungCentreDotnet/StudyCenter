using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;

namespace StudyCenter.Backend.Models
{
    public class Subject
    {
        [Identity]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [MaxLength(200)]
        public string? Discraption { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string? Image { get; set; }

    }
}
