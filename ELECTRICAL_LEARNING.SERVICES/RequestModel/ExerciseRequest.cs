using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.RequestModel
{
    public class ExerciseRequest
    {
        public class CreateExerciseModel
        {
            [Required]
            public string Title { get; set; }

            [Required]
            public int LessonId { get; set; }
        }

        public class UpdateExerciseModel
        {
            public string? Title { get; set; }
            public int? LessonId { get; set; }
        }
    }
}
