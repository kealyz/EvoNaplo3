using EvoNaplo.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoNaplo.DataAccessLayer
{
    public class EvoNaploContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<StudentData> StudentDatas { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<AttendanceSheet> AttendanceSheets { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public EvoNaploContext(DbContextOptions<EvoNaploContext> options) : base(options)
        {
        }
    }
}
