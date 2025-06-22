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
    public class Submissionconfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            List<Submission> submissions = new List<Submission>()
            {
              
                new Submission
                {
                    Id = 1,
                    AccountId = 2,
                    ExerciseId = 1,
                    Answer = "R = 6 ohm",
                    CreatedAt = DateTimeOffset.UtcNow,
                }
            };
            builder.HasData(submissions);
        }
    }
}
