using Microsoft.EntityFrameworkCore;
using StudyCenter.Backend.Models;

namespace StudyCenter.Backend.DataLayer
{
    public class StudyDbContext: DbContext
    {
        public StudyDbContext(DbContextOptions<StudyDbContext> db):
            base(db)
        {}

        public DbSet<Admin> Admins{ get; set; }
        public DbSet<Teacher> Teschers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
