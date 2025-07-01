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
    public interface ISubmissionService
    {
        Task<Result<PagedResult<SubmissionResponse.GetSubmissionModel>>> GetSubmissions(string? searchTerm, int pageIndex, int pageSize);
        Task<Result<SubmissionResponse.GetSubmissionModel>> GetById(int id);
        Task<Result> CreateSubmission(SubmissionRequest.CreateSubmissionModel model);
        Task<Result> UpdateSubmission(int id, SubmissionRequest.UpdateSubmissionModel model);
        Task<Result> DeleteSubmission(int id);
    }
}
