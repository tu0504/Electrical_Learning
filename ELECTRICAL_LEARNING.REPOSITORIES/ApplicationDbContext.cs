using ElectricalLearning.Repositories.Configurations;
using ElectricalLearning.Repositories.Entities;
using ElectricalLearning.Repositories.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Repositories
{
    public class ApplicationDbContext : DbContext
    {

        // kết nối với cơ sở dữ liệu SQL Server(file appseting)
        private readonly IConfiguration _configuration; //Tim hieu lai Dependency Injection trong ASP.NET Core
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

                optionsBuilder.AddInterceptors(new UpdateAuditableInterceptor());
                optionsBuilder.AddInterceptors(new DeleteAuditableInterceptor());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new AccountConfiguration());
            //modelBuilder.ApplyConfiguration(new GradeConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        }
    }
}
