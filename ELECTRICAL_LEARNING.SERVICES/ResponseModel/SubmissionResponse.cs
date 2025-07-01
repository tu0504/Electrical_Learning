using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.ResponseModel
{
    public static class SubmissionResponse
    {
        public record GetSubmissionModel(
            int Id,
            string Answer,
            int AccountId,
            int ExerciseId,
            DateTimeOffset CreatedAt,
            DateTimeOffset UpdatedAt
        );
    }
}
