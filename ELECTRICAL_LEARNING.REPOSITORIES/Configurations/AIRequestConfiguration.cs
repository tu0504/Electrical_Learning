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
    public class AIRequestConfiguration : IEntityTypeConfiguration<AIRequest>
    {
        public void Configure(EntityTypeBuilder<AIRequest> builder)
        {
            List<AIRequest> list = new List<AIRequest>() {              
                new AIRequest
                {
                    Id = 1,
                    AccountId = 2,
                    ImageUrl = "https://example.com/image1.png",
                    CreatedAt = DateTimeOffset.UtcNow,
                    Status = "Pending"
                }
            };

            builder.HasData(list);
        }
    }
}
