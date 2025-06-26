using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.RequestModel
{
    public class GradeRequest
    {
        public class CreateGradeModel
        {
            [Required(ErrorMessage = "Tên khối không được để trống.")]
            [Range(0, 20, ErrorMessage = "Giá trị phải trong khoảng 0-20")]
            public int Name { get; set; }
        }

        public class UpdateGradeModel
        {
            [Required(ErrorMessage = "Tên khối không được để trống.")]
            [Range(0, 20, ErrorMessage = "Giá trị phải trong khoảng 0-20")]
            public int Name { get; set; }
        }
    }
}
