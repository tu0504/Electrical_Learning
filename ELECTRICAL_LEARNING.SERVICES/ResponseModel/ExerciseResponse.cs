using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.ResponseModel
{
    public static class ExerciseResponse
    {
        public record GetExerciseModel(
            int Id,
            string Title,
            int LessonId,
            DateTimeOffset CreatedAt,
            DateTimeOffset UpdatedAt
        );
    }
}
