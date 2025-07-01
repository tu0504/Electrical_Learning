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
    public interface IExerciseService
    {
        Task<Result<PagedResult<ExerciseResponse.GetExerciseModel>>> GetExercises(string? searchTerm, int pageIndex, int pageSize);
        Task<Result<ExerciseResponse.GetExerciseModel>> GetById(int id);
        Task<Result> CreateExercise(ExerciseRequest.CreateExerciseModel exercise);
        Task<Result> UpdateExercise(int id, ExerciseRequest.UpdateExerciseModel exercise);
        Task<Result> DeleteExercise(int id);
    }
}
