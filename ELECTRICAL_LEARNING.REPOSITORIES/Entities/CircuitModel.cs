using ElectricalLearning.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Repositories.Entities
{
    public class CircuitModel : Entity<int>, IAuditable
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string JsonData { get; set; }
        public DateTimeOffset CreatedAt { get; set ; }
        public DateTimeOffset UpdatedAt { get; set ; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }

        public ICollection<Formula> Formulas { get; set; }
        
    }
}
