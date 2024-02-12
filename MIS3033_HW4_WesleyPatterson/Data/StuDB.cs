
using a;
using Microsoft.EntityFrameworkCore;


namespace a
{
    public class StuDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite("Data Source=Students.sqlitedb");
        }
    }
}
