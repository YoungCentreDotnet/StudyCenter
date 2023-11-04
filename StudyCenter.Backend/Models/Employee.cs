using LinqToDB.Mapping;
using StudyCenter.Backend.Models.Postion;

namespace StudyCenter.Backend.Models
{
    public class Employee
    {
        [Identity]
        public Guid Id { get; set; }
        public RoleEmployee RoleEmp { get; set; }
        public string? Discreption { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public decimal? Salary { get; set; }
    }
}
