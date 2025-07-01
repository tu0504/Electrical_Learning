using ElectricalLearning.Repositories.Abstraction;
using ElectricalLearning.Services.Common;
using ElectricalLearning.Services.RequestModel;
using ElectricalLearning.Services.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.IServices
{
    public interface ILessonService
    {
        Task<Result<PagedResult<LessonResponse.GetLessonModel>>> GetLessons(string? searchTerm, int pageIndex, int pageSize);
        Task<Result<LessonResponse.GetLessonModel>> GetById(int id);

        Task<Result> CreateLesson(LessonRequest.CreateLessonModel request);
        Task<Result> UpdateLesson(int id, LessonRequest.UpdateLessonModel request);
        Task<Result> DeleteLesson(int id);
    }
}
