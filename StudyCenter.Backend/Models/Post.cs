using LinqToDB.Mapping;

namespace StudyCenter.Backend.Models
{
    public class Post
    {
        [Identity]
        public Guid Id { get; set; }
        public string? PostName { get; set; }
        public string? Image { get; set; }
        public string? Discreption { get; set; }

    }
}
