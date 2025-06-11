using ELECTRICAL_LEARNING.REPOSITORIES.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELECTRICAL_LEARNING.REPOSITORIES.Entities
{
    public class Lesson : Entity<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int ChapterId { get; set; }
        [ForeignKey("ChapterId")]
        public Chapter Chapter { get; set; }

        public ICollection<CircuitModel> CircuitModels { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
