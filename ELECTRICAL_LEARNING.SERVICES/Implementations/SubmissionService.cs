using ElectricalLearning.Repositories.Abstraction;
using ElectricalLearning.Repositories.Entities;
using ElectricalLearning.Services.Common;
using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using ElectricalLearning.Services.ResponseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.Implementations
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IBaseRepository<Submission, int> _submissionRepository;

        public SubmissionService(IBaseRepository<Submission, int> submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        public async Task<Result<PagedResult<SubmissionResponse.GetSubmissionModel>>> GetSubmissions(string? searchTerm, int pageIndex, int pageSize)
        {
            var query = _submissionRepository.GetAll().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string term = searchTerm.Trim().ToLower();
                query = query.Where(x => x.Answer.ToLower().Contains(term));
            }

            var projected = query.Select(x => new SubmissionResponse.GetSubmissionModel(
                x.Id,
                x.Answer,
                x.AccountId,
                x.ExerciseId,
                x.CreatedAt,
                x.UpdatedAt
            ));

            var paged = await PagedResult<SubmissionResponse.GetSubmissionModel>.CreateAsync(projected, pageIndex, pageSize);
            return Result<PagedResult<SubmissionResponse.GetSubmissionModel>>.Success(paged, "Danh sách bài nộp.");
        }

        public async Task<Result<SubmissionResponse.GetSubmissionModel>> GetById(int id)
        {
            var submission = await _submissionRepository.GetById(id);
            if (submission == null)
                return Result<SubmissionResponse.GetSubmissionModel>.Failure("Không tìm thấy bài nộp.", 404);

            var model = new SubmissionResponse.GetSubmissionModel(
                submission.Id,
                submission.Answer,
                submission.AccountId,
                submission.ExerciseId,
                submission.CreatedAt,
                submission.UpdatedAt
            );

            return Result<SubmissionResponse.GetSubmissionModel>.Success(model, "Lấy chi tiết thành công.");
        }

        public async Task<Result> CreateSubmission(SubmissionRequest.CreateSubmissionModel model)
        {
            var entity = new Submission
            {
                Answer = model.Answer,
                AccountId = model.AccountId,
                ExerciseId = model.ExerciseId,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _submissionRepository.Add(entity);
            await _submissionRepository.SaveChangesAsync();

            return Result.Success("Tạo bài nộp thành công.");
        }

        public async Task<Result> UpdateSubmission(int id, SubmissionRequest.UpdateSubmissionModel model)
        {
            var entity = await _submissionRepository.GetById(id);
            if (entity == null)
                return Result.Failure("Không tìm thấy bài nộp.", 404);

            entity.Answer = model.Answer ?? entity.Answer;
            if (model.AccountId.HasValue) entity.AccountId = model.AccountId.Value;
            if (model.ExerciseId.HasValue) entity.ExerciseId = model.ExerciseId.Value;

            entity.UpdatedAt = DateTimeOffset.UtcNow;

            await _submissionRepository.Update(entity);
            await _submissionRepository.SaveChangesAsync();

            return Result.Success("Cập nhật bài nộp thành công.");
        }

        public async Task<Result> DeleteSubmission(int id)
        {
            var entity = await _submissionRepository.GetById(id);
            if (entity == null)
                return Result.Failure("Không tìm thấy bài nộp.", 404);

            await _submissionRepository.Remove(entity);
            await _submissionRepository.SaveChangesAsync();

            return Result.Success("Xoá bài nộp thành công.");
        }
    }
}
