using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.RequestModel
{
        public class FormulaRequest
    {
        public class CreateFormulaModel
        {
            [Required(ErrorMessage = "Tên công thức không được để trống.")]
            [MaxLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Biểu thức không được để trống.")]
            public string Expression { get; set; }

            [Required(ErrorMessage = "Mô tả không được để trống.")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Mô hình mạch điện không được để trống.")]
            public int CircuitModelId { get; set; }
        }

        public class UpdateFormulaModel
        {
            [Required(ErrorMessage = "Tên công thức không được để trống.")]
            [MaxLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Biểu thức không được để trống.")]
            public string Expression { get; set; }

            [Required(ErrorMessage = "Mô tả không được để trống.")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Mô hình mạch điện không được để trống.")]
            public int CircuitModelId { get; set; }
        }
    }
}
