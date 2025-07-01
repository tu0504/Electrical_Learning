using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.RequestModel
{
    public class LessonRequest
    {
        public class CreateLessonModel
        {
            [Required(ErrorMessage = "Tiêu đề không được để trống.")]
            [MaxLength(200, ErrorMessage = "Tiêu đề không được vượt quá 200 ký tự.")]
            public string Title { get; set; }

            [Required(ErrorMessage = "ChapterId không được để trống.")]
            public int ChapterId { get; set; }
        }

        public class UpdateLessonModel
        {
            [MaxLength(200, ErrorMessage = "Tiêu đề không được vượt quá 200 ký tự.")]
            public string? Title { get; set; }

            public int? ChapterId { get; set; }
        }
    }
}
