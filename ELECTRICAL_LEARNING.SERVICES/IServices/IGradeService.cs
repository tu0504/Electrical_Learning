using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricalLearning.Repositories.Abstraction;
using ElectricalLearning.Services.Common;
using ElectricalLearning.Services.RequestModel;
using ElectricalLearning.Services.ResponseModel;

namespace ElectricalLearning.Services.IServices
{
    public interface IGradeService
    {
        Task<Result<PagedResult<GradeResponse.GetGradesModel>>> GetGrades(string? searchTerm, int pageIndex, int pageSize);
        Task<Result<GradeResponse.GetGradesModel>> GetById(int id);

        Task<Result> CreateGrade(GradeRequest.CreateGradeModel request);
        Task<Result> UpdateGrade(int id, GradeRequest.UpdateGradeModel request);
        Task<Result> DeleteGrade(int id);
    }
}
