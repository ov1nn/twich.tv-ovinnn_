using Microsoft.EntityFrameworkCore;

namespace twich.tv_ovinnn_.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Таблицы бд
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        // Конфигурация модели
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Admin",
                    Password = "admin1",
                    IsAdmin = true
                },
                new User
                {
                    Id = 2,
                    Username = "User",
                    Password = "User1",
                    IsAdmin = false
                }
            );
        }
    }
}
