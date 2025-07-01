using ElectricalLearning.Repositories.Abstraction;
using ElectricalLearning.Repositories.Entities;
using ElectricalLearning.Services.Common;
using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using ElectricalLearning.Services.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace ElectricalLearning.Services.Implementations
{
    public class ExerciseService : IExerciseService
    {
        private readonly IBaseRepository<Exercise, int> _exerciseRepository;

        public ExerciseService(IBaseRepository<Exercise, int> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Result<PagedResult<ExerciseResponse.GetExerciseModel>>> GetExercises(string? searchTerm, int pageIndex, int pageSize)
        {
            var raw = _exerciseRepository.GetAll().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string term = searchTerm.Trim().ToLower();
                raw = raw.Where(e => e.Title.ToLower().Contains(term));
            }

            var query = raw.Select(e => new ExerciseResponse.GetExerciseModel(
                e.Id,
                e.Title,
                e.LessonId,
                e.CreatedAt,
                e.UpdatedAt
            ));

            var paged = await PagedResult<ExerciseResponse.GetExerciseModel>.CreateAsync(query, pageIndex, pageSize);

            return Result<PagedResult<ExerciseResponse.GetExerciseModel>>.Success(paged, "Danh sách bài tập.");
        }

        public async Task<Result<ExerciseResponse.GetExerciseModel>> GetById(int id)
        {
            var exercise = await _exerciseRepository.GetById(id);
            if (exercise == null)
                return Result<ExerciseResponse.GetExerciseModel>.Failure("Không tìm thấy bài tập.", 404);

            var model = new ExerciseResponse.GetExerciseModel(
                exercise.Id,
                exercise.Title,
                exercise.LessonId,
                exercise.CreatedAt,
                exercise.UpdatedAt
            );

            return Result<ExerciseResponse.GetExerciseModel>.Success(model, "Lấy thông tin bài tập thành công.");
        }

        public async Task<Result> CreateExercise(ExerciseRequest.CreateExerciseModel request)
        {
            var entity = new Exercise
            {
                Title = request.Title,
                LessonId = request.LessonId,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _exerciseRepository.Add(entity);
            await _exerciseRepository.SaveChangesAsync();

            return Result.Success("Tạo bài tập thành công.");
        }

        public async Task<Result> UpdateExercise(int id, ExerciseRequest.UpdateExerciseModel request)
        {
            var exercise = await _exerciseRepository.GetById(id);
            if (exercise == null)
                return Result.Failure("Bài tập không tồn tại.", 404);

            exercise.Title = request.Title ?? exercise.Title;
            if (request.LessonId.HasValue)
                exercise.LessonId = request.LessonId.Value;

            exercise.UpdatedAt = DateTimeOffset.UtcNow;

            await _exerciseRepository.Update(exercise);
            await _exerciseRepository.SaveChangesAsync();

            return Result.Success("Cập nhật bài tập thành công.");
        }

        public async Task<Result> DeleteExercise(int id)
        {
            var exercise = await _exerciseRepository.GetById(id);
            if (exercise == null)
                return Result.Failure("Không tìm thấy bài tập.", 404);

            await _exerciseRepository.Remove(exercise);
            await _exerciseRepository.SaveChangesAsync();

            return Result.Success("Xoá bài tập thành công.");
        }
    }
}
