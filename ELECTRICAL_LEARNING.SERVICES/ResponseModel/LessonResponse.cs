using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.ResponseModel
{
    public class LessonResponse
    {
        public record GetLessonModel(
        int Id,
        string Title,
        int ChapterId,
        bool IsDeleted
    );
    }
}
