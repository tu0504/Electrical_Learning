using ELECTRICAL_LEARNING.REPOSITORIES.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELECTRICAL_LEARNING.REPOSITORIES.Entities
{
    public class Account : Entity<int>, IAuditable
    {
        

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string PasswordHash { get; set; }

        [Required, RegularExpression("^(Student|Teacher| Admin)$")]
        public string Role { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public ICollection<CircuitModel> CircuitModels { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Submission> Submissions { get; set; }
        public ICollection<AIRequest> AIRequests { get; set; }
        
    }
}
