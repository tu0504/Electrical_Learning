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
    public class LessonService : ILessonService
    {
        private readonly IBaseRepository<Lesson, int> _lessonRepository;

        public LessonService(IBaseRepository<Lesson, int> lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<Result> CreateLesson(LessonRequest.CreateLessonModel request)
        {
            var lesson = new Lesson
            {
                Title = request.Title,
                ChapterId = request.ChapterId
            };

            await _lessonRepository.Add(lesson);
            await _lessonRepository.SaveChangesAsync();

            return Result.Success("Tạo bài học thành công");
        }

        public async Task<Result> DeleteLesson(int id)
        {
            var lesson = await _lessonRepository.GetById(id);
            if (lesson == null || lesson.IsDeleted)
                return Result.Failure("Bài học không tồn tại", 404);

            lesson.IsDeleted = true;
            await _lessonRepository.Update(lesson);
            await _lessonRepository.SaveChangesAsync();

            return Result.Success("Xóa bài học thành công");
        }

        public async Task<Result<LessonResponse.GetLessonModel>> GetById(int id)
        {
            var lesson = await _lessonRepository.GetAll()
                .Include(x => x.Chapter)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (lesson == null)
                return Result<LessonResponse.GetLessonModel>.Failure("Không tìm thấy bài học", 404);

            var result = new LessonResponse.GetLessonModel(
                lesson.Id,
                lesson.Title,
                lesson.ChapterId,
                lesson.IsDeleted
            );

            return Result<LessonResponse.GetLessonModel>.Success(result, "Lấy bài học thành công");
        }

        public async Task<Result<PagedResult<LessonResponse.GetLessonModel>>> GetLessons(string? searchTerm, int pageIndex, int pageSize)
        {
            var query = _lessonRepository.GetAll()
                .AsNoTracking()
                .Include(x => x.Chapter)
                .Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();
                query = query.Where(x => x.Title.ToLower().Contains(term));
            }

            var projection = query.Select(x => new LessonResponse.GetLessonModel(
                x.Id,
                x.Title,
                x.ChapterId,
                x.IsDeleted
            ));

            var pagedResult = await PagedResult<LessonResponse.GetLessonModel>.CreateAsync(projection, pageIndex, pageSize);
            return Result<PagedResult<LessonResponse.GetLessonModel>>.Success(pagedResult, "Lấy danh sách bài học thành công");
        }

        public async Task<Result> UpdateLesson(int id, LessonRequest.UpdateLessonModel request)
        {
            var lesson = await _lessonRepository.GetById(id);
            if (lesson == null || lesson.IsDeleted)
                return Result.Failure("Không tìm thấy bài học", 404);

            if (!string.IsNullOrEmpty(request.Title))
                lesson.Title = request.Title;

            if (request.ChapterId.HasValue)
                lesson.ChapterId = request.ChapterId.Value;

            await _lessonRepository.Update(lesson);
            await _lessonRepository.SaveChangesAsync();

            return Result.Success("Cập nhật bài học thành công");
        }
    }
}
