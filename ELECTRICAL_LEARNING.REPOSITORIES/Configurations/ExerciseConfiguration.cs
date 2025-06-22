using ElectricalLearning.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Repositories.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            List<Exercise> exercises = new List<Exercise>() {
                new Exercise
                {
                    Id = 1,
                    Title = "Khi đặt vào hai đầu dây dẫn một hiệu điện thế 12V thì cường độ dòng điện chạy qua nó là 0,5A.Tính điện trở? ",
                    LessonId = 1,
                }
            };
            builder.HasData(exercises);
        }
    }
}
