using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.RequestModel
{
    public class SubmissionRequest
    {
        public class CreateSubmissionModel
        {
            [Required]
            public string Answer { get; set; }

            [Required]
            public int AccountId { get; set; }

            [Required]
            public int ExerciseId { get; set; }
        }

        public class UpdateSubmissionModel
        {
            public string? Answer { get; set; }
            public int? AccountId { get; set; }
            public int? ExerciseId { get; set; }
        }
    }
}
