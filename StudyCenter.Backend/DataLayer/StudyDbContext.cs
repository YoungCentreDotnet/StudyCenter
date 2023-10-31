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
    }
}
