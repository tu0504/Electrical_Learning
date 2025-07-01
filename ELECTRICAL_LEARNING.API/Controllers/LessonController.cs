using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace ElectricalLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetLessons(string? searchTerm, int pageIndex = 1, int pageSize = 10)
        {
            var result = await _lessonService.GetLessons(searchTerm, pageIndex, pageSize);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _lessonService.GetById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LessonRequest.CreateLessonModel request)
        {
            var result = await _lessonService.CreateLesson(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] LessonRequest.UpdateLessonModel request)
        {
            var result = await _lessonService.UpdateLesson(id, request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _lessonService.DeleteLesson(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
