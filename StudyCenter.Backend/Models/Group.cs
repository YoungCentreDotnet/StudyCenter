using LinqToDB.Mapping;

namespace StudyCenter.Backend.Models
{
    public class Group
    {

        [Identity]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Discreption { get; set; }
        public string? Image { get; set; }
        public Teacher? Teachers { get; set; }
        public string?  Room { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
