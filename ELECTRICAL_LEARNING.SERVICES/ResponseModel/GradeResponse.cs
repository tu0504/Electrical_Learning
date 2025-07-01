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
            int Id,
            int Name,
            List<ChapterModel> Chapters
        );

        public record ChapterModel(
            int Id,
            string Name,
            int GradeId
        );
    }
}

