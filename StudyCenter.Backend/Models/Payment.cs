using LinqToDB.Mapping;

namespace StudyCenter.Backend.Models
{
    public class Payment
    {
        [Identity]
        public Guid Id { get; set; }
        public decimal ALLMoney { get; set; }
        public decimal Salary { get; set; }
        public decimal AnotherExpense { get; set; }
    }
}
