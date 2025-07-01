using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.ResponseModel
{
    public class ChapterResponse
    {
        public record GetChaptersModel(
            int id,
            string Name,
            int GradeId
        );
    }
}
