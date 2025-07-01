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
    public interface IChapterService
    {
        Task<Result<PagedResult<ChapterResponse.GetChaptersModel>>> GetChapters(string? searchTerm, int pageIndex, int pageSize);
        Task<Result<ChapterResponse.GetChaptersModel>> GetById(int id);

        Task<Result> CreateChapter(ChapterRequest.CreateChapterModel request);
        Task<Result> UpdateChapter(int id, ChapterRequest.UpdateChapterModel request);
        Task<Result> DeleteChapter(int id);
    }
}
