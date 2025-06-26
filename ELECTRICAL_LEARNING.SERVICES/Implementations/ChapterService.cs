using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricalLearning.Repositories.Abstraction;
using ElectricalLearning.Repositories.Entities;
using ElectricalLearning.Services.Common;
using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using ElectricalLearning.Services.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace ElectricalLearning.Services.Implementations
{
    public class ChapterService : IChapterService
    {
        private readonly IBaseRepository<Chapter,int> _chapterRepository;
        public ChapterService(IBaseRepository<Chapter, int> chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<Result> CreateChapter(ChapterRequest.CreateChapterModel request)
        {
            var chapter = new Chapter
            {
                Name = request.Name,
                GradeId = request.GradeId,
            };
            await _chapterRepository.Add(chapter);
            await _chapterRepository.SaveChangesAsync();

            return Result.Success("Tạo chương mới thành công");
        }

        public async Task<Result> DeleteChapter(int id)
        {
            var chapter = await _chapterRepository.GetById(id);
            if (chapter == null || chapter.IsDeleted)
                return Result.Failure("Chương không tồn tại", 404);
            chapter.IsDeleted = true;
            await _chapterRepository.Update(chapter);
            await _chapterRepository.SaveChangesAsync();

            return Result.Success("Xóa chương thành công");
        }

        public async Task<Result<ChapterResponse.GetChaptersModel>> GetById(int id)
        {
            var raw = await _chapterRepository.GetById(id);
            if (raw == null || raw.IsDeleted) throw new Exception("Không tìm thấy chương");

            var result = new ChapterResponse.GetChaptersModel(
                raw.Id,
                raw.Name,
                raw.GradeId
                );
            return Result<ChapterResponse.GetChaptersModel>.Success(result, "Lấy chương thành công");
        }

        public async Task<Result<PagedResult<ChapterResponse.GetChaptersModel>>> GetChapters(string? searchTerm, int pageIndex, int pageSize)
        {
            var raw = _chapterRepository.GetAll();
            raw = raw.AsNoTracking();
            raw = raw.Where(x => !x.IsDeleted);
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var cleanSearchTerm = searchTerm.Trim().ToLower();
                raw = raw.Where(x => x.Name.Contains(cleanSearchTerm));
            }

            var query = raw.Select(x => new ChapterResponse.GetChaptersModel(
                x.Id,
                x.Name,
                x.GradeId
                ));

            var pagedResult = await PagedResult<ChapterResponse.GetChaptersModel>.CreateAsync(query, pageIndex, pageSize);
            
            var result = Result<PagedResult<ChapterResponse.GetChaptersModel>>.Success(pagedResult, "Lấy danh sách chương thành công");
            return result;
        }

        public async Task<Result> UpdateChapter(int id, ChapterRequest.UpdateChapterModel request)
        {
            var chapter = await _chapterRepository.GetById(id);
            if (chapter == null || chapter.IsDeleted)
                return Result.Failure("Không tìm thấy chương", 404);

            chapter.Name = request.Name;
            chapter.GradeId = request.GradeId;

            await _chapterRepository.Update(chapter);
            await _chapterRepository.SaveChangesAsync();

            return Result.Success("Cập nhật chương thành công");
        }
    }
}
