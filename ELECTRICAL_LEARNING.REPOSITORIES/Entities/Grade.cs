using ELECTRICAL_LEARNING.REPOSITORIES.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELECTRICAL_LEARNING.REPOSITORIES.Entities
{
    public class Grade : Entity<int>
    {
        [Required]
        public int Name { get; set; }

        public ICollection<Chapter> Chapters { get; set; }
    }
}
