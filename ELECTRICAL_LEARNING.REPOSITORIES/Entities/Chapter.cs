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
    public class Chapter : Entity<int>
    {
        [Required]
        public string Name { get; set; }

        public int GradeId { get; set; }
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }
        public ICollection<CircuitModel> CircuitModels { get; set; } = new List<CircuitModel>();
    }
}
