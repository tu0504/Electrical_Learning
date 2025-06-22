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
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            List<Grade> grades = new List<Grade>()
            {              
                new Grade { Id = 1, Name =  6 },
                new Grade { Id = 2, Name = 7 },
                new Grade { Id = 3, Name = 8 },
                new Grade { Id = 4, Name = 9 },
                new Grade { Id = 5, Name = 10 },
                new Grade { Id = 6, Name = 11 },
                new Grade { Id = 7, Name = 12 }
            };

            builder.HasData(grades);
        }
    }
}
