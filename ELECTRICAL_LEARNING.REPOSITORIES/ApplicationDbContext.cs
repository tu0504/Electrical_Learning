using ELECTRICAL_LEARNING.REPOSITORIES.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELECTRICAL_LEARNING.REPOSITORIES
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<CircuitModel> CircuitModels { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<AIRequest> AIRequests { get; set; }

        // kết nối với cơ sở dữ liệu SQL Server(file appseting)
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed dữ liệu mẫu
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, FullName = "Nguyễn Văn A", Email = "teacher@gmail.com", PasswordHash= "teacher123", Role = "Teacher", CreatedAt = DateTimeOffset.UtcNow},
                new Account { Id = 2, FullName = "Trần Thị B", Email = "student@gmail.com", PasswordHash = "student123", Role = "Student", CreatedAt = DateTimeOffset.UtcNow },
                new Account { Id = 3, FullName = "Lê Văn C", Email = "admin@gmail.com", PasswordHash = "adminr123", Role = "Admin", CreatedAt = DateTimeOffset.UtcNow }
            );

            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, Name =  6 },
                new Grade { Id = 2, Name = 7 },
                new Grade { Id = 3, Name = 8 },
                new Grade { Id = 4, Name = 9 },
                new Grade { Id = 5, Name = 10 },
                new Grade { Id = 6, Name = 11 },
                new Grade { Id = 7, Name = 12 }
            );

            modelBuilder.Entity<Chapter>().HasData(
                new Chapter { Id = 1, Name = "Điện học cơ bản", GradeId = 1 }
            );

            modelBuilder.Entity<Lesson>().HasData(
                new Lesson { Id = 1, Title = "Định luật Ôm", ChapterId = 1 }
            );

            modelBuilder.Entity<CircuitModel>().HasData(
                new CircuitModel
                {
                    Id = 1,
                    Name = "Mạch mẫu 1",
                    JsonData = "{\"resistor\": 100, \"voltage\": 5}",
                    CreatedAt = DateTimeOffset.UtcNow,
                    AccountId = 1,
                    LessonId = 1
                }
            );

            modelBuilder.Entity<Formula>().HasData(
                new Formula
                {
                    Id = 1,
                    Name = "Định luật Ôm",
                    Expression = "I = U / R",
                    Description = "Cường độ dòng điện chạy qua dây dẫn tỉ lệ thuận với hiệu điện thế đặt vào hai đầu dây và tỉ lệ nghịch với điện trở của dây.",
                    CircuitModelId = 1
                }
            );

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = 1,
                    Title = "Khi đặt vào hai đầu dây dẫn một hiệu điện thế 12V thì cường độ dòng điện chạy qua nó là 0,5A.Tính điện trở? ",
                    LessonId = 1,
                }
            );

            modelBuilder.Entity<Submission>().HasData(
                new Submission
                {
                    Id = 1,
                    AccountId = 2,
                    ExerciseId = 1,
                    Answer = "R = 6 ohm",
                    CreatedAt = DateTimeOffset.UtcNow,
                }
            );

            modelBuilder.Entity<AIRequest>().HasData(
                new AIRequest
                {
                    Id = 1,
                    AccountId = 2,
                    ImageUrl = "https://example.com/image1.png",
                    CreatedAt = DateTimeOffset.UtcNow,
                    Status = "Pending"
                }
            );
        }
    }
}
