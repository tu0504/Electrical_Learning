using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricalLearning.Repositories.Entities;

namespace ElectricalLearning.Services.RequestModel
{
    public class ChapterRequest
    {
        public class CreateChapterModel
        {
            [Required(ErrorMessage = "Tên công thức không được để trống.")]
            [MaxLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Khối không được để trống.")]
            public int GradeId { get; set; }
        }
        public class UpdateChapterModel
        {
            [Required(ErrorMessage = "Tên công thức không được để trống.")]
            [MaxLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Khối không được để trống.")]
            public int GradeId { get; set; }
        }
    }
}
