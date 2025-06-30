using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.ResponseModel
{
    public static class GradeResponse
    {
        public record GetGradesModel(
            int id,
            int Name
        );
    }
}
