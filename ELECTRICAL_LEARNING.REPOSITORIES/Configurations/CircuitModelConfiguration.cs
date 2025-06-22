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
    public class CircuitModelConfiguration : IEntityTypeConfiguration<CircuitModel>
    {
        public void Configure(EntityTypeBuilder<CircuitModel> builder)
        {
            List<CircuitModel> circuitModels = new List<CircuitModel>()
            {
                new CircuitModel
                {
                    Id = 1,
                    Name = "Mạch mẫu 1",
                    JsonData = "{\"resistor\": 100, \"voltage\": 5}",
                    CreatedAt = DateTimeOffset.UtcNow,
                    AccountId = 1,
                    LessonId = 1
                }
            };

            builder.HasData(circuitModels);
        }
    }
}
