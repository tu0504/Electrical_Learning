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
    public class Formula: Entity<int>
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Expression { get; set; } // e.g., "V = I * R"

        [Required]
        public string Description { get; set; }

        public int CircuitModelId { get; set; }
        [ForeignKey("CircuitModelId")]
        public CircuitModel CircuitModel { get; set; }
    }
}
