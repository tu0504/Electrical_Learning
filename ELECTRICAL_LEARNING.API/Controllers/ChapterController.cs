using ElectricalLearning.Services.Implementations;
using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace ElectricalLearning.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IChapterService _chapterService;
        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetChapters(string? searchTerm, int pageIndex = 1, int pageSize = 10)
        {
            var result = await _chapterService.GetChapters(searchTerm, pageIndex, pageSize);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _chapterService.GetById(id);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChapterRequest.CreateChapterModel request)
        {
            var result = await _chapterService.CreateChapter(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ChapterRequest.UpdateChapterModel request)
        {
            var result = await _chapterService.UpdateChapter(id, request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _chapterService.DeleteChapter(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
