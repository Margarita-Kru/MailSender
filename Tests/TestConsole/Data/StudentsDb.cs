using Microsoft.EntityFrameworkCore;
using TestConsole.Entityes;

namespace TestConsole.Data
{
    public class StudentsDb:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public StudentsDb(DbContextOptions<StudentsDb> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<Student>()
                .Property(s => s.LastName)
                .HasMaxLength(150)
                .IsRequired();

            model.Entity<Student>()
               .Property(s => s.Name)
               .IsRequired();
        }
    }
}
